using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagiaUnit : MonoBehaviour
{
    public bool y;
    
    public string name;

    public int attack;

    public Transform instantiationTransformY;
    public Transform instantiationTransformZ;
    public Transform destinationTransformToZ;
    public Transform destinationTransformToY;

    public int speed;
    
    // Start is called before the first frame update
    void Start()
    {
        if (y)
        {
            transform.position = instantiationTransformY.position;
        }
        else
        {
            transform.position = instantiationTransformZ.position;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (BattleSystem.Singleton.go)
        {
            if (y)
            {
                //destinationTransformToY
            }
            else
            {
                
            }
        }
    }
}
