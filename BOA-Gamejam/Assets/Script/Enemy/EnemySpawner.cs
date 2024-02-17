using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject enemyPrefab;
    [SerializeField]
    private float enemyInterval = 3.5f;
    public Vector3 spawnPoint;
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
            GameObject newEnemy = Instantiate(enemyPrefab, spawnPoint, Quaternion.identity);
            StartCoroutine(spawnEnemy(enemyInterval, enemyPrefab));
            MaxCount--;
        }
    }
}
