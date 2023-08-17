using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ball : MonoBehaviour
{
    [SerializeField]tileCheck TileSet;
    [SerializeField] float Velocity = 0.5f;
    public bool posF, posL, posB, posR;
    // Start is called before the first frame update
    void Start()
    {
        posF = true;posB = false; posR = false; posL = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (posF)
        {
            transform.position += Time.deltaTime * Velocity * Vector3.forward;
            if (TileSet.cornerPc)
            {
                TileSet.PrefabPicker(0);
            }
        }

        if (posL)
        {
            transform.position += Time.deltaTime * Velocity * Vector3.left;
            if (TileSet.cornerPc)
            {
                TileSet.PrefabPicker(-90);
            }

        }
        if (posR)
        {

            transform.position += Time.deltaTime * Velocity * Vector3.right;
            if (TileSet.cornerPc)
            {
                TileSet.PrefabPicker(-90);
            }
        }
        if (posB)
        {

            transform.position += -1 * Time.deltaTime * Velocity * Vector3.forward;
            if (TileSet.cornerPc)
            {
                TileSet.PrefabPicker(0);
            }


        }
    }



    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("leftCheck"))
        {
            posR = true;

            if (posF)
            {
                TileSet.PrefabPicker(90);
            }
            else
            {
                TileSet.PrefabPicker(1);

            }
            TileSet.cornerPc = false;
            posF = posB = posL = false;

        }
        else if (other.CompareTag("rightCheck"))
        {

            posL = true;
            if (posB)
            {
                TileSet.PrefabPicker(270);
            }
            else
            {
                TileSet.PrefabPicker(180);

            }
            TileSet.cornerPc = false;
            posF = posB = posR = false;

        }
        else if (other.CompareTag("forwardCheck"))
        {
            posF = true;
            if (posL)
            {
                TileSet.PrefabPicker(1);
            }
            else
            {
                TileSet.PrefabPicker(270);

            }
            TileSet.cornerPc = false;
            posL = posB = posR = false;


        }
        else if (other.CompareTag("backCheck"))
        {
            posB = true;

            if (posR)
            {
                TileSet.PrefabPicker(180);
            }
            else
            {
                TileSet.PrefabPicker(90);

            }
            TileSet.cornerPc = false;
            posF = posL = posR = false;

        }
    }
}
