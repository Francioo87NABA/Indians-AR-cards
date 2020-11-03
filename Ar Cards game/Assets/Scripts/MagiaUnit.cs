using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagiaUnit : MonoBehaviour
{
    public bool y;
    public bool fuoco;
    public bool acqua;
    public bool vento;


    public string name;

    public int attack;

    public Transform instantiationTransformY;
    public Transform instantiationTransformZ;
    public Transform destinationTransformToZ;
    public Transform destinationTransformToY;

    private int speed = 8;
    
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        if (BattleSystem.Singleton.go)
        {
            if (y)
            {
                transform.position = Vector3.MoveTowards(transform.position, destinationTransformToZ.position, Time.deltaTime * speed);
            }
            else
            {
                transform.position = Vector3.MoveTowards(transform.position, destinationTransformToY.position, Time.deltaTime * speed);
            }
        }
    }

    public void SetUp()
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

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Magia"))
        {
            //qua avvengono le sottrazioni rispetto le varie superefficaciezzietteizzie
        }
    }
}
