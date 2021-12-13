using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sensor : MonoBehaviour
{
    new BoxCollider collider;
    //public bool sensorTriggered = false;

    public bool sensorTriggered { get;  set; }
    
    // Start is called before the first frame update
    void Start()
    {
        collider = GetComponent<BoxCollider>();
        collider.enabled = true;
    }

    //detect player trigger
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            collider.enabled = false;

            sensorTriggered = true;
        }
    }

}
