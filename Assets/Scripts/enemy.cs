using UnityEngine;

public class enemy : MonoBehaviour
{
    //[SerializeField]
    //private GameObject player;
    [SerializeField]
    private Transform pointA;
    [SerializeField] 
    private Transform pointB;
    private Rigidbody2D rb;
    private Vector3 nextPoint;
    [SerializeField]
    private int speedEnemy;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        nextPoint = pointB.position;
    }

    private void FixedUpdate()
    {
        Vector2 target = new Vector2(nextPoint.x, rb.position.y);
        rb.MovePosition(Vector2.MoveTowards(rb.position, target, speedEnemy * Time.fixedDeltaTime));
    }

    void Update()
    {
        float distance = Mathf.Abs(rb.position.x - nextPoint.x);

        if (distance < 0.1f)
        {
            nextPoint = (nextPoint == pointA.position) ? pointB.position : pointA.position;
        }
    }


}
