using UnityEngine;

public class WaekSpot : MonoBehaviour
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
