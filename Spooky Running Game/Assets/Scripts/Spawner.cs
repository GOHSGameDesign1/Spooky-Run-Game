using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Spawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public GameObject enemyPrefab2;
    public GameObject enemyPrefab3;
    public GameObject candyPrefab;
    public GameObject rareCandyPrefab;
    GameObject[] spawns;
    GameObject[] spawns2;

    public GameObject dedPanel;

    public static int score;
    public TMP_Text scoreText;
    // Start is called before the first frame update
    void Start()
    {
        spawns = new GameObject[] { candyPrefab, candyPrefab, enemyPrefab, enemyPrefab2, enemyPrefab3 };
        spawns2 = new GameObject[] { candyPrefab, enemyPrefab, enemyPrefab2, enemyPrefab3, rareCandyPrefab };
        score = 0;

        //StartCoroutine(Spawn());
        //StartCoroutine(CountdownToSpawn2());
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = score.ToString();
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

    IEnumerator CountdownToSpawn2()
    {
        yield return new WaitForSeconds(20);
        Debug.Log("starting spawn2");
        StartCoroutine(Spawn2());
    }

    IEnumerator Spawn2()
    {
        while (true) //TODO: Make this instead for as long as the game is running
        {
            yield return new WaitForSeconds(3f);
            int index = Random.Range(0, spawns2.Length);

            Vector3 enemyPos = new Vector3(500 * -1 /** (Random.Range(0, 1) * 2 - 1)*/, 0, 0);

            Instantiate(spawns2[index], enemyPos, Quaternion.identity);
        }
    }

    public void StartGame()
    {
        StartCoroutine(Spawn());
        StartCoroutine(CountdownToSpawn2());
    }

    public void Die()
    {
        StopAllCoroutines();
        dedPanel.SetActive(true);
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
