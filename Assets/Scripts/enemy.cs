using UnityEngine;

public class enemy : MonoBehaviour
{
    [SerializeField]
    private Transform pointA;
    [SerializeField]
    private Transform pointB;
    [SerializeField]
    private int speedEnemy;
    [SerializeField]
    private Animator animator;

    private Rigidbody2D rb;
    private Vector3 nextPoint;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        if (animator == null) animator = GetComponent<Animator>();
        nextPoint = pointB.position;
    }

    private void FixedUpdate()
    {
        // Cambio de punto
        if (Mathf.Abs(rb.position.x - nextPoint.x) < 0.1f)
        {
            nextPoint = (nextPoint == pointA.position) ? pointB.position : pointA.position;
        }

        // Dirección hacia el punto destino: -1 o 1
        float dir = Mathf.Sign(nextPoint.x - rb.position.x);

        Vector2 target = new Vector2(nextPoint.x, rb.position.y);
        rb.MovePosition(Vector2.MoveTowards(rb.position, target, speedEnemy * Time.fixedDeltaTime));

        // La animación usa la velocidad configurada, no la calculada
        animator.SetFloat("movement", speedEnemy);

        // Giro del sprite
        transform.localScale = new Vector3(dir, 1, 1);
    }
}