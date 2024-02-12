using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRB : MonoBehaviour
{
    public float moveSpeed = 5f; // Geschwindigkeit des Spielers
    private Rigidbody rb; // Referenz auf Rigidbody-Komponente des Spielers
    private Camera cam; // Referenz auf Kamera im Spiel

    void Start()
    {
        rb = GetComponent<Rigidbody>(); // Initialisiere Rigidbody-Referenz
        cam = Camera.main; // Initialisiere Kamera-Referenz
    }

    void Update()
    {
        // Bewegung in der Ebene (x-z) relativ zur Kamera
        Vector3 camForward = cam.transform.forward; // Richtungsvektor der Kamera
        Vector3 camRight = cam.transform.right; // Vektor nach rechts von der Kamera
        camForward.y = 0f; // Ignoriere die y-Komponente
        camRight.y = 0f; // Ignoriere die y-Komponente
        camForward = camForward.normalized; // Normalisiere den Vektor
        camRight = camRight.normalized; // Normalisiere den Vektor

        // Bewegungsvektor berechnen
        float horizontalInput = Input.GetAxis("Horizontal"); // Eingabe von der Tastatur
        float verticalInput = Input.GetAxis("Vertical"); // Eingabe von der Tastatur
        Vector3 moveDirection = (camForward * verticalInput + camRight * horizontalInput) * moveSpeed;

        // Anwendung der Bewegung auf den Rigidbody
        Vector3 newVelocity = rb.velocity;
        newVelocity.x = moveDirection.x;
        newVelocity.z = moveDirection.z;
        rb.velocity = newVelocity;
    }
}
