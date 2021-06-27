using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockingFurniture : MonoBehaviour
{

    public BuoyancyEffector2D effector;
    public bool isRocking;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("RockObject", 0.0f, 0.5f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void RockObject()
    {
        isRocking = !isRocking;
        if (isRocking)
        {
            effector.flowAngle = 120f;
        }
        else
        {
            effector.flowAngle = 60f;
        }

    }
}
