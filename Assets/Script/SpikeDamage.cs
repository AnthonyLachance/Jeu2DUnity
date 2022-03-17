using UnityEngine;

public class SpikeDamage : MonoBehaviour
{
    public int damageOnCollision = 20;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            PlayerHealth playerHealth = collision.transform.GetComponent<PlayerHealth>();
            playerHealth.TakeDamage(damageOnCollision);

        }
    }
}
