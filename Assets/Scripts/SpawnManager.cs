using System.Collections;
using System.Collections.Generic;
// using System.Numerics;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{

    public GameObject enemyPrefab;
    public GameObject powerPrefab;

    private float spawnPos = 9;

    private int enemyCount; 

    private int enemyWaves = 3;
    // Start is called before the first frame update
    void Start()
    {
        //Spawn 3 enemies to begin the game 
        SpawnWave(3);

        //Power up comes every 20 seconds
        InvokeRepeating(nameof(PowerUpPickUp), 15f, 20f);

    }

    // Update is called once per frame
    void Update()
    {
        EnemyControlUnit();
    }

    public void SpawnWave(int enemiesToSpawn){
        //Use for loop to spawn a wave of enemies
        for(int i = 0; i < enemiesToSpawn; i++){
            CreateEnemy();
        }
    }

    public void CreateEnemy(){

        //Spawn enemy in random position on level
        float randomPos = Random.Range(-spawnPos, spawnPos);

        Instantiate(enemyPrefab, new Vector3(randomPos,0,randomPos), enemyPrefab.transform.rotation);
    }

    public void PowerUpPickUp(){
        //Spawn power up in random position on level

        float randomPos = Random.Range(-spawnPos, spawnPos);
        Instantiate(powerPrefab, new Vector3(randomPos,0,randomPos), enemyPrefab.transform.rotation);

    }

    public void EnemyControlUnit(){
        //Check the number of enemies alive
        enemyCount = FindObjectsOfType<Enemy>().Length;

        //If no enemies are alive then...
        //...add 1 to the enemy wave
        //...Spawn a wave with the amount of enemies in the current wave
        if(enemyCount == 0){
            enemyWaves+=1;
            SpawnWave(enemyWaves);
        }
    }

    
}
