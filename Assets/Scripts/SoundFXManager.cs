using UnityEngine;

public class SoundFXManager : MonoBehaviour
{
    public static SoundFXManager instance; //singleton instance
    [SerializeField] private AudioSource soundFXObject;

    public void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    public void PlaySoundFX(AudioClip audioClip, Transform spawn, float volume)
    {
        //spawn gameobject
        AudioSource audioSource = Instantiate(soundFXObject, spawn.position, Quaternion.identity);

        //assign audioclip
        audioSource.clip = audioClip;

        //assign volume
        audioSource.volume = volume;

        //play sound
        audioSource.Play();

        //get length of sound FX
        float soundLength = audioSource.clip.length;

        //destroy gameobject after sound FX is done playing
        Destroy(audioSource.gameObject, soundLength);
    }
}
