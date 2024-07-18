using UnityEngine;

public class KeyDoor : MonoBehaviour
{
    [SerializeField] Key key;

    [SerializeField] Animation myAnimation;

    void OnCollisionEnter2D(Collision2D other) 
    {
        if(other.gameObject.CompareTag(TagManager.PLAYER))
        {
            if(key.isTaked)
            {
                SoundManager.Instancce.PlaySound2D("OpenDoor");
                myAnimation.Play();
            }
        }    
    }

}
