using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    int posNum;
    float[] positions = new float[] {-3.75f, 0.7f, 5.3f};

    // Start is called before the first frame update
    void Start()
    {
        posNum = 1;
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
        Vector2 newPos = new Vector2(transform.position.x, positions[posNum]);

        transform.position = Vector2.Lerp(transform.position, newPos, 7 * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Candy")
        {
            Debug.Log("candy picked up");
        }
    }
}
