using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spinner : MonoBehaviour
{
    [SerializeField]
    Vector3 eulerAngles = new Vector3 (0, 0, 0);
    [SerializeField] float rotationSpeed = 1.0f;


    // Update is called once per frame
    void Update()
    {
        transform.Rotate(eulerAngles*rotationSpeed*Time.deltaTime);
    }
}
