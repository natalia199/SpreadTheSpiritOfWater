using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodScript : MonoBehaviour
{
    // Start is called before the first frame update
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
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "MainPlayer")
        {
            other.gameObject.GetComponent<MainPlayer>().currentTrash = this.gameObject;
            //other.gameObject.GetComponent<MainPlayer>().trashInHand = true;

            this.gameObject.SetActive(false);
        }
    }
}
