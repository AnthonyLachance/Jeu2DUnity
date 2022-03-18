using UnityEngine;
using UnityEngine.UI;

public class ShopManager : MonoBehaviour
{
    public Animator animator;
    public Text pnjNameText;

    public static ShopManager instance;
    public GameObject sellButton;
    public Transform sellButtonsParent;


    private void Awake()
    {
        // Code d'erreur si jamais ya un bug et qu'il y a 2 inventaire
        if (instance != null)
        {
            Debug.LogWarning("Il y a plus d'une instance de ShopManager dans la scène");
        }

        instance = this;
    }

    public void OpenShop(Item[] items, string pnjName)
    {
        pnjNameText.text = pnjName;
        UpdateItemToSell(items);
        animator.SetBool("isOpen", true);
    }

    void UpdateItemToSell(Item[] items)
    {
       

        // Instancie un bouton pour chaque item à vendre et le configure
        for (int i = 0; i < items.Length ; i++)
        {
            Instantiate(sellButton, sellButtonsParent);
        }
    }


    public void CloseShop()
    {
        animator.SetBool("isOpen", false);
    }
}
