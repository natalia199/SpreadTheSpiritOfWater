using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuadraticCurve : MonoBehaviour
{

    public Transform A;
    public Transform B;
    public Transform Control;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public Vector3 ParabolaThrow(float t)
    {
        Vector3 ac = Vector3.Lerp(GameObject.Find("Player").transform.position, GameObject.Find("Player").GetComponent<MainPlayer>().currentBin.transform.GetChild(2).position, t);
        Vector3 cb = Vector3.Lerp(GameObject.Find("Player").GetComponent<MainPlayer>().currentBin.transform.GetChild(2).position, GameObject.Find("Player").GetComponent<MainPlayer>().currentBin.transform.GetChild(1).position, t);

        return Vector3.Lerp(ac, cb, t);
    }
}
