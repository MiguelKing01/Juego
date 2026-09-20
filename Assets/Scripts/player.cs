using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    private Rigidbody2D rg;
    private InputSystem_Actions action;
    private float moveInput;
    private bool puedeSaltar;
    private SpriteRenderer spriteR;
    private Vector2 lugarIni;
    [SerializeField]
    private int playerSpeed;
    [SerializeField]
    private int playerJump;
    [SerializeField]
    private bool esPlayer2;
    [SerializeField]
    private Player otroPlayer;
    [SerializeField]
    public Animator animator;

    private void Awake()
    {
        rg = GetComponent<Rigidbody2D>();
        spriteR = GetComponent<SpriteRenderer>();
        action = new InputSystem_Actions();
        lugarIni = rg.position;
    }

    private void OnEnable()
    {
        action.Player.Enable();

        if (esPlayer2)
        {
            action.Player.Move2.performed += onMovePerformed;
            action.Player.Move2.canceled += onMoveCanceled;
            action.Player.Jump2.performed += onJump;
        }
        else
        {
            action.Player.Move.performed += onMovePerformed;
            action.Player.Move.canceled += onMoveCanceled;
            action.Player.Jump.performed += onJump;
        }
    }

    private void OnDisable()
    {
        if (esPlayer2)
        {
            action.Player.Move2.performed -= onMovePerformed;
            action.Player.Move2.canceled -= onMoveCanceled;
            action.Player.Jump2.performed -= onJump;
        }
        else
        {
            action.Player.Move.performed -= onMovePerformed;
            action.Player.Move.canceled -= onMoveCanceled;
            action.Player.Jump.performed -= onJump;
        }

        action.Player.Disable();
    }

    private void FixedUpdate()
    {
        rg.linearVelocity = new Vector2(moveInput * playerSpeed, rg.linearVelocity.y);
        animator.SetFloat("movement", rg.linearVelocity.x);
        animator.SetBool("ensuelo", puedeSaltar);

        if (rg.linearVelocity.x < 0)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
        if (rg.linearVelocity.x > 0)
        {
            transform.localScale = new Vector3(1, 1, 1);
        }

        //Vector3 posicion = transform.position;

        //transform.position = new Vector3(rg.linearVelocity.x + posicion.x, posicion.y, posicion.z);

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Plataforma"))
        {
            puedeSaltar = true;
        }

        if (collision.collider.CompareTag("Enemy") || collision.collider.CompareTag("Enemy2") || collision.collider.CompareTag("Enemy3"))
        {
            //cambiarColor();
            //lugarInicial();
            //otroPlayer.lugarInicial();
            //otroPlayer.cambiarColor();
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

        if (collision.collider.CompareTag("Player"))
        {
            if (SceneManager.GetActiveScene().name == "Nivel1")
            {
                SceneManager.LoadScene("Nivel2");
            }
        }
    }

    private void onMovePerformed(InputAction.CallbackContext ctx)
    {
        moveInput = ctx.ReadValue<float>();
    }

    private void onMoveCanceled(InputAction.CallbackContext ctx)
    {
        moveInput = 0;
    }

    private void onJump(InputAction.CallbackContext ctx)
    {
        if (puedeSaltar)
        {
            rg.linearVelocity = new Vector2(
                rg.linearVelocity.x,
                playerJump
            );

            puedeSaltar = false;
        }
    }

    //private void cambiarColor()
    //{
    //    spriteR.color = Color.red;
    //    Invoke(nameof(restaurarColor), 1f);
    //}

    //private void restaurarColor()
    //{
    //    spriteR.color = Color.white;
    //}

    //public void lugarInicial()
    //{
    //    rg.position = lugarIni;
    //    rg.linearVelocity = Vector2.zero;
    //}
}
