using UnityEngine;

public class glass : MonoBehaviour
{
    public GameObject brokenGlassPrefab; // Prefab for broken glass shards

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player")) // Change "Player" to the tag of the object that can break the glass
        {
            BreakGlass();
            Debug.Log("test");
        }
    }

    private void BreakGlass()
    {
        // Instantiate broken glass prefab at the same position and rotation as the original glass
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

        // Remove the original glass wall
        Destroy(gameObject);
    }
}
