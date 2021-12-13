using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Panels : MonoBehaviour
{

    [SerializeField]
    GameObject affected;

    [SerializeField]
    float sinkAmount = 0.05f;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            transform.Translate(0,-sinkAmount,0);
            
            if (!affected.activeSelf)
            {
                affected.SetActive(true);
            }
            affected.SetActive(false);
        }

    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            transform.Translate(0, sinkAmount, 0);
            affected.SetActive(false);
        }
    }
}
