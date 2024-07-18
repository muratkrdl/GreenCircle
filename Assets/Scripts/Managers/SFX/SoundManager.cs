using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager Instancce { get; private set; }

    [SerializeField] SoundLibrary sfxLibrary;
    [SerializeField] AudioSource sfx2DSource;

    void Awake() 
    {
        if(Instancce == null)
        {
            Instancce = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void PlaySound2D(string soundName)
    {
        sfx2DSource.PlayOneShot(sfxLibrary.GetClipFromName(soundName));
    }

}
