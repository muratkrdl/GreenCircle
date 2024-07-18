using UnityEngine;

[System.Serializable]
public struct SFX
{
    public string groupID;
    public AudioClip[] audioClips;
}

public class SoundLibrary : MonoBehaviour
{
    public SFX[] soundFXs;

    public AudioClip GetClipFromName(string name)
    {
        foreach (var soundEffect in soundFXs)
        {
            if (soundEffect.groupID == name)
            {
                return soundEffect.audioClips[Random.Range(0, soundEffect.audioClips.Length)];
            }
        }
        return null;
    }

}
