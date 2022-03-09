
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    // Le but est de codé le fait que la caméra va etre collé sur le joueur !

    public GameObject player;
    public float timeOffset;
    public Vector3 posOffset;

    private Vector3 velocity;

    void Update()
    {
        transform.position = Vector3.SmoothDamp(transform.position, player.transform.position + posOffset, ref velocity, timeOffset);
    }
}
