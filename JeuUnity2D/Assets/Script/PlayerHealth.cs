using UnityEngine;

public class PlayerHealthy : MonoBehaviour
{

    public int maxHealth = 100;
    public int currentHealth;

    public HealthBar healthBar;

    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

    // Update is called once per frame
    void Update()
    {
        //TEST QUI FAIT QUE LORSQUE L'ON APPUIE SUR UNE TOUCHE ON APPEL LA FONCTION TAKEDAMAGE ET ON PERD 10 PV, MAIS BON CEST SEULEMENT POUR TESTER LA HEALTHBAR
        if (Input.GetKeyDown(KeyCode.H))
        {
            TakeDamage(10);
        }
    }

    void TakeDamage(int damage)
    {
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);
    }
}
