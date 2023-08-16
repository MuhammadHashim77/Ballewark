using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoint : MonoBehaviour
{
    [SerializeField] private bool isPlacable;
    [SerializeField] private GameObject cannonPrefab;

    private void OnMouseDown()
    {
        if (isPlacable)
        {
            Debug.Log(transform.name);
            Instantiate(cannonPrefab, transform.position, Quaternion.identity);
            isPlacable = false;
        }
    }
}
