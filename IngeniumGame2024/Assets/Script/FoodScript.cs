using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodScript : MonoBehaviour
{
    public bool beingThrown = false;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void setToPlayerPosition(Vector3 pPos)
    {
        this.transform.position = new Vector3(pPos.x, pPos.y, pPos.z);
        beingThrown = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "MainPlayer" && !other.gameObject.GetComponent<MainPlayer>().trashInHand && GameObject.Find("Player").GetComponent<MainPlayer>().status == "post")
        {
            other.gameObject.GetComponent<MainPlayer>().currentTrash = this.gameObject;
            other.gameObject.GetComponent<MainPlayer>().trashInHand = true;
            //other.gameObject.GetComponent<MainPlayer>().trashInHand = true;

            this.gameObject.SetActive(false);
        }

        /*if (other.tag == "GarbageBin" || other.tag == "RecyclingBin" || other.tag == "CompostBin")
        {
            Destroy(this.gameObject);
        }

        
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
        }*/
    }
}
