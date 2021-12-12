using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scorer : MonoBehaviour
{

    int bumpCounter;

    // Start is called before the first frame update
    void Start()
    {
        bumpCounter = 0;
    }

    private void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.tag != "Ground")
        {
            bumpCounter++;
            Debug.Log("You've bumped into something " + bumpCounter + " times.");
        }

    }
}
