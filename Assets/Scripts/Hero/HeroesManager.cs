using System.Collections.Generic;
using System.Linq;
using Hero.Settings;
using UnityEngine;

namespace Hero
{
    public class HeroesManager : MonoBehaviour
    {
        public static readonly HeroSettings MaxSettings = new()
        {
            Health = 200,
            Attack = 20,
            Defense = 10,
            Speed = 10
        };

        [SerializeField] private HeroController[] _heroPrefabs;
        [SerializeField] private Transform _heroHolder;


        private readonly List<HeroController> _heroControllers = new();

        private void Awake()
        {
            foreach (var heroPrefab in _heroPrefabs)
            {
                InstantiateHero(heroPrefab);
            }
            
            ActivateSelectedHero(GetSavedHeroController());
            
            DontDestroyOnLoad(this);
        }
        
        public IReadOnlyList<HeroController> GetHeroes()
        {
            return _heroControllers;
        }
        
        public void ActivateSelectedHero(HeroController hero)
        {
            var selectedHeroName = hero.HeroSettings.Name;
            var currentHero = _heroControllers.FirstOrDefault(heroController => 
                heroController.HeroSettings.Name == selectedHeroName);
            
            if (currentHero != null)
            {
                currentHero.gameObject.SetActive(true);
                currentHero.HeroSettings.IsSelected = true;
            }
        }

        private void InstantiateHero(HeroController heroPrefab)
        {
            var heroController = Instantiate(heroPrefab, _heroHolder);
            heroController.gameObject.SetActive(false);
            _heroControllers.Add(heroController);
        }

        public HeroController GetSavedHeroController()
        {
            var selectedHeroName = PrefsManager.LoadActiveHero();
            
            return _heroControllers.FirstOrDefault(heroController => 
                heroController.HeroSettings.Name == selectedHeroName);
        }
    }
}