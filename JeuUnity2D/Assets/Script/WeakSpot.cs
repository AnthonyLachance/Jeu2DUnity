using UnityEngine;

public class WeakSpot : MonoBehaviour
{
    public GameObject obecjToDestroy;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Destroy(obecjToDestroy);
        }
    }


}
