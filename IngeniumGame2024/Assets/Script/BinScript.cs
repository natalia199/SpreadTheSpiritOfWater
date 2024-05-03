using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BinScript : MonoBehaviour
{
    public bool interacting = false;

    public string binType;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (GameObject.Find("Player").GetComponent<MainPlayer>().currentTrash == null)
        {
            // set sign inactive
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "MainPlayer" && other.GetComponent<MainPlayer>().currentTrash != null)
        {
            other.gameObject.GetComponent<MainPlayer>().currentBin = this.gameObject;

            // Set sign active            
        }

        // garbage throw result
        if (other.tag == binType)
        {
            //correct
        }
        else
        {
            //wrong, spit back
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "MainPlayer")
        {
            other.gameObject.GetComponent<MainPlayer>().currentBin = null;
            // Set sign inactive
        }
    }
}
