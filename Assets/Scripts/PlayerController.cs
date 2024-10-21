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

    public GameObject powerUpIndicator;
    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
        focalPoint = GameObject.Find("FocalPoint");
    }

    // Update is called once per frame
    void Update()
    {
        //Get vertical input and add force in forward direction
        float input = Input.GetAxis("Vertical");
        rb.AddForce(moveSpeed* input * focalPoint.transform.forward);

        //place the indicator at player position with offset
        powerUpIndicator.transform.position = transform.position - new Vector3(0,0.5f,0);
        
        
    }

    private void OnTriggerEnter(Collider other){

        //if player collides with power up the apply power
        if(other.CompareTag("PowerUp")){
            hasPowerUp = true;
            Debug.Log("POWER UP!!! GO GO");
            Destroy(other.gameObject);
            StartCoroutine(PowerUpCountDownRoutine());
            powerUpIndicator.SetActive(true);
        }
    }

    //Interface used to set up Timer with Coroutine(outside of Update or start)
    IEnumerator PowerUpCountDownRoutine(){
        yield return new WaitForSeconds(7);
        hasPowerUp = false; 
        powerUpIndicator.SetActive(false);
    }

    public void OnCollisionEnter(Collision other){
        //if player has power up and collides with enemy then use buffs
        if(other.gameObject.CompareTag("Enemy")&& hasPowerUp)
        {
            //Get enemy reference and direction to send them away from player. 
            Rigidbody enemy = other.gameObject.GetComponent<Rigidbody>();
            Vector3 awayFromPlayer = (other.gameObject.transform.position - transform.position);

            //Buff sends enemy flying away from player
            enemy.AddForce(awayFromPlayer * powerUpStrength, ForceMode.Impulse);
        }
    }

}
