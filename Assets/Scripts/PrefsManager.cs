using UnityEngine;

public static class PrefsManager
{
    private const string ACTIVE_HERO = "ActiveHero";
    private const string MONEY_AMOUNT = "MoneyAmount";
    private const string BOUGHT_HEROES = "BoughtHeroes";

    public static void SaveActiveHero(string currentHero)
    {
        PlayerPrefs.SetString(ACTIVE_HERO, currentHero);
        PlayerPrefs.Save();
    }

    public static string LoadActiveHero()
    {
        return PlayerPrefs.GetString(ACTIVE_HERO);
    }

    public static void SaveMoney(int amount)
    {
        PlayerPrefs.SetInt(MONEY_AMOUNT, amount);
        PlayerPrefs.Save();
    }

    public static int LoadMoney()
    {
        return PlayerPrefs.GetInt(MONEY_AMOUNT);
    }

    public static void SaveBoughtHero(string heroName)
    {
        var alreadyBought = LoadBoughtHeroes();
        
        PlayerPrefs.SetString(BOUGHT_HEROES, alreadyBought + " " + heroName);
        PlayerPrefs.Save();
    }

    public static string LoadBoughtHeroes()
    {
        return PlayerPrefs.GetString(BOUGHT_HEROES);
    }
}
