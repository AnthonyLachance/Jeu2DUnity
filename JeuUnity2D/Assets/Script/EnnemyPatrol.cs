using UnityEngine;

public class EnnemyPatrol : MonoBehaviour
{
    public float speed;
    public Transform[] waypoints;

    public SpriteRenderer graphics;
    private Transform target;
    private int destPoint = 0;


    // LE CODE EXPLIQUÉ PAR MOI-MEME :  EN GROS, DANS LA FONCTION START, ON SET LA TARGET DE L'ENNEMI EN DISANT : VA AU POINT 1 (DANS LA LISTE WAYPOINT) WAYPOINT[0]
    // ENSUITE DANS UPDATE ON DÉFINI LA DIRECTION DE L'ENNEMI.
    // PAR LA SUITE ON DIT DES QUE L'ENNEMI EST PRESQUE (0.3F) ARRIVÉ A SA TARGET, COMMENCE A CALCULER C'EST QUOI LA PROCHAINE TARGET
    // DONC AVEC UN MODULO ON CHOISI LE NEXT WAYPOINT DANS LA LISTE. ON UTILISE LE MODULE CAR ON VEUX QUE L'ENNEMI PATROUILLE DONC FASSE DES ALLEZ-RETOUR
    void Start()
    {
        target = waypoints[0];
    }

    
    void Update()
    {
        Vector3 dir = target.position - transform.position;
        transform.Translate(dir.normalized * speed * Time.deltaTime, Space.World);

        // Si l'ennemi est quasiment arrivé a sa destination
        if(Vector3.Distance(transform.position, target.position) < 0.3f)
        {
            destPoint = (destPoint + 1) % waypoints.Length;
            target = waypoints[destPoint];
            // Seul ajout pour que le serpent regarde du coté ou il va. (avec la definition de la variable "public SpriteRenderer graphics;")
            graphics.flipX = !graphics.flipX;
        }
    }
}
