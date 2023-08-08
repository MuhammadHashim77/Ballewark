using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingularEnemyMovement : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] float speed = 100f;

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * speed);

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Right")
        {
            transform.localEulerAngles = new Vector3(0,90,0) * Time.deltaTime * 1000f;
        }
        else if(collision.collider.tag == "Left")
        {
            transform.localEulerAngles = new Vector3(0,-90,0) * Time.deltaTime * speed;
        }
    }
}
