using UnityEngine;
using System.Collections;

public class PlayerHealth : MonoBehaviour
{

    public int maxHealth = 100;
    public int currentHealth;
    public float invincibilityFlashDelay = 0.2f;

    public float invincibleTimeAfterHit = 2.5f;
    public bool isInvincible = false;
    public SpriteRenderer graphics;
    public HealthBar healthBar;

    public static PlayerHealth instance;

    private void Awake()
    {
        // Code d'erreur si jamais ya un bug et qu'il y a 2 inventaire
        if (instance != null)
        {
            Debug.LogWarning("Il y a plus d'une instance de PlayerHealth dans la scène");
        }

        instance = this;
    }

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

    public void TakeDamage(int damage)
    {
        if (!isInvincible) { 
            currentHealth -= damage;
            healthBar.SetHealth(currentHealth);

            //Vérifie si le joueur est mort
            if(currentHealth <= 0)
            {
                Die();
                return;
            }
            
            isInvincible = true;
            StartCoroutine(InvincibilityFlash());
            StartCoroutine(HandleInvincibilityDelay());
        }
    }

    public void HealPlayer(int amount)
    {

        if ((currentHealth + amount) > maxHealth)
        {
            currentHealth = maxHealth;
        }
        else
        {
            currentHealth += amount;   
        }
            healthBar.SetHealth(currentHealth);
    }

    public void Die()
    {
        //Bloquer les mouvements du perso

        //Jouer l'animation d'élimination

        //empecher les interactions physique avec les autres object de la scene

    }

    public IEnumerator InvincibilityFlash()
    {
        while (isInvincible)
        {
            graphics.color = new Color(1f, 1f, 1f, 0f);
            yield return new WaitForSeconds(invincibilityFlashDelay);
            graphics.color = new Color(1f, 1f, 1f, 1f);
            yield return new WaitForSeconds(invincibilityFlashDelay);
        }
    }

    public IEnumerator HandleInvincibilityDelay()
    {
        yield return new WaitForSeconds(invincibleTimeAfterHit);
        isInvincible = false;
    }


    
}
