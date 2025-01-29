using UnityEngine;
using UnityEngine.Rendering;

public class AudioPlayer : MonoBehaviour
{
    [SerializeField]
    AudioSource audioSource;

    public void playSound(AudioClip clip)
    {
        audioSource.clip = clip;
        audioSource.Play();
    }
}
