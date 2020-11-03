using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour
{
    public bool y;
    
    public string name;
    
    public int currentHealth;

    public Transform instantiationTransformY;
    public Transform instantiationTransformZ;

    private MagiaUnit magiaValues;
    
    private void Start()
    {
      
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Magia"))
        {
            magiaValues = other.GetComponent<MagiaUnit>();

            currentHealth = currentHealth - magiaValues.attack;
            
            Destroy(other);
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
}
