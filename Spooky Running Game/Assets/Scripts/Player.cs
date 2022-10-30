using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    int posNum;
    float[] positions = new float[] {-3.75f, 0.7f, 5.3f};
    int score;
    public float speed;
    public Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        posNum = 1;
        score = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.RightArrow) && posNum != 2)
        {
            posNum++;
        }

        if(Input.GetKeyDown(KeyCode.LeftArrow) && posNum != 0)
        {
            posNum--;
        }

        Move();
    }

    private void Move()
    {
        //Vector2 newPos = Vector2.Lerp(rb.position, new Vector2(rb.position.x, positions[posNum]), Time.deltaTime * speed);
        Vector2 newPos = new Vector2(rb.position.x, positions[posNum]);

        rb.MovePosition(newPos);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Candy")
        {
            score++;
            Debug.Log("candy picked up. Score = " + score);
        }
    }
}
