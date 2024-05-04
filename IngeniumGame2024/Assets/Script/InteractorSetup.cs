using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractorScript : MonoBehaviour
{
    public bool interacting = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // PLAYER WANTS TO INTERACT
        if (interacting)
        {
            Debug.Log("Whale talks");
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "MainPlayer")
        {
            other.gameObject.GetComponent<MainPlayer>().currentInteractor = this.gameObject;
            other.gameObject.GetComponent<MainPlayer>().interactorNearby = true;
            // Interact Btn Active
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "MainPlayer")
        {
            other.gameObject.GetComponent<MainPlayer>().currentInteractor = null;
            other.gameObject.GetComponent<MainPlayer>().interactorNearby = false;
        }
    }
}
