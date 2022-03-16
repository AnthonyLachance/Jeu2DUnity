using UnityEngine;

public class HealPowerUp : MonoBehaviour
{
    public int healthPoints;
    public AudioClip healthSound;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (PlayerHealth.instance.currentHealth < PlayerHealth.instance.maxHealth)
            {
                AudioManager.instance.PlayClipAt(healthSound, transform.position);
                //Rendre de la vie au joueur
                PlayerHealth.instance.HealPlayer(healthPoints);

                Destroy(gameObject);
            }
        }
    }
}

