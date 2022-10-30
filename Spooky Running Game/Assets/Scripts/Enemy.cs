using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Rigidbody2D rb;
    public float speed;

    [SerializeField]
    int direction;

    float[] positions = new float[] { -4.7f, -0.2f, 4.3f };
    

    // Start is called before the first frame update
    void Awake()
    {
        int posNum = Random.Range(0, 3);
        direction = (Random.Range(0, 2) * 2 - 1);
        Vector3 enemyPos = new Vector3(positions[posNum], 17 * direction, 0);

        transform.position = enemyPos;


    }

    // Update is called once per frame
    void Update()
    {
        //rb.MovePosition(transform.position + Vector3.right);
        Move();

    }

    void Move()
    {
        if (direction < 0)
        {
            rb.velocity = Vector2.down * (speed + 3) * direction;
        }
        else
        {
            rb.velocity = Vector2.down * speed * direction;

        }
    }
}
