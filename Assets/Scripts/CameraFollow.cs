using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField]
    Transform playerTransform;

    [SerializeField]
    float yDistance, zDistance, sensitivity;


    // Start is called before the first frame update
    void Start()
    {
        transform.position = playerTransform.position - new Vector3(-yDistance, zDistance);
        transform.LookAt(playerTransform.transform);
    }

    // Update is called once per frame
    void Update()
    {
        
        transform.position = Vector3.Lerp(transform.position, playerTransform.position - new Vector3(0, -yDistance, zDistance),sensitivity);
        transform.LookAt(playerTransform.transform);
    }
}
