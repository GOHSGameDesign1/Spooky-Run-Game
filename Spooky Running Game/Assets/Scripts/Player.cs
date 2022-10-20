using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    int posNum;
    float[] positions = new float[] {-4, 0, 4};

    // Start is called before the first frame update
    void Start()
    {
        posNum = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow) && posNum != 2)
        {
            posNum++;
        }

        if(Input.GetKeyDown(KeyCode.DownArrow) && posNum != 0)
        {
            posNum--;
        }

        Move();
    }

    private void Move()
    {
        Vector2 newPos = new Vector2(transform.position.x, positions[posNum]);

        transform.position = Vector2.Lerp(transform.position, newPos, 5 * Time.deltaTime);
    }
}
