using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class PlayerPrefsController
{
    const string VOLUME_KEY = "MasterVolume";
    const string DIFFICULTY_KEY = "DifficultyLevel";
    const float MIN_VOL = 0f;
    const float MAX_VOL = 1f;

    const float VOLUME_DEFAULT = 1f;
    const int DIFFICULTY_DEFAULT = 3;
    const int MAX_DIF = 5;
    const int MIN_DIF = 1;


    public static void SetVolume(float vol)
    {
        vol = vol > MAX_VOL ? MAX_VOL : vol < MIN_VOL ? MIN_VOL : vol;

        PlayerPrefs.SetFloat(VOLUME_KEY, vol);
    }

    public static void SetDifficulty(float dif)
    {
        dif = dif > MAX_DIF ? MAX_DIF : dif < MIN_DIF ? MIN_DIF : dif;

        PlayerPrefs.SetFloat(DIFFICULTY_KEY, dif);
    }

    public static float GetVolume()
    {
        if (!PlayerPrefs.HasKey(VOLUME_KEY))
            return VOLUME_DEFAULT;
        return PlayerPrefs.GetFloat(VOLUME_KEY);
    }

    public static float GetDifficulty()
    {
        if (!PlayerPrefs.HasKey(DIFFICULTY_KEY))
            return DIFFICULTY_DEFAULT;
        return PlayerPrefs.GetFloat(DIFFICULTY_KEY);
    }

    public static void ResetToDefaults()
    {
        PlayerPrefs.SetFloat(VOLUME_KEY, VOLUME_DEFAULT);
        PlayerPrefs.SetFloat(VOLUME_KEY, DIFFICULTY_DEFAULT);
    }
}
