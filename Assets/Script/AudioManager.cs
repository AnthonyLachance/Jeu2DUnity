using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{

    public AudioClip[] playlist;
    public AudioSource audioSource;
    private int musicIndex = 0;
    public AudioMixerGroup soundEffectMixer;

    public static AudioManager instance;

    private void Awake()
    {
        // Code d'erreur si jamais ya un bug et qu'il y a 2 inventaire
        if (instance != null)
        {
            Debug.LogWarning("Il y a plus d'une instance de AudioManager dans la scène");
        }

        instance = this;
    }

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

    public AudioSource PlayClipAt(AudioClip clip, Vector3 pos)
    {
        GameObject tempGO = new GameObject("TempAudio");
        tempGO.transform.position = pos;
        AudioSource audioSource = tempGO.AddComponent<AudioSource>();
        audioSource.clip = clip;
        audioSource.outputAudioMixerGroup = soundEffectMixer;
        audioSource.Play();
        Destroy(tempGO, clip.length);
        return audioSource;
    }
}
