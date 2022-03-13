using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    public int coinsCount;
    public Text coinsCountText;


    public static Inventory instance;

    private void Awake()
    {
        // Code d'erreur si jamais ya un bug et qu'il y a 2 inventaire
        if(instance != null)
        {
            Debug.LogWarning("Il y a plus d'une instance de Inventory dans la scène");
        }

        instance = this;
    }

    public void AddCoins(int count)
    {
        coinsCount += count;
        coinsCountText.text = coinsCount.ToString();
    }
}
