using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ball : MonoBehaviour
{
    [SerializeField]tileCheck TileSet;
    [SerializeField] float Velocity = 7f;
    [SerializeField]private bool posF, posL, posB, posR;
    // Start is called before the first frame update
    void Awake()
    {
        posF = true;posB = false; posR = false; posL = false;
    }

    // Update is called once per frame
    void Update()
    {
        BallDirection();
    }

    void BallDirection ()
    {
        if (posF)
        {
            transform.position += Time.deltaTime * Velocity * Vector3.forward;
            if (TileSet.cornerPc)
            {
/*                TileSet.PrefabPicker(0);
*/            }
        }

        if (posL)
        {
            transform.position += Time.deltaTime * Velocity * Vector3.left;
            if (TileSet.cornerPc)
            {
/*                TileSet.PrefabPicker(-90);
*/            }

        }
        if (posR)
        {

            transform.position += Time.deltaTime * Velocity * Vector3.right;
            if (TileSet.cornerPc)
            {
/*                TileSet.PrefabPicker(-90);
*/            }
        }
        if (posB)
        {

            transform.position += -1 * Time.deltaTime * Velocity * Vector3.forward;
            if (TileSet.cornerPc)
            {
/*                TileSet.PrefabPicker(0);
*/            }
        }
        TileSet.PrefabPicker(-1);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Despawner"))
        {
            levelManager.HealthDecrease();
            Destroy(gameObject);
        }

        if (other.CompareTag("canon")) 
        {
            Destroy(other.gameObject);
        }

        if (other.CompareTag("leftCheck"))
        {
            posR = true;
/*
            if (posF)
            {
                TileSet.PrefabPicker(90);
            }
            else
            {
                TileSet.PrefabPicker(1);

            }
*/            posF = posB = posL = false;
            TileSet.cornerPc = false;

        }
        else if (other.CompareTag("rightCheck"))
        {

            posL = true;
/*            if (posB)
            {
                TileSet.PrefabPicker(270);
            }
            else
            {
                TileSet.PrefabPicker(180);

            }
*/            posF = posB = posR = false;
            TileSet.cornerPc = false;

        }
        else if (other.CompareTag("forwardCheck"))
        {
            posF = true;
/*            if (posL)
            {
                TileSet.PrefabPicker(1);
            }
            else
            {
                TileSet.PrefabPicker(270);

            }
*/            posL = posB = posR = false;
            TileSet.cornerPc = false;


        }
        else if (other.CompareTag("backCheck"))
        {
            posB = true;

/*            if (posR)
            {
                TileSet.PrefabPicker(180);
            }
            else
            {
                TileSet.PrefabPicker(90);

            }
*/            posF = posL = posR = false;
            TileSet.cornerPc = false;

        }
    }
}
