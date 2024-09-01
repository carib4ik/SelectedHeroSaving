using System;
using System.Collections.Generic;
using Currency;
using Hero;
using UnityEngine;

namespace HeroSelection
{
    public class HeroSelectionScreenManager : MonoBehaviour
    {
        public event Action<HeroController> HeroSelected;
        public event Action<HeroController> HeroChanged;
    
        [SerializeField] private CurrencyManager _currencyManager;
        [SerializeField] private HeroSelectionScreenView _heroSelectionScreenView;
        [SerializeField] private HeroSwitcher _heroSwitcher;

        private HeroController _currentHeroController;
        private IReadOnlyList<HeroController> _heroControllers;

        public void Initialize(IReadOnlyList<HeroController> heroControllers)
        {
            _heroControllers = heroControllers;
            _heroSwitcher.Initialize(_heroControllers);
        }
    
        public void OpenScreen(HeroController heroController)
        {
            gameObject.SetActive(true);
            _currentHeroController = heroController;

            CheckBoughtHeroes();
        
            _heroSelectionScreenView.UpdateHeroSelectionView(_currentHeroController.HeroSettings);

            _heroSwitcher.HeroChanged += OnHeroChanged;
            _heroSwitcher.SetCurrentHero(heroController);
        }

        public void TryBuyHero()
        {
            var price = _currentHeroController.HeroSettings.Price;

            if (_currencyManager.TryBuy(price))
            {
                _currentHeroController.HeroSettings.WasBought = true;
                _heroSelectionScreenView.UpdateHeroSelectionView(_currentHeroController.HeroSettings);
                
                PrefsManager.SaveBoughtHero(_currentHeroController.HeroSettings.Name);
            }
        }

        public void SelectHero()
        {
            foreach (var heroController in _heroControllers)
            {
                heroController.HeroSettings.IsSelected = _currentHeroController == heroController;
                heroController.gameObject.SetActive(heroController.HeroSettings.IsSelected);
            }

            PrefsManager.SaveActiveHero(_currentHeroController.HeroSettings.Name);
            
            HeroSelected?.Invoke(_currentHeroController);
        }

        public void OnBackButtonClicked()
        {
            foreach (var heroController in _heroControllers)
            {
                if (PrefsManager.LoadActiveHero() != heroController.HeroSettings.Name)
                {
                    heroController.gameObject.SetActive(false);
                    heroController.HeroSettings.IsSelected = false;
                }
                else
                {
                    heroController.gameObject.SetActive(true);
                }
            }
        }

        private void OnHeroChanged(HeroController currentHeroController)
        {
            _currentHeroController = currentHeroController;
            _heroSelectionScreenView.UpdateHeroSelectionView(_currentHeroController.HeroSettings);
            HeroChanged?.Invoke(currentHeroController);
        }


        private void OnDisable()
        {
            _heroSwitcher.HeroChanged -= OnHeroChanged;
        }
        
        private void CheckBoughtHeroes()
        {
            var boughtHeroes = PrefsManager.LoadBoughtHeroes().Split(" ");

            foreach (var heroController in _heroControllers)
            {
                foreach (var boughtHero in boughtHeroes)
                {
                    if (heroController.HeroSettings.Name == boughtHero)
                    {
                        heroController.HeroSettings.WasBought = true;
                    }
                }
            }
        }
    }
}