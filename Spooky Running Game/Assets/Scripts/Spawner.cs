using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    float[] positions = new float[] { -4.6f, 0, 4.6f };
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Spawn());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator Spawn()
    {
        while(true) //TODO: Make this instead for as long as the game is running
        {
            yield return new WaitForSeconds(1.5f);
            int posNum = Random.Range(0, 3);

            Vector3 enemyPos = new Vector3(17 * -1 /** (Random.Range(0, 1) * 2 - 1)*/, positions[posNum], 0);

            Instantiate(enemyPrefab, enemyPos, Quaternion.identity);
        }
    }
}
