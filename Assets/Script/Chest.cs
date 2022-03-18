using UnityEngine;
using UnityEngine.UI;

public class Chest : MonoBehaviour
{
    private bool isInRange = false;
    private bool isChestOpen = false;
    public Text interactUI;

    public Animator animator;
    public int coinsToAdd;
    public AudioClip soundToPlay;

    private void Update()
    {
        if (isInRange && !isChestOpen && Input.GetKeyDown(KeyCode.E))
        {
            isChestOpen = true;
            interactUI.enabled = false;
            OpenChest();
        }
    }

    private void OpenChest()
    {
        animator.SetTrigger("OpenChest");
        Inventory.instance.AddCoins(coinsToAdd);
        AudioManager.instance.PlayClipAt(soundToPlay, transform.position);
    }

    private void Awake()
    {
        interactUI = GameObject.FindGameObjectWithTag("InteractUI").GetComponent<Text>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && !isChestOpen)
        {
            isInRange = true;
            interactUI.enabled = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            isInRange = false;          
            interactUI.enabled = false;
        }
    }
}
