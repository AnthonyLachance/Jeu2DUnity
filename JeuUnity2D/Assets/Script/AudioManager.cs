using UnityEngine;

public class AudioManager : MonoBehaviour
{

    public AudioClip[] playlist;
    public AudioSource audioSource;
    private int musicIndex = 0;
    
    void Start()
    {
        audioSource.clip = playlist[0];
        audioSource.Play();
    }
 
    void Update()
    {
        if (!audioSource.isPlaying)
        {
            //  Passer a la prochaine musique
            PlayNextSong();

        }
    }

    //  Passer a la prochaine musique
    void PlayNextSong()
    {
        musicIndex = (musicIndex +1) % playlist.Length;
        audioSource.clip = playlist[musicIndex];
        audioSource.Play();
    }
}
