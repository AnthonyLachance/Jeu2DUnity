using UnityEngine;

public class WeakSpot : MonoBehaviour
{
    public AudioClip deathSound;
    public GameObject obecjToDestroy;
    private void OnTriggerEnter2D(Collider2D collision)
    {
       
        if (collision.CompareTag("Player"))
        {
            AudioManager.instance.PlayClipAt(deathSound, transform.position);
            Destroy(obecjToDestroy);
        }
    }


}
