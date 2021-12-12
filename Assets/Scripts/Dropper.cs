using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dropper : MonoBehaviour
{
    //BoxCollider
    [SerializeField]
    float minWaitTime = 0.0f, maxWaitTime = 1.5f;

    [SerializeField] Sensor sensor;

    MeshRenderer meshRenderer;
    new Rigidbody rigidbody;

    bool triggered;

    // Start is called before the first frame update
    void Start()
    {
        meshRenderer = GetComponent<MeshRenderer>();
        rigidbody = GetComponent<Rigidbody>();

        meshRenderer.enabled = false;
        rigidbody.useGravity = false;
    }

    // Update is called once per frame
    void Update()
    {
        float waitTime;

        if (sensor.sensorTriggered == true)
        {
            
            //sensor.sensorTriggered = false;
            waitTime = Random.Range(minWaitTime, maxWaitTime);

            StartCoroutine(Drop(waitTime));

        }

    }

    IEnumerator Drop(float waitTime)
    {

        yield return new WaitForSeconds(waitTime);
        meshRenderer.enabled = true;
        rigidbody.useGravity = true;

        yield return null;
    }
}
