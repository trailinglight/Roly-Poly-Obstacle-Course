using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flipper: MonoBehaviour
{

    [SerializeField] float impulseForce = 200.0f;
    [SerializeField] float rotationDegrees = 80.0f;
    [SerializeField] float rotationSpeed = 45.0f;
    [SerializeField] float minRotation = 50.0f;
    [SerializeField] Sensor sensor;
    Vector3 intialRotation;

    enum FlipperType { Left, Right}

    [SerializeField]
    FlipperType flipperType;


    // Start is called before the first frame update
    void Start()
    {
        intialRotation = transform.eulerAngles;   
    }

    // Update is called once per frame
    void Update()
    {
        //if (sensor.sensorTriggered == true)
        //{
        //    int directionality;

        //    switch (flipperType)
        //    {
        //        case FlipperType.Left:
        //            directionality = -1;
        //            break;

        //        case FlipperType.Right:
        //            directionality = 1;
        //            break;

        //        default:
        //            directionality = -1;
        //            break;
        //    }

        //    //sensor.sensorTriggered = false;
        //    transform.Rotate(Vector3.up*directionality*rotationDegrees*rotationSpeed*Time.deltaTime);

        //    if(transform.eulerAngles.y >= rotationDegrees + intialRotation.y)
        //    {
        //        directionality *= -1;
        //    }
        //    else if(transform.eulerAngles.y < intialRotation.y)
        //    {
        //        directionality *= -1;
        //        sensor.sensorTriggered = false;
        //    }
        //}
        float angle = Mathf.PingPong(Time.time*rotationSpeed, rotationDegrees) + minRotation;
        transform.rotation = Quaternion.AngleAxis(-angle, Vector3.up);
    }
}
