using UnityEngine;
using System.Collections;
public class  MeteorSpawner : MonoBehaviour

{
    // Tag of the ground object
    public string groundTag = "Ground";

    // Initial position and rotation
    private Vector3 initialPosition;
    private Quaternion initialRotation;

    // Time to wait before respawning (in seconds)
    public float respawnDelay = 2f;

    // Flag to prevent multiple respawns at the same time
    private bool isRespawning = false;

    void Start()
    {
        // Save the initial position and rotation
        initialPosition = transform.position;
        initialRotation = transform.rotation;
    }

    void OnCollisionEnter(Collision collision)
    {
        // Check if the object collided with the ground and is not already respawning
        if (collision.gameObject.CompareTag(groundTag) && !isRespawning)
        {
            StartCoroutine(RespawnWithDelay());
        }
    }

    IEnumerator RespawnWithDelay()
    {
        isRespawning = true;

        // Wait for the specified delay
        yield return new WaitForSeconds(respawnDelay);

        // Reset the object's position and rotation
        transform.position = initialPosition;
        transform.rotation = initialRotation;

        // Optional: Reset velocity if the object has a Rigidbody
        Rigidbody rb = GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.velocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;
        }

        isRespawning = false;
    }
}