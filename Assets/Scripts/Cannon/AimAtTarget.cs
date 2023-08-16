using UnityEngine;

public class AimAtTarget : MonoBehaviour
{
    [SerializeField] private Transform cannonHead;
    [SerializeField] private Transform cannonBase;

    private Transform target;
    private Color cannonColor;

    void Start()
    {
        // Get the color of the cannon.
        Renderer cannonRenderer = GetComponentInChildren<Renderer>();
        if (cannonRenderer)
        {
            cannonColor = cannonRenderer.sharedMaterial.color; // Assuming it might be a prefab, use sharedMaterial
        }

        FindMatchingTarget();
    }

    void Update()
    {
        AimWeapon();
    }

    private void FindMatchingTarget()
    {
        // Find the EnemyMover instance in the scene.
        EnemyMover enemy = FindObjectOfType<EnemyMover>();
        if (enemy)
        {
            Renderer[] childRenderers = enemy.GetComponentsInChildren<Renderer>();
            foreach (Renderer r in childRenderers)
            {
                if (r.sharedMaterial.color == cannonColor)
                {
                    // If we find a child with a matching color, set it as the target.
                    target = r.transform;
                    break;
                }
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
            cannonBase.rotation = Quaternion.Euler(0, newRotation.y, 0);
        }
    }
}
