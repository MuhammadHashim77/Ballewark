using UnityEngine;

public class TileSwitcher : MonoBehaviour
{
    public GameObject tile_CornerPiece;
    public GameObject tile_CornerPiece90;
    public GameObject tile_CornerPiece180;
    public GameObject tile_CornerPiece270;
    public GameObject tile_roadStraight;
    public GameObject tile_roadStraight90;

    private Vector3 lastDirection;  // The last direction of the enemy/ball

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))  // Assuming your enemy/ball has the tag "Enemy"
        {
            // Check the direction of the enemy/ball
            Vector3 direction = (other.transform.position - transform.position).normalized;

            GameObject prefabToInstantiate;

            // Check if the enemy/ball is moving diagonally (i.e., both x and z are non-zero)
            if (direction.x != 0 && direction.z != 0)
            {
                prefabToInstantiate = tile_roadStraight90;  // Diagonal sand tile
            }
            else  // The enemy/ball is moving straight
            {
                if (direction != lastDirection)  // The direction has changed
                {
                    // Determine which corner piece to use based on the new direction
                    if (direction == Vector3.right && lastDirection == Vector3.back)
                    {
                        prefabToInstantiate = tile_CornerPiece;
                    }
                    else if (direction == Vector3.right && lastDirection == Vector3.forward)
                    {
                        prefabToInstantiate = tile_CornerPiece90;
                    }
                    else if (direction == Vector3.left && lastDirection == Vector3.forward)
                    {
                        prefabToInstantiate = tile_CornerPiece180;
                    }
                    else if (direction == Vector3.left && lastDirection == Vector3.back)
                    {
                        prefabToInstantiate = tile_CornerPiece270;
                    }
                    else  // Not a corner piece
                    {
                        prefabToInstantiate = tile_roadStraight;  // Straight sand tile
                    }
                }
                else  // The direction has not changed
                {
                    prefabToInstantiate = tile_roadStraight;  // Straight sand tile
                }

                lastDirection = direction;  // Update the last direction
            }

            // Create a new tile at the same position as the current tile (grass tile)
            Instantiate(prefabToInstantiate, transform.position, Quaternion.identity);

            // Delete the grass tile
            Destroy(gameObject);
        }
    }
}
