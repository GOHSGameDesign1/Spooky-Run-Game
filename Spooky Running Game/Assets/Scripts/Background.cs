using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.down * Time.deltaTime * 8, Space.World);

        /*if(transform.position.y <= 0)
        {
            Instantiate(bgPrefab, new Vector3(transform.position.x, 34, transform.position.z), Quaternion.identity);
        }*/
    }
}
