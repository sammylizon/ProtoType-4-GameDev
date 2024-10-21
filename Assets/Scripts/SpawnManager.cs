using System.Collections;
using System.Collections.Generic;
// using System.Numerics;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{

    public GameObject enemyPrefab;
    public GameObject powerPrefab;

    private float spawnPos = 9;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating(nameof(SpawnWave), 2f, 15f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SpawnWave(){
        for(int i = 0; i < 3; i++){
            CreateEnemy();
        }
    }

    public void CreateEnemy(){

        float randomPos = Random.Range(-spawnPos, spawnPos);

        Instantiate(enemyPrefab, new Vector3(randomPos,0,randomPos), enemyPrefab.transform.rotation);
    }

    public void PowerUpPickUp(){

        float randomPos = Random.Range(-spawnPos, spawnPos);
        Instantiate(powerPrefab, new Vector3(randomPos,0,randomPos), enemyPrefab.transform.rotation);

    }
}
