using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainPlayer : MonoBehaviour
{
    public Rigidbody rb;
    public float movementSpeed = 1f;

    public Vector3 camPos;

    public Camera cam;
    void Start()
    {
        rb = this.GetComponent<Rigidbody>();
        //camPos = cam.transform.position - transform.position;
    }

    void FixedUpdate()
    {
        // player movement
        float horz = Input.GetAxis("Horizontal");
        float vert = Input.GetAxis("Vertical");

        Vector3 move = new Vector3(horz, 0, vert);
        rb.MovePosition(transform.position + move * Time.deltaTime * movementSpeed);

        if (move == Vector3.zero)
        {
            return;
        }

        Quaternion tragRot = Quaternion.LookRotation(move);
        tragRot = Quaternion.RotateTowards(
            transform.rotation,
            tragRot,
            360 * Time.fixedDeltaTime);

        rb.MoveRotation(tragRot);

        // camera
        cam.transform.position = new Vector3(this.transform.position.x, this.transform.position.y + camPos.y, this.transform.position.z - camPos.z);
    }
}
