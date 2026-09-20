using UnityEngine;

public class Trigger : MonoBehaviour
{
    private Rigidbody2D[] rg;
    private Rigidbody2D[] rg2;

    private void Awake()
    {
        GameObject[] enemies2 = GameObject.FindGameObjectsWithTag("Enemy2");
        rg = new Rigidbody2D[enemies2.Length];

        for (int i = 0; i < enemies2.Length; i++)
        {
            rg[i] = enemies2[i].GetComponent<Rigidbody2D>();
        }

        GameObject[] enemies3 = GameObject.FindGameObjectsWithTag("Enemy3");
        rg2 = new Rigidbody2D[enemies3.Length];

        for (int i = 0; i < enemies3.Length; i++)
        {
            rg2[i] = enemies3[i].GetComponent<Rigidbody2D>();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (gameObject.CompareTag("TriggerEnemy2"))
            {
                foreach (Rigidbody2D enemy in rg)
                {
                    enemy.bodyType = RigidbodyType2D.Dynamic;
                }
            }

            if (gameObject.CompareTag("TriggerEnemy3"))
            {
                foreach (Rigidbody2D enemy in rg2)
                {
                    enemy.bodyType = RigidbodyType2D.Dynamic;
                }
            }
        }
    }
}