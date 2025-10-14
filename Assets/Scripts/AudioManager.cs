using UnityEngine;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{
    public AudioClip walking, hello, sad,dance, click1, click2,error,victory;
    public AudioClip[] theme;
    public AudioSource musicSource, soundSource, playerSource;
    public float musicVolume, soundVolume;
    [SerializeField] Scrollbar musicScrollBar, soundScrollBar;
    private void Start()
    {
      //  PlayThemeSource(0, 0.1f);
    }
    public void PlayGameSound(AudioClip clip, bool isLoop = false)
    {
        soundSource.clip = clip;
        soundSource.loop = isLoop;
        soundSource.Play();
    }
    public void PlayerPlayerSound(AudioClip clip, bool isLoop = false)
    {
        playerSource.clip = clip;
        playerSource.loop = isLoop;
        playerSource.Play();
    }
    public void ButtonClick1()
    {
        PlayGameSound(click1);
    }
    public void ButtonClick2()
    {
        PlayGameSound(click2);
    }
    public void ErrorSound()
    {
        PlayGameSound(error);
    }
    
    public void Walking(bool isWalking)
    {
        playerSource.clip = walking;
        playerSource.loop = true;
        if(isWalking) 
        {
            playerSource.Play();
        }
        else playerSource.Stop();
    }
    public void PlayThemeSource(int indexTheme,float volume, bool isLoop=true)
    {
        musicSource.clip = theme[indexTheme];
        musicSource.Play();
        musicSource.volume = volume;
    }
}
