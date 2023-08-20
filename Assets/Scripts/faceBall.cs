using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class faceBall : MonoBehaviour
{
    private Vector3 nextWaypointPosition;

    private void Update()
    {
        if (nextWaypointPosition != Vector3.zero)
        {
            Vector3 moveDirection = nextWaypointPosition - transform.position;
            if (moveDirection != Vector3.zero)
            {
                transform.rotation = Quaternion.LookRotation(moveDirection, Vector3.up);
            }
        }
    }

    public void SetNextWaypoint(Vector3 waypointPosition)
    {
        nextWaypointPosition = waypointPosition;
    }
}
