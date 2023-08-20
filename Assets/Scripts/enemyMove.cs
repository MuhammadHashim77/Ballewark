using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyMove : MonoBehaviour
{
    [SerializeField] List<Waypoint> path = new List<Waypoint>();
    [SerializeField] float waitTime = 1f, speed;

    public GameObject tile_CornerPiece;
    public GameObject tile_CornerPiece90;
    public GameObject tile_CornerPiece180;
    public GameObject tile_CornerPiece270;
    public GameObject tile_roadStraight;
    public GameObject tile_roadStraight90;

    [SerializeField] private Vector3 lastPosition;
    [SerializeField] private Vector3 beforeLastPosition;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(FollowPath());
    }

    IEnumerator FollowPath()
    {
        foreach (Waypoint waypoint in path)
        {
            yield return new WaitForSeconds(waitTime);

            // Calculate the direction from the last waypoint to the current one
            Vector3 direction = (waypoint.transform.position - lastPosition).normalized;
            GameObject prefabToInstantiate = null;

            if (lastPosition != Vector3.zero) // Ignore the first waypoint
            {
                // Calculate the direction from the waypoint before the last one to the last one
                Vector3 lastDirection = (lastPosition - beforeLastPosition).normalized;

                if (direction == Vector3.forward || direction == Vector3.back)
                {
                    prefabToInstantiate = tile_roadStraight;
                }
                else if (direction == Vector3.left || direction == Vector3.right)
                {
                    prefabToInstantiate = tile_roadStraight90;
                }

                if (lastDirection == Vector3.right && direction == Vector3.forward || lastDirection == Vector3.back && direction == Vector3.left)
                {
                    prefabToInstantiate = tile_CornerPiece270;
                }
                else if (lastDirection == Vector3.left && direction == Vector3.forward || lastDirection == Vector3.back && direction == Vector3.right)
                {
                    prefabToInstantiate = tile_CornerPiece;
                }
                else if (lastDirection == Vector3.left && direction == Vector3.back || lastDirection == Vector3.forward && direction == Vector3.right)
                {
                    prefabToInstantiate = tile_CornerPiece90;
                }
                else if (lastDirection == Vector3.right && direction == Vector3.back || lastDirection == Vector3.forward && direction == Vector3.left)
                {
                    prefabToInstantiate = tile_CornerPiece180;
                }

                // Find the grass tile at the last position and destroy it
                RaycastHit hit;
                if (Physics.Raycast(lastPosition + Vector3.up, Vector3.down, out hit, 1f))
                {
                    Destroy(hit.transform.gameObject);
                }

                // Create a new tile at the position of the last waypoint
                GameObject newTile = Instantiate(prefabToInstantiate, lastPosition, Quaternion.identity);
                newTile.transform.parent = waypoint.transform.parent; // Make sure the tile is parented correctly (e.g., to the same parent as the waypoint)
            }

            // Store the last two positions of the ball
            beforeLastPosition = lastPosition;
            lastPosition = waypoint.transform.position;

            // Move the ball to the current waypoint
            Vector3 startPosition = transform.position;
            Vector3 endPosition = waypoint.transform.position;
            float travelAmount = 0f;

            transform.LookAt(endPosition);

            while (travelAmount < 1f)
            {
                travelAmount += Time.deltaTime * speed;
                transform.position = Vector3.Lerp(startPosition, endPosition, travelAmount);
                yield return new WaitForEndOfFrame();
            }
        }
    }
}
