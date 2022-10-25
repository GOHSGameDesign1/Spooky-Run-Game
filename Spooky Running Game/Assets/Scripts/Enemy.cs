using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Rigidbody2D rb;
    public float speed;

    [SerializeField]
    int direction;

    float[] positions = new float[] { -3.75f, 0.7f, 5.3f };
    

    // Start is called before the first frame update
    void Awake()
    {
        int posNum = Random.Range(0, 3);
        direction = (Random.Range(0, 2) * 2 - 1);
        Vector3 enemyPos = new Vector3(17 * -1 * direction, positions[posNum], 0);

        transform.position = enemyPos;


    }

    // Update is called once per frame
    void Update()
    {
        //rb.MovePosition(transform.position + Vector3.right);
        rb.velocity = Vector2.right * speed * direction;
        rb.rotation = 90 * direction;
    }
}
