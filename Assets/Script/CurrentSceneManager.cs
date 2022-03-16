using UnityEngine;

public class CurrentSceneManager : MonoBehaviour
{   
    public int coinsPickedUpInThisSceneCount;
    public Vector3 respawnPoint;


    public static CurrentSceneManager instance;

    private void Awake()
    {
        // Code d'erreur si jamais ya un bug et qu'il y a 2 inventaire
        if (instance != null)
        {
            Debug.LogWarning("Il y a plus d'une instance de CurrentSceneManager dans la scène");
        }

        instance = this;


        respawnPoint = GameObject.FindGameObjectWithTag("Player").transform.position;
    }
  
}
