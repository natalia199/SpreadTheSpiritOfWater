using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BinScript : MonoBehaviour
{
    public bool interacting = false;

    public string binType;

    public GameObject garbageIndicator;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (GameObject.Find("Player").GetComponent<MainPlayer>().currentTrash == null)
        {
            garbageIndicator.SetActive(false);
        }
    }


    private void OnCollisionEnter(Collision other)
    {
        // garbage throw result
        if (other.gameObject.tag == binType)
        {
            Debug.Log("Correct bin");
            other.gameObject.GetComponent<FoodScript>().beingThrown = false;
            Destroy(other.gameObject);
        }
        else
        {
            Debug.Log("Wrong bin");
            other.gameObject.GetComponent<FoodScript>().beingThrown = false;

            Destroy(other.gameObject);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "MainPlayer" && other.GetComponent<MainPlayer>().currentTrash != null)
        {
            other.gameObject.GetComponent<MainPlayer>().currentBin = this.gameObject;

            garbageIndicator.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "MainPlayer")
        {
            other.gameObject.GetComponent<MainPlayer>().currentBin = null;

            garbageIndicator.SetActive(false);
        }
    }
}
