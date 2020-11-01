﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour
{
    public bool y;
    
    public string name;

    public int maxHealth;
    public int currentHealth;
    int damage;

    public Transform instantiationTransformY;
    public Transform instantiationTransformZ;
    
    private void Start()
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
           // damage = other.GetComponent()
        }
    }
}
