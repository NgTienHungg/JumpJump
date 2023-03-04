using UnityEngine;
using System.Collections.Generic;

public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance { get; private set; }

    public bool MusicOn
    {
        get { return PlayerPrefs.GetInt("MusicOn") == 1; }
        set { PlayerPrefs.SetInt("MusicOn", value == true ? 1 : 0); }
    }

    public bool SoundOn
    {
        get { return PlayerPrefs.GetInt("SoundOn") == 1; }
        set { PlayerPrefs.SetInt("SoundOn", value == true ? 1 : 0); }
    }

    public bool VibrationOn
    {
        get { return PlayerPrefs.GetInt("VibrationOn") == 1; }
        set { PlayerPrefs.SetInt("VibrationOn", value == true ? 1 : 0); }
    }

    [SerializeField] private List<Sound> _listMusic;
    [SerializeField] private List<Sound> _listSound;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);

        DefaultSettings();
        PrepareMusicAndSound();
    }

    private void DefaultSettings()
    {
        if (!PlayerPrefs.HasKey("MusicOn"))
        {
            MusicOn = true;
            SoundOn = true;
            VibrationOn = true;
        }
    }

    private void PrepareMusicAndSound()
    {
        foreach (var sound in _listSound)
        {
            sound.Source = gameObject.AddComponent<AudioSource>();
            sound.Source.clip = sound.Clip;
            sound.Source.loop = sound.Loop;
            sound.Source.volume = sound.Volume;
        }

        foreach (var sound in _listMusic)
        {
            sound.Source = gameObject.AddComponent<AudioSource>();
            sound.Source.clip = sound.Clip;
            sound.Source.loop = sound.Loop;
            sound.Source.volume = sound.Volume;
        }
    }

    public void PlayMusic(string musicName)
    {
        if (MusicOn)
        {
            Sound music = _listMusic.Find(music => music.Source.clip.name == musicName);

            if (music == null)
                Debug.LogWarning("Can't find music with name: " + musicName);
            else
                music.Source.Play();
        }
    }

    public void StopAllMusic()
    {
        foreach (var music in _listMusic)
        {
            music.Source.Stop();
        }
    }

    public void PlaySound(string soundName)
    {
        if (SoundOn)
        {
            Sound sound = _listSound.Find(sound => sound.Source.clip.name == soundName);

            if (sound == null)
                Debug.LogWarning("Can't find sound with name: " + soundName);
            else
                sound.Source.Play();
        }
    }

    //public void Vibrate(HapticTypes type)
    //{
    //    if (VibrationOn)
    //    {
    //        MMVibrationManager.Haptic(type);
    //    }
    //}
}