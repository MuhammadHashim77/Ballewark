using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnerScript : MonoBehaviour
{
    [SerializeField] GameObject[] enemyBalls;
    int randomSelect;
    static public float rate = 5;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnRandom",1f,rate);
    }

    // Update is called once per frame
    void Update()
    {
        randomSelect = Random.Range(0, enemyBalls.Length);

    }

    void SpawnRandom()
    {
        Instantiate(enemyBalls[randomSelect],gameObject.transform,true);
    }

}
