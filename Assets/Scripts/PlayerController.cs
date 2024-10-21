using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public Rigidbody rb;
    public float moveSpeed;
    public float powerUpStrength = 20f;

    public GameObject focalPoint;

    public bool hasPowerUp = false;
    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
        focalPoint = GameObject.Find("FocalPoint");
    }

    // Update is called once per frame
    void Update()
    {
         float input = Input.GetAxis("Vertical");
            rb.AddForce(moveSpeed* input * focalPoint.transform.forward);
        
        
    }

    private void OnTriggerEnter(Collider other){
        if(other.CompareTag("PowerUp")){
            hasPowerUp = true;
            Debug.Log("POWER UP!!! GO GO");
            Destroy(other.gameObject);
            StartCoroutine(PowerUpCountDownRoutine());
        }
    }

    IEnumerator PowerUpCountDownRoutine(){
        yield return new WaitForSeconds(7);
        hasPowerUp = false; 
    }

    public void OnCollisionEnter(Collision other){
        if(other.gameObject.CompareTag("Enemy")&& hasPowerUp){
            Debug.Log($"You collided with {other.gameObject.name} and Power up is : {hasPowerUp}. Kill on!");
            Debug.Log("I am {king}! You got destroyed bitch!");
            Rigidbody enemy = other.gameObject.GetComponent<Rigidbody>();
            Vector3 awayFromPlayer = (other.gameObject.transform.position - transform.position);

            enemy.AddForce(awayFromPlayer * powerUpStrength, ForceMode.Impulse);
            // Destroy(other.gameObject);
        }
    }

}
