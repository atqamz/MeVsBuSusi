using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance { get; private set; }

    [SerializeField] private AudioSource musicSource;
    [SerializeField] private AudioSource sfxSource;
    [SerializeField] private AudioClip[] musicClips;
    [SerializeField] private AudioClip[] sfxClips;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void PlayMusic(AudioClip _audioClip)
    {
        musicSource.clip = _audioClip;
        musicSource.Play();
    }

    public void PlayMusic(int _index)
    {
        musicSource.clip = musicClips[_index];
        musicSource.Play();
    }

    public void PlaySFX(AudioClip _audioClip)
    {
        sfxSource.PlayOneShot(_audioClip);
    }

    public void PlaySFX(int _index)
    {
        sfxSource.PlayOneShot(sfxClips[_index]);
    }

    // get is SFX is playing
    public bool IsSFXPlaying()
    {
        if (sfxSource.isPlaying)
        {
            return true;
        }

        return false;
    }

    public void StopMusic()
    {
        musicSource.Stop();
    }

    public void StopSFX()
    {
        sfxSource.Stop();
    }

    public void PauseMusic()
    {
        musicSource.Pause();
    }

    public void PauseSFX()
    {
        sfxSource.Pause();
    }

    public void UnPauseMusic()
    {
        musicSource.UnPause();
    }

    public void UnPauseSFX()
    {
        sfxSource.UnPause();
    }

    public float GetMusicVolume()
    {
        return musicSource.volume;
    }

    public float GetSFXVolume()
    {
        return sfxSource.volume;
    }

    public void SetMusicVolume(float _volume)
    {
        musicSource.volume = _volume;
    }

    public void SetSFXVolume(float _volume)
    {
        sfxSource.volume = _volume;
    }

    public void SetMusicMute(bool _mute)
    {
        musicSource.mute = _mute;
    }

    public void SetSFXMute(bool _mute)
    {
        sfxSource.mute = _mute;
    }
}
