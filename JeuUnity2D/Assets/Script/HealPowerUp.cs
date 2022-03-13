using UnityEngine;

public class HealPowerUp : MonoBehaviour
{
    public int healthPoints;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (PlayerHealth.instance.currentHealth < PlayerHealth.instance.maxHealth)
            {
                //Rendre de la vie au joueur
                PlayerHealth.instance.HealPlayer(healthPoints);

                Destroy(gameObject);
            }
        }
    }
}

