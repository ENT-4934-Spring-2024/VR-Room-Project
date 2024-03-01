using UnityEngine;

public class ExplodeAfterTime : MonoBehaviour
{
    public float explosionDelay = 3f; // Time delay before exploding
    public int numberOfParticles = 100; // Number of particles to emit
    public float explosionForce = 10f; // Force of the explosion
    public float explosionRadius = 5f; // Radius of the explosion
    public Shader breakApartShader; // Reference to the break apart shader

    private bool hasExploded = false;

    private void Start()
    {
        // Start the countdown timer
        Invoke("Explode", explosionDelay);
    }

    private void Explode()
    {
        if (!hasExploded)
        {
            // Change material shader to break apart shader
            Renderer renderer = GetComponent<Renderer>();
            if (renderer != null && breakApartShader != null)
            {
                Material[] materials = renderer.materials;
                foreach (Material material in materials)
                {
                    material.shader = breakApartShader;
                }
            }

            // Emit particles
            EmitParticles();

            // Destroy the object
            Destroy(gameObject);

            hasExploded = true;
        }
    }

    private void EmitParticles()
    {
        for (int i = 0; i < numberOfParticles; i++)
        {
            Vector3 randomDirection = Random.insideUnitSphere;
            GameObject particle = GameObject.CreatePrimitive(PrimitiveType.Sphere);
            Rigidbody rb = particle.AddComponent<Rigidbody>();
            rb.velocity = randomDirection * explosionForce;
            particle.transform.position = transform.position;
            Destroy(particle, 2f);
        }
    }
}
