using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoint : MonoBehaviour
{

    [SerializeField] static public bool isPlacable;
    [SerializeField] public GameObject[] cannonPrefab;
    [SerializeField] static int canonNum;
    [SerializeField] int canon_Num;

    private void Awake()
    {
        isPlacable = true;
    }

    private void Update()
    {
        canon_Num = canonNum;
    }
    private void OnMouseDown()
    {
        if (isPlacable && levelManager.canPlace)
        {
            Debug.Log(transform.name);
            Instantiate(cannonPrefab[canonNum], transform.position, Quaternion.identity);
            isPlacable = false;
            levelManager.cash -= 20;
        }
    }

    static public void SelectCanon(int num)
    {
        switch (num){
            case 0:
                canonNum = 0;
                break;

            case 1:
                canonNum = 1;
                break;  

            case 2: 
                canonNum = 2;   
                break;

        }
    }
}
