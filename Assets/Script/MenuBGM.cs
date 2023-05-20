using UnityEngine;

public class MenuBGM : MonoBehaviour
{
    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        PlayBGM();
    }

    public void PlayBGM()
    {
        if(audioSource.isPlaying == false)
        {
            audioSource.Play();
        }
    }

    public void StopBGM()
    {
        if(audioSource.isPlaying)
        {
            audioSource.Stop();
        }
    }
}