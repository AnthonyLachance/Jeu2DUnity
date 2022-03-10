using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed;
    private bool isJumping;
    public float jumpForce;
    private bool isGrounded;
    
    public Rigidbody2D rb;
    public Transform groundCheck;
    public float groundCheckRadius;
    public LayerMask collisionLayers;



    private Vector3 velocity = Vector3.zero;
    public Animator animator;
    public SpriteRenderer spriteRenderer;

    private float horizontalMovement;

    void Update()
    {
        

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            isJumping = true;
        }


        Flip(rb.velocity.x);

        float characterVelocity = Mathf.Abs(rb.velocity.x);
        animator.SetFloat("Speed", characterVelocity);
    }

    void FixedUpdate()
    {

        // On défini une variable qui est le mouvement horizontale : Sur l'axe horizontale * Vitesse * Temps
        horizontalMovement = Input.GetAxis("Horizontal") * moveSpeed * Time.deltaTime;

        // Créer une boite de colision (entre les 2 indice) qui envoie true en cas de colision
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, collisionLayers);


        MovePlayer(horizontalMovement);

    }

    
    void MovePlayer(float _horizontalMovement)
    {
        Vector3 targetVelocity = new Vector2(_horizontalMovement, rb.velocity.y);
        rb.velocity = Vector3.SmoothDamp(rb.velocity, targetVelocity, ref velocity, .05f);

        if(isJumping == true)
        {
            rb.AddForce(new Vector2(0f, jumpForce));
            isJumping = false;
        }
    }


    // Fonction pour implementer le player qui court vers la gauche aussi
    void Flip(float _velocity)
    {
        if (_velocity > 0.1f)
        {
            spriteRenderer.flipX = false;
        }
        else if (_velocity < -0.1f)
        {
            spriteRenderer.flipX = true;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(groundCheck.position, groundCheckRadius);
    }

}
