using System.Collections;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] int maxHP = 5;
    [SerializeField] GameObject cannon; // Reference to the cannon.

    private Color cannonColor;
    private Renderer enemyRenderer;

    int currHP = 0;

    void Start()
    {
        currHP = maxHP;

        if (cannon)
        {
            // Get the Renderer component from the first child (or the cannon itself) that has a Renderer component.
            Renderer cannonChildRenderer = cannon.GetComponentInChildren<Renderer>();
            if (cannonChildRenderer)
            {
                cannonColor = cannonChildRenderer.sharedMaterial.color; // Use sharedMaterial for prefabs
            }
        }

        enemyRenderer = GetComponentInChildren<Renderer>(); // Assuming the enemy's Renderer is on a child

        // Additional safety checks
        if (!enemyRenderer)
        {
            Debug.LogError("Enemy Renderer not found on: " + gameObject.name);
        }

        if (cannon && !cannon.GetComponentInChildren<Renderer>())
        {
            Debug.LogError("Cannon Renderer not found on: " + cannon.name);
        }
    }


    private void OnParticleCollision(GameObject other)
    {
        Debug.Log("Particle collided with: " + gameObject.name);
        ProcessHit();
    }

    private void ProcessHit()
    {
        if (enemyRenderer && enemyRenderer.material && AreColorsSimilar(enemyRenderer.material.color, cannonColor))
        {
            currHP--;

            if (currHP <= 0)
            {
                Destroy(gameObject);
            }
        }
        else
        {
            if (!enemyRenderer)
            {
                Debug.LogError("Enemy renderer is missing!");
                return;
            }

            if (!enemyRenderer.material)
            {
                Debug.LogError("Material on the enemy renderer is missing!");
                return;
            }

            Debug.Log("Colors are NOT similar for: " + gameObject.name +
                      ". Enemy Color: " + enemyRenderer.material.color.ToString() +
                      ", Cannon Color: " + cannonColor.ToString());
        }
    }


    // Compare two colors with a certain tolerance.
    private bool AreColorsSimilar(Color color1, Color color2, float tolerance = 0.05f)
    {
        float diffR = Mathf.Abs(color1.r - color2.r);
        float diffG = Mathf.Abs(color1.g - color2.g);
        float diffB = Mathf.Abs(color1.b - color2.b);

        return diffR <= tolerance && diffG <= tolerance && diffB <= tolerance;
    }
}
