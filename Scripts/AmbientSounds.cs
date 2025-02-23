using UnityEngine;

public class AmbientSounds : MonoBehaviour
{
    public AudioClip[] musicPlaylist; // Tableau de musiques
    private AudioSource audioSource; // L'AudioSource pour jouer les musiques

    void Start()
    {
        audioSource = GetComponent<AudioSource>(); // R�cup�re le composant AudioSource
        if (musicPlaylist.Length > 0)
        {
            PlayRandomTrack(); // Joue une musique d�s le d�part
        }
    }

    private void Update()
    {
        if (!audioSource.isPlaying) PlayRandomTrack();
    }

    void PlayRandomTrack()
    {
        int randomIndex = Random.Range(0, musicPlaylist.Length); // Choisit un indice al�atoire
        audioSource.clip = musicPlaylist[randomIndex]; // Assigne le clip audio � l'AudioSource
        audioSource.Play(); // Joue la musique
    }
}
