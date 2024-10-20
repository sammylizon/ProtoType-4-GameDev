using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public Rigidbody rb;
    public float moveSpeed;

    public GameObject focalPoint;
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
}
