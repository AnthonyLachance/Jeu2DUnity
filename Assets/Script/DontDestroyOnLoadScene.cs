using UnityEngine;
using UnityEngine.SceneManagement;

public class DontDestroyOnLoadScene : MonoBehaviour
{
    public GameObject[] objects;

    public static DontDestroyOnLoadScene instance;

    private void Awake()
    {
        // Code d'erreur si jamais ya un bug et qu'il y a 2 inventaire
        if (instance != null)
        {
            Debug.LogWarning("Il y a plus d'une instance de DontDestroyOnLoadScene dans la scène");
        }

        instance = this;

        foreach (var element in objects)
        {
            DontDestroyOnLoad(element);
        }
    }


    public void RemoveFromOnDestroyOnLoad()
    {
        foreach (var element in objects)
        {
            SceneManager.MoveGameObjectToScene(element, SceneManager.GetActiveScene());
        }
    }

}
