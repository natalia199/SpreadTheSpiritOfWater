using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainPlayer : MonoBehaviour
{
    public Rigidbody rb;
    public float movementSpeed = 1f;
    public float rotationSpeed;

    public Vector3 camPos;

    public Camera cam;

    public bool interactorNearby = false;
    public bool interacting = false;
    public GameObject currentInteractor = null;

    public string status;
    // pre, talk, post

    public bool trashInHand = false;
    public GameObject currentTrash = null;
    public GameObject currentBin = null;

    public RuntimeAnimatorController anim;

    public float curveSpeed;

    void Start()
    {
        rb = this.GetComponent<Rigidbody>();
        cam.transform.position = new Vector3(this.transform.position.x + camPos.x, this.transform.position.y + camPos.y, this.transform.position.z - camPos.z);
    }

    void FixedUpdate()
    {
        if (!interacting)
        {          
            // Try to interact
            if (Input.GetKey(KeyCode.E) && interactorNearby && status == "pre")
            {
                // ZOOM IN CAMERA
                currentInteractor.GetComponent<InteractorScript>().interacting = true;
                interacting = true;

                GameObject.Find("Main Camera").GetComponent<Animator>().enabled = true;
                status = "talk";
            }

            // Throw trash
            if (Input.GetKeyDown(KeyCode.Space) && currentBin != null && trashInHand && status == "post")
            {
                currentTrash.GetComponent<FoodScript>().setToPlayerPosition(this.transform.position);
                currentTrash.SetActive(true);
                //currentTrash.GetComponent<SphereCollider>().isTrigger = false;
                //currentTrash.GetComponent<FoodScript>().ParabolaThrow(curveSpeed);

                trashInHand = false;

                Debug.Log("THREW TRASH");
            }

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
        else
        {
            // Clean up trash
            if (Input.GetKeyDown(KeyCode.Space) && status == "talk")
            {
                // ZOOM OUT CAMERA
                GameObject.Find("Main Camera").GetComponent<Animator>().runtimeAnimatorController = anim;
                interacting = false;

                status = "post";
            }
        }
    }
}
