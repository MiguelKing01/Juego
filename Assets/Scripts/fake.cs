using Unity.VisualScripting;
using UnityEngine;

public class fake : MonoBehaviour
{

    private Rigidbody2D rg;
    private BoxCollider2D boxColl;

    private void Awake()
    {
        rg = GetComponent<Rigidbody2D>();
        boxColl = GetComponent<BoxCollider2D>();

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            if (gameObject.CompareTag("fake"))
            {
                boxColl.gameObject.SetActive(false);
            }
            else
            {
                rg.bodyType = RigidbodyType2D.Dynamic;
            }

        }
        ;

        // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}