using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public QuadraticCurve curve;
    public float speed;

    private float sampleTime;

    // Start is called before the first frame update
    void Start()
    {
        sampleTime = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        if (this.GetComponent<FoodScript>().beingThrown) 
        {
            sampleTime += Time.deltaTime * speed;
            transform.position = curve.ParabolaThrow(sampleTime);
            transform.forward = curve.ParabolaThrow(sampleTime + 0.001f) - transform.position;
        }
    }
}
