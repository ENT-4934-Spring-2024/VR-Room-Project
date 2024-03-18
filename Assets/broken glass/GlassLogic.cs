using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlassLogic : MonoBehaviour
{
    public string playerTag = "Player";
    public Material glassMaterial; // Assign your glass material in the Inspector

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag(playerTag))
        {
            ShatterGlass();
        }
    }

    private void ShatterGlass()
    {
        if (glassMaterial != null)
        {
            // Enable shattering effect by setting the "_Break" property in the material
            glassMaterial.SetFloat("_Break", 1.0f);

            // Optional: You may want to disable the collider or hide the glass mesh here
            // e.g., GetComponent<Collider>().enabled = false;
            // e.g., GetComponent<MeshRenderer>().enabled = false;

            // You might want to reset the "_Break" property after some time for future interactions
            // Invoke("ResetGlass", 2.0f);
        }
    }

    private void ResetGlass()
    {
        if (glassMaterial != null)
        {
            // Reset the "_Break" property to 0.0 to disable the shattering effect
            glassMaterial.SetFloat("_Break", 0.0f);

            // Optional: Re-enable the collider or show the glass mesh here
            // e.g., GetComponent<Collider>().enabled = true;
            // e.g., GetComponent<MeshRenderer>().enabled = true;
        }
    }
}
