using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyX : MonoBehaviour
{
    // public float speed;
    private Rigidbody enemyRb;
    private GameObject playerGoal;

    private float speed;

    // Start is called before the first frame update
    void Start()
    {
        enemyRb = GetComponent<Rigidbody>();
        playerGoal = GameObject.Find("Player Goal");
    }

    // Update is called once per frame
    void Update()
    {
        
        speed = GameObject.Find("Spawn Manager").GetComponent<SpawnManagerX>().enemySpeed;
        Debug.Log(speed);

        // Set enemy direction towards player goal and move there
        //Spawn Manager Script increasing speed per round
        Vector3 lookDirection = (playerGoal.transform.position - transform.position).normalized;
        Debug.Log(lookDirection);
        enemyRb.AddForce(lookDirection * speed * Time.deltaTime);

    }

    private void OnCollisionEnter(Collision other)
    {
        // If enemy collides with either goal, destroy it
        if (other.gameObject.name == "Enemy Goal")
        {
            Destroy(gameObject);
        } 
        else if (other.gameObject.name == "Player Goal")
        {
            Destroy(gameObject);
        }

    }

}
