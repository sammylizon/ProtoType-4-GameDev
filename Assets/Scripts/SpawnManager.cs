using System.Collections;
using System.Collections.Generic;
// using System.Numerics;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{

    public GameObject prefab;

    public float spawnPos = 9;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating(nameof(CreateEnemy), 2f, 10f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CreateEnemy(){

        float randomPos = Random.Range(-spawnPos, spawnPos);

        Instantiate(prefab, new Vector3(randomPos,0,randomPos), prefab.transform.rotation);

    }
}
