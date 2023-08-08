using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AimAtTarget : MonoBehaviour
{
    [SerializeField] private Transform cannonHead;
    [SerializeField] private Transform cannonBase;

    private Transform target;

    // Start is called before the first frame update
    void Start()
    {
        target = FindObjectOfType<EnemyMover>().transform;
    }

    // Update is called once per frame
    void Update()
    {
        AimWeapon();
    }

    private void AimWeapon()
    {
        cannonHead.LookAt(target);
        cannonBase.LookAt(target);
    }
}
