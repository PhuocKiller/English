using UnityEngine;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{
    public AudioClip walking, hello, sad,dance, click1, click2,error;
    public AudioClip[] theme;
    public AudioSource musicSource, soundSource, playerSource;
    public float musicVolume, soundVolume;
    [SerializeField] Scrollbar musicScrollBar, soundScrollBar;
    private void Start()
    {
        musicSource.clip = theme[0];
        musicSource.loop = true;
        musicSource.Play();
        musicSource.volume = 0.1f;
    }
    public void PlaySound(AudioClip clip, bool isLoop = false)
    {
        soundSource.clip = clip;
        soundSource.loop = isLoop;
        soundSource.Play();
    }
    public void ButtonClick1()
    {
        PlaySound(click1);
    }
    public void ButtonClick2()
    {
        PlaySound(click2);
    }
    public void ErrorSound()
    {
        PlaySound(error);
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
}
