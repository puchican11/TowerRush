using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;        // Vitesse de d�placement
    public float jumpForce = 12f;        // Force du saut
    public float gravity = 9.81f;         // Gravit� personnalis�e
    public int maxJumps = 2;            // Nombre de sauts possibles (double saut)

    private CharacterController controller;
    private Camera mainCam;
    private Vector3 moveDirection;
    private int jumpsLeft;              // Compteur de sauts restants

    public static bool isDead = false;

    void Start()
    {
        controller = GetComponent<CharacterController>();
        mainCam = Camera.main;
        jumpsLeft = maxJumps;  // Initialise le nombre de sauts
        isDead = false;
    }

    void Update()
    {
        if(!isDead)
        {
            MovePlayer();
        }
    }

    void MovePlayer()
    {
        float moveX = Input.GetAxis("Horizontal"); // D�placement gauche/droite
        float moveZ = Input.GetAxis("Vertical");

        Vector3 forward = mainCam.transform.forward;
        Vector3 right = mainCam.transform.right;

        forward.y = 0;
        forward.Normalize();
        right.y = 0;
        right.Normalize();

        Vector3 dir = forward * moveZ + right * moveX;
        moveDirection.z = dir.z * moveSpeed;
        moveDirection.x = dir.x * moveSpeed;


        if (controller.isGrounded) // Si le joueur touche le sol
        {
            moveDirection.y = 0f;
            jumpsLeft = maxJumps; // R�initialise les sauts
        }

        if (Input.GetButtonDown("Jump") && jumpsLeft > 0) // Gestion du saut
        {
            moveDirection.y = jumpForce;
            jumpsLeft--; // Diminue le nombre de sauts restants
        }

        moveDirection.y -= gravity * Time.deltaTime; // Applique la gravit�
        controller.Move(moveDirection * Time.deltaTime); // D�place le joueur
    }
}
