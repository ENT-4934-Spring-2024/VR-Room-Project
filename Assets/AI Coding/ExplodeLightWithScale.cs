using UnityEngine;

public class ExplodeLightWithScale : MonoBehaviour
{
    public float explosionDelay = 3f; // Time delay before exploding
    public int numberOfParticles = 100; // Number of particles to emit
    public float explosionForce = 10f; // Force of the explosion
    public float explosionRadius = 5f; // Radius of the explosion
    public float lightIntensity = 5f; // Intensity of the flash light
    public float lightDuration = 0.1f; // Duration of the flash light
    public Shader breakApartShader; // Reference to the break apart shader
    public float scaleDuration = 1.5f; // Duration for scaling down the object
    public float scaleDelay = 0.1f; // Delay between scaling each object

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

            // Create flash light
            CreateFlashLight();

            // Scale down the object
            StartCoroutine(ScaleDownObject(gameObject));

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

    private void CreateFlashLight()
    {
        GameObject flashLight = new GameObject("FlashLight");
        flashLight.transform.position = transform.position;
        Light light = flashLight.AddComponent<Light>();
        light.type = LightType.Point;
        light.intensity = lightIntensity;
        Destroy(flashLight, lightDuration);
    }

    private System.Collections.IEnumerator ScaleDownObject(GameObject obj)
    {
        Vector3 initialScale = obj.transform.localScale;
        float elapsedTime = 0f;

        while (elapsedTime < scaleDuration)
        {
            float t = elapsedTime / scaleDuration;
            obj.transform.localScale = Vector3.Lerp(initialScale, Vector3.zero, t);
            elapsedTime += Time.deltaTime;
            yield return new WaitForSeconds(scaleDelay);
        }

        // Ensure the object is scaled down completely
        obj.transform.localScale = Vector3.zero;
    }
}
