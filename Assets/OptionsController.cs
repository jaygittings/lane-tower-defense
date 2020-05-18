using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionsController : MonoBehaviour
{
    [SerializeField] Slider volumeSlilder = null;
    [SerializeField] float defaultVolume = 0.8f;
    [SerializeField] Slider difficultySlider = null;
    [SerializeField] float defaultDifficulty = 3f;

    MusicPlayer musicPlayer = null;

    // Start is called before the first frame update
    void Start()
    {
        volumeSlilder.value = PlayerPrefsController.GetVolume();
        difficultySlider.value = PlayerPrefsController.GetDifficulty();
    }

    // Update is called once per frame
    void Update()
    {
        musicPlayer = FindObjectOfType<MusicPlayer>();
        if(musicPlayer != null)
        {
            musicPlayer.SetVolume(volumeSlilder.value);
        }

    }

    public void SaveAndExit()
    {
        PlayerPrefsController.SetVolume(volumeSlilder.value);
        PlayerPrefsController.SetDifficulty(difficultySlider.value);
        FindObjectOfType<LevelLoader>().LoanMainMenu();
    }

    public void SetDefaults()
    {
        volumeSlilder.value = defaultVolume;
        difficultySlider.value = defaultDifficulty;
    }
}
