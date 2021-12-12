using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bumper: MonoBehaviour
{
    [SerializeField] float impulseForce = 10.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        Vector3 forceDirection = (collision.transform.position - transform.position).normalized;

        collision.rigidbody.AddForce(forceDirection * impulseForce, ForceMode.Impulse);
        //collision.rigidbody.AddForce( 9.0f, ForceMode.Impulse);
    }
}
