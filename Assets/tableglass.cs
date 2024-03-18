using UnityEngine;

public class tableglass : MonoBehaviour
{
    public GameObject brokenGlassPrefab; // Prefab for broken glass shards

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Robot")) // Change "Robot" to the tag of your robot
        {
            BreakGlass();
        }
    }

    private void BreakGlass()
    {
        // Instantiate broken glass prefab at the same position and rotation as the original glass table
        GameObject brokenGlass = Instantiate(brokenGlassPrefab, transform.position, transform.rotation);

        // Iterate through each shard in the broken glass prefab
        foreach (Transform shard in brokenGlass.transform)
        {
            // Add a rigidbody to the shard if it doesn't have one
            Rigidbody shardRb = shard.GetComponent<Rigidbody>();
            if (shardRb == null)
            {
                shardRb = shard.gameObject.AddComponent<Rigidbody>();
            }

            // Apply force to each shard to simulate the shattering effect
            shardRb.AddExplosionForce(500f, transform.position, 1f);
        }

        // Remove the original glass table
        Destroy(gameObject);
    }
}
