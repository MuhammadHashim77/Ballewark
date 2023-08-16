using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ball : MonoBehaviour
{
    Rigidbody rb;
    [SerializeField] float Velocity = 0.5f;
    bool posF, posL, posB ,posR;  
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        posF = true;posB = false; posR = false; posL = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (posF)
        {
            transform.position += Time.deltaTime * Velocity * Vector3.forward;
        }
        if (posL)
        {
            transform.position += Time.deltaTime * Velocity * Vector3.left;
        }
        if (posR)
        {
            transform.position += Time.deltaTime * Velocity * Vector3.right;
        }
        if (posB)
        {
            transform.position += -1 * Time.deltaTime * Velocity * Vector3.forward;
        }
    }



    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("leftCheck"))
        {
            posR = true;
            posF = posB = posL = false;
        }
        else if (other.CompareTag("rightCheck"))
        {
            posL = true;
            posF = posB = posR = false;
        }
        else if (other.CompareTag("forwardCheck"))
        {
            posF = true;
            posL = posB = posR = false;
        }
        else if (other.CompareTag("backCheck"))
        {
            posB = true;
            posF = posL = posR = false;
        }
    }
}
