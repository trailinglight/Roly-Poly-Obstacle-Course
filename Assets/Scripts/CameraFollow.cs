using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField]
    Transform playerTransform;
    [SerializeField]
    float smoothness;

    
    Vector3 intialOffset;
    Vector3 cameraPosition;

    
    enum RelativePosition {InitialPosition, Position1, Position2}
    
    [SerializeField]
    RelativePosition relativePosition;
    [SerializeField]
    Vector3 position1;
    [SerializeField]
    Vector3 position2;


    // Start is called before the first frame update
    void Start()
    {
        intialOffset = transform.position - playerTransform.position;
    }

    private void LateUpdate()
    {
        cameraPosition = playerTransform.position + intialOffset;
        //transform.position = cameraPosition;

        //using lerp
        transform.position = Vector3.Lerp(transform.position, cameraPosition, smoothness * Time.deltaTime);
        transform.LookAt(playerTransform);

        //adding relative positions
        cameraPosition = playerTransform.position + CameraOffset(relativePosition);
        transform.position = Vector3.Lerp(transform.position, cameraPosition, smoothness*Time.deltaTime);
        transform.LookAt(playerTransform);
    }

    Vector3 CameraOffset (RelativePosition relativePos)
    {
        Vector3 currentOffset;

        switch (relativePos)
        {
            case RelativePosition.Position1:
                currentOffset = position1;
                break;

            case RelativePosition.Position2:
                currentOffset = position2;
                break;

            default:
                currentOffset = intialOffset;
                break;
        }

        return currentOffset;
    }


}
