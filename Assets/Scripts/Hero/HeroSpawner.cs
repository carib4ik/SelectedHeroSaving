using Hero;
using UnityEngine;

public class HeroSpawner : MonoBehaviour
{
    private void Start()
    {
        var heroesManager = FindObjectOfType<HeroesManager>();

        Instantiate(heroesManager.GetSavedHeroController().gameObject, transform);
        
        heroesManager.gameObject.SetActive(false);
    }
}
