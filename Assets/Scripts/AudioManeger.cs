using UnityEngine;

public class AudioManeger : MonoBehaviour
{
    public static AudioManeger instance;
    private AudioSource seAudioSource;
    [SerializeField]
    private AudioClip goalAudioClip;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }
    }
    public void SEPlay()
    {
        if(seAudioSource == null)
        {
            seAudioSource = this.gameObject.AddComponent<AudioSource>();
        }
        seAudioSource.clip = goalAudioClip;
        seAudioSource.Play();
    }
}
