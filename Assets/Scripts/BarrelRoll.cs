using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrelRoll : MonoBehaviour
{
    enum RollAxis { XAxis, YAxis, ZAxis }
    [SerializeField]
    RollAxis rollAxis;

    enum StartPoint {StartPos, EndPos}
    [SerializeField]
    StartPoint startPoint;


    [SerializeField]
    Vector3 startPos, endPos;
    [SerializeField]
    float rotationForce;

    Vector3 rollVector;
    Rigidbody rigidbody;
    Vector3 directionality;
    bool reverseDirection = false;
    Vector3 launchPos, targetPos, midPos;
    float smoothing;


    [SerializeField]
    float toVelocity = 2.5f, maxVelocity = 5.0f, maxForce = 40.0f, gain = 5.0f;

    // Start is called before the first frame update
    void Start()
    {
        RollSetup();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        RollBarrel();
    }

    void RollSetup()
    {
        switch (rollAxis)
        {
            case RollAxis.XAxis:
                rollVector = Vector3.right;
                break;

            case RollAxis.YAxis:
                rollVector = Vector3.up;
                break;

            case RollAxis.ZAxis:
                rollVector = Vector3.forward;
                break;

            default:
                rollVector = Vector3.zero;
                break;
        }


        switch (startPoint)
        {
            case StartPoint.StartPos:
                transform.position = startPos;
                directionality = (startPos - endPos).normalized;
                launchPos = startPos;
                targetPos = endPos;
                break;
            case StartPoint.EndPos:
                transform.position = endPos;
                directionality = (endPos - startPos).normalized;
                launchPos = endPos;
                targetPos = startPos;
                break;
            default:
                transform.position = startPos;
                directionality = (startPos - endPos).normalized;
                launchPos = startPos;
                targetPos = endPos;
                break;
        }

        //midPos = (startPos - endPos) / 2;

        rigidbody = GetComponent<Rigidbody>();
    }

    void RollBarrel()
    {
        Vector3 distance = targetPos - transform.position;
        distance.y = 0;


        Vector3 targetVelocity = Vector3.ClampMagnitude(toVelocity * distance, maxVelocity);
        Vector3 velocityError = targetVelocity - rigidbody.velocity;
        Vector3 force = Vector3.ClampMagnitude(gain * velocityError, maxForce);

        rigidbody.AddForce(force, ForceMode.Acceleration);

        if (Vector3.Distance(endPos, transform.position) <= 0.1)
        {

            //rigidbody.velocity = Vector3.zero;
            //rigidbody.velocity = -rigidbody.velocity;
            reverseDirection = true;
            launchPos = endPos;
            targetPos = startPos;
            
        }
        else if (Vector3.Distance(transform.position, startPos) <= 0.1)
        {
            //rigidbody.velocity = Vector3.zero;
            //rigidbody.velocity = -rigidbody.velocity;
            reverseDirection = false;
            launchPos = startPos;
            targetPos = endPos;
            //rigidbody.AddRelativeForce(rollVector * rotationForce * Time.fixedDeltaTime, ForceMode.Acceleration);
        }


        //fractionalDistance = ((targetPos - transform.position) / Vector3.Distance(targetPos, launchPos));

        //Debug.Log(((targetPos - transform.position + midPos) / Vector3.Distance(targetPos, launchPos)));
        //Debug.Log(midPos);

        //rigidbody.AddForce((((targetPos - transform.position) + midPos) / Vector3.Distance(targetPos, launchPos)) * rotationForce * Time.fixedDeltaTime, ForceMode.Acceleration);
        //rigidbody.AddForce(((targetPos - transform.position) /  Vector3.Distance(targetPos, launchPos)) * rotationForce * Time.fixedDeltaTime, ForceMode.Acceleration);

        //if (reverseDirection == true)
        //{
        //    rigidbody.AddForce(((targetPos - transform.position) / Vector3.Distance(targetPos, transform.position)) * rotationForce * Time.fixedDeltaTime, ForceMode.Acceleration);
        //    //rigidbody.AddForce(rollVector * -rotationForce * Time.fixedDeltaTime, ForceMode.Acceleration);
        //}
        //else
        //{
        //    //Vector3.Lerp(startPos, endPos, rotationForce * Time.fixedDeltaTime);
        //    rigidbody.AddForce(((targetPos - transform.position) / Vector3.Distance(targetPos, transform.position)) * rotationForce * Time.fixedDeltaTime, ForceMode.Acceleration);
        //    //rigidbody.AddForce(rollVector * rotationForce * Time.fixedDeltaTime, ForceMode.Acceleration);
        //}

        


        //transform.Translate(new Vector3(xForce, 0, yForce) * Time.deltaTime);

    }


}
