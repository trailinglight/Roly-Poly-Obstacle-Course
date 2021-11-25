using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rolling : MonoBehaviour
{

    Rigidbody rb;

    [SerializeField]
    float forceSenstivity;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        //Movement();
    }

    private void FixedUpdate()
    {
        forceMovement();
    }


    //method taking axis inputs to move player
    void Movement()
    {
        //variables that grab keyboard movement inputs
        float xValue = Input.GetAxis("Horizontal");
        float zValue = Input.GetAxis("Vertical");
        transform.Translate(new Vector3(xValue, 0, zValue) * Time.deltaTime);
    }

    //method taking axis inputs to apply force to player
    void forceMovement()
    {
        //variables that grab keyboard movement inputs
        float xForce = Input.GetAxis("Horizontal");
        float zForce = Input.GetAxis("Vertical");

        rb.AddForce(new Vector3(xForce, 0, zForce) * forceSenstivity * Time.fixedDeltaTime, ForceMode.Acceleration);

        //transform.Translate(new Vector3(xForce, 0, yForce) * Time.deltaTime);
        
    }
}
