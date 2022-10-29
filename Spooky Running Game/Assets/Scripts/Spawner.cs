using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public GameObject candyPrefab;
    //float[] positions = new float[] { -4.6f, 0, 4.6f };
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Spawn());
        StartCoroutine(SpawnCandy());
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
            //int itemSpawned = Random.Range(1, 4);

            Vector3 enemyPos = new Vector3(500 * -1 /** (Random.Range(0, 1) * 2 - 1)*/, 0, 0);

            Instantiate(enemyPrefab, enemyPos, Quaternion.Euler(0,0,90));
        }
    }

    IEnumerator SpawnCandy()
    {
        while (true) //TODO: Make this instead for as long as the game is running
        {
            yield return new WaitForSeconds(1f);

            Vector3 enemyPos = new Vector3(500 * -1 /** (Random.Range(0, 1) * 2 - 1)*/, 0, 0);

            Instantiate(candyPrefab, enemyPos, Quaternion.Euler(0, 0, 90));
        }
    }
}
