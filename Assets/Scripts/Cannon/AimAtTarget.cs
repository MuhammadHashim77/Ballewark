using System.Linq;
using UnityEngine;

public class AimAtTarget : MonoBehaviour
{
    [SerializeField] private Transform cannonHead;
    [SerializeField] private Transform cannonBase;
    [SerializeField] GameObject particleShooter;
    private Transform target;
    [SerializeField] private Material cannonColor;


    void Start()
    {
        Destroy(gameObject, 30);
        // Get the color of the cannon.
/*        Renderer cannonRenderer = GetComponentInChildren<Renderer>();
        if (cannonRenderer)
        {
            cannonColor = cannonRenderer.sharedMaterial.color; // Assuming it might be a prefab, use sharedMaterial
        }
*/
    FindMatchingTarget();
    }

    void Update()
    {
        FindMatchingTarget();
        AimWeapon();
    }

    public void FindMatchingTarget()
    {
        ball[] enemyBalls = FindObjectsOfType<ball>();
        // Find the EnemyMover instance in the scene.
/*        ball enemy = FindObjectOfType<ball>();
*/        foreach (var item in enemyBalls.Reverse())
        {
            if (item)
            {
                Renderer childRenderers = item.GetComponentInChildren<Renderer>();
               
                    if (childRenderers.sharedMaterial == cannonColor)
                    {
                        // If we find a child with a matching color, set it as the target.
                        target = childRenderers.transform;
                        particleShooter.SetActive(true);
                        break;
                    }
                
            }
            else
            {
                particleShooter.SetActive(false);
            }
        }
        

    }

    private void AimWeapon()
    {
        if (target != null)
        {
            // Aim cannon head directly at target.
            cannonHead.LookAt(target);

            // Aim cannon base at target but only in the Y-axis.
            Vector3 newRotation = Quaternion.LookRotation(target.position - cannonBase.position).eulerAngles;
/*            cannonHead.rotation = Quaternion.Euler(Quaternion.identity.x, newRotation.y, Quaternion.identity.z);
*/        }
    }

    private void OnDestroy()
    {
        Waypoint.isPlacable = true;
    }
}
