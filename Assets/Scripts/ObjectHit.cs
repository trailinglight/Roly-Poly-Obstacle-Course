using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectHit : MonoBehaviour
{
    float blinkTime = 0.5f;
    MeshRenderer meshRenderer;
    Color baseColor;


    private void Start()
    {
        meshRenderer = GetComponent<MeshRenderer>();
        baseColor = meshRenderer.material.color;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            StartCoroutine(Blink());
        }
        //Debug.Log("Bumped into an obstacle!");
        
    }

    IEnumerator Blink()
    {
        //Color baseColor = GetComponent<MeshRenderer>().material.color;
        meshRenderer.material.color = Color.cyan;

        yield return new WaitForSeconds(blinkTime);

        meshRenderer.material.color = baseColor;

        yield return null;
    }
}
