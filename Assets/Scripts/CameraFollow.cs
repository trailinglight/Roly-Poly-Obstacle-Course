using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField]
    Transform playerTransform;

    [SerializeField]
    float yDistance, zDistance, sensitivity;

    [SerializeField]
    float lerpDuration;

    float timeElapsed;

    Vector3 offset;

    // Start is called before the first frame update
    void Start()
    {
        timeElapsed = 0;
        offset = transform.position - playerTransform.position;
        //transform.position = playerTransform.position - new Vector3(-yDistance, zDistance);
        transform.LookAt(playerTransform.transform);
    }

    // Update is called once per frame
    void Update()
    {
        

        //if (timeElapsed < lerpDuration)
        //{
        //    transform.position = Vector3.Lerp(transform.position, playerTransform.position + offset, timeElapsed / lerpDuration);
        //    transform.LookAt(playerTransform.transform);
        //    timeElapsed += Time.deltaTime;
        //}
        //else
        //{
        //    transform.position = playerTransform.position +offset;
        //    transform.LookAt(playerTransform.transform);
        //}


       // transform.position = Vector3.Lerp(transform.position, playerTransform.position - new Vector3(0, -yDistance, zDistance), sensitivity);
       // transform.LookAt(playerTransform.transform);
    }

    private void LateUpdate()
    {
        
        //transform.position = playerTransform.position + offset;
        if(timeElapsed < lerpDuration)
        {
            transform.position = Vector3.Lerp(transform.position, playerTransform.position + offset, timeElapsed / lerpDuration);
            timeElapsed += Time.deltaTime;
        }
        else
        {
            transform.position = playerTransform.position + offset;
            timeElapsed = 0;
        }

        transform.LookAt(playerTransform.transform);
    }

}
