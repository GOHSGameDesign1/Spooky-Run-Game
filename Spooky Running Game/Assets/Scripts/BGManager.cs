using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGManager : MonoBehaviour
{
    public GameObject bgPrefab;
    private GameObject currentBG;

    // Start is called before the first frame update
    void Start()
    {
        currentBG = Instantiate(bgPrefab, new Vector3(0.6f, 0, 0), Quaternion.Euler(0, 0, 90)); //Do this step maybe not when the game starts?
    }

    // Update is called once per frame
    void Update()
    {
        if(currentBG.transform.position.y <= 0)
        {
            currentBG = Instantiate(bgPrefab, new Vector3(0.6f, 33.9f, 0), Quaternion.Euler(0,0,90));
        }
    }
}
