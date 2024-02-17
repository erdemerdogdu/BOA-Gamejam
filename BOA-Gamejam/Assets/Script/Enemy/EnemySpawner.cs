using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject enemyPrefab;
    public Vector3 spawnPoint;
    [SerializeField]
    private float enemyInterval = 3.5f;
    public Vector3 spawnPoint;
    public float spawnRadius;
    public int MaxCount;


    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(spawnEnemy(enemyInterval, enemyPrefab));
    }

    private IEnumerator spawnEnemy(float interval,  GameObject enemyPrefab)
    {
        if (MaxCount != 1)
        {
            
            yield return new WaitForSeconds(interval);
            GameObject newEnemy = Instantiate(enemyPrefab, new Vector3(Random.Range(20f, -20), Random.Range(20f, -20f), 0f), Quaternion.identity);
            StartCoroutine(spawnEnemy(enemyInterval, enemyPrefab));
            MaxCount--;
        }
    }
}
