using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WhaleScript : MonoBehaviour
{
    public GameObject InteractBtn;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (GameObject.Find("Player").GetComponent<MainPlayer>().interactorNearby && GameObject.Find("Player").GetComponent<MainPlayer>().currentInteractor != null)
        {
            if (GameObject.Find("Player").GetComponent<MainPlayer>().currentInteractor.tag == "WhaleInteract") 
            {
                InteractBtn.SetActive(true);
            }
        }
        else
        {
            InteractBtn.SetActive(false);
        }
    }
}
