using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Candy : MonoBehaviour
{
    public Rigidbody2D rb;
    public float speed;

    float[] positions = new float[] { -4.7f, -0.2f, 4.3f };
    // Start is called before the first frame update
    void Start()
    {
        int posNum = Random.Range(0, 3);
        Vector3 enemyPos = new Vector3(positions[posNum], 17, 0);

        transform.position = enemyPos;
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = Vector2.up * speed * -1;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            Destroy(gameObject);
        }
    }
}
