using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public GameObject enemyPrefab2;
    public GameObject enemyPrefab3;
    public GameObject candyPrefab;
    GameObject[] spawns;
    // Start is called before the first frame update
    void Start()
    {
        spawns = new GameObject[] { candyPrefab, candyPrefab, enemyPrefab, enemyPrefab2, enemyPrefab3 };

        StartCoroutine(Spawn());
        //StartCoroutine(SpawnCandy());
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
            int index = Random.Range(0, spawns.Length);

            Vector3 enemyPos = new Vector3(500 * -1 /** (Random.Range(0, 1) * 2 - 1)*/, 0, 0);

            Instantiate(spawns[index], enemyPos, Quaternion.identity);
        }
    }

    IEnumerator SpawnCandy()
    {
        while (true) //TODO: Make this instead for as long as the game is running
        {
            yield return new WaitForSeconds(1f);

            Vector3 enemyPos = new Vector3(500 * -1 /** (Random.Range(0, 1) * 2 - 1)*/, 0, 0);

            Instantiate(candyPrefab, enemyPos, Quaternion.identity);
        }
    }
}
