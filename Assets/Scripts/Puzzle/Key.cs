using UnityEngine;

public class Key : MonoBehaviour
{
    public bool isTaked = false;

    [SerializeField] Animation myAnimation;

    void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.CompareTag(TagManager.PLAYER))
        {
            isTaked = true;
            SoundManager.Instancce.PlaySound2D("GetKey");
            myAnimation.Play();
        }
    }

}
