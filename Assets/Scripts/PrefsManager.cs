using UnityEngine;

public static class PrefsManager
{
    private const string ACTIVE_HERO = "ActiveHero";

    public static void SaveActiveHero(string currentHero)
    {
        PlayerPrefs.SetString(ACTIVE_HERO, currentHero);
        PlayerPrefs.Save();
    }

    public static string LoadActiveHero()
    {
        return PlayerPrefs.GetString(ACTIVE_HERO);
    }
}
