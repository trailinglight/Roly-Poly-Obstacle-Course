using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bumper: MonoBehaviour
{
    [SerializeField] float impulseForce = 10.0f;
    [SerializeField] bool blink = false;
    [SerializeField] float intialDelay = 2.0f, delay = 2.0f, blinkTime = 2.0f;
    MeshRenderer meshRenderer;
    CapsuleCollider capsuleCollider;
    
    float nextDelay;



    private void Start()
    {
        nextDelay = intialDelay;
        meshRenderer = GetComponent<MeshRenderer>();
        capsuleCollider = GetComponent<CapsuleCollider>();
    }

    private void Update()
    {
       // Debug.Log(Time.time);
        //Debug.Log(nextDelay);
        if (blink == true)
        {
            if (Time.time >= nextDelay && meshRenderer.enabled)
            {
                nextDelay += (blinkTime + delay);
                meshRenderer.enabled = false;
                capsuleCollider.enabled = false;
                
                //StartCoroutine(Blink());

            } else if(Time.time > nextDelay - delay)
            {
                meshRenderer.enabled = true;
                capsuleCollider.enabled = true;
            }

        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        Vector3 forceDirection = (collision.transform.position - transform.position).normalized;

        collision.rigidbody.AddForce(forceDirection * impulseForce, ForceMode.Impulse);
    }

    IEnumerator Blink()
    {

        yield return new WaitForSeconds(blinkTime);

        meshRenderer.enabled = true;
        capsuleCollider.enabled = true;
        //nextDelay += Time.time + delay;


        yield return null;

    }
}
