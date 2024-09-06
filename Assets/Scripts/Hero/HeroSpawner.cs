using UnityEngine;
using UnityEngine.AI;

namespace Hero
{
    public class HeroSpawner : MonoBehaviour
    {
        [SerializeField] private Camera _camera;

        private GameObject _hero;
    
        private void Awake()
        {
            var heroesManager = FindObjectOfType<HeroesManager>();
            _hero = Instantiate(heroesManager.GetSavedHeroController().gameObject, transform);
            Destroy(heroesManager.gameObject);
            _hero.GetComponent<HeroMovementController>().enabled = true;
            _hero.GetComponent<NavMeshAgent>().enabled = true;
        }
    }
}
