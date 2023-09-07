using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{    
    public static AudioManager instance; // Singleton pattern

    public AudioSource backgroundMusic; // AudioSource za pozadinsku muziku
    public AudioSource soundEffect; // AudioSource za zvucne efekte

    private void Awake()
    {
        // Postavite singleton
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }

        DontDestroyOnLoad(gameObject); // Cuvajte AudioManager izmedju scenarija
    }

    // Funkcija za reprodukciju zvucnog efekta
    public void PlaySound(AudioClip clip)
    {
        soundEffect.clip = clip;
        soundEffect.Play();
    }

    // Funkcija za promenu pozadinske muzike
    public void ChangeBackgroundMusic(AudioClip newClip)
    {
        backgroundMusic.Stop();
        backgroundMusic.clip = newClip;
        backgroundMusic.Play();
    }

    // Dodatne funkcionalnosti za podesavanje jacine zvuka, mutiranje, itd.
    // Mozete ih dodati prema potrebi.

    // Na primer, funkcija za podesavanje glasnoce zvucnih efekata:
    public void SetSoundVolume(float volume)
    {
        soundEffect.volume = volume;
    }
}


