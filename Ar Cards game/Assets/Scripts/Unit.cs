using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour
{
    public bool y;

    //private int maxHealth = 100;
    public int currentHealth;
    private int i;

    public Transform instantiationTransformY;
    public Transform instantiationTransformZ;

    private MagiaUnit magiaValues;

    public bool debug;
    
    private void Start()
    {
      
    }

    private void Update()
    {
        if (currentHealth <= 0)
        {
            if (y)
            {
                BattleSystem.Singleton.isThereYTotem = false;
            }
            else
            {
                BattleSystem.Singleton.isThereZTotem = false;
            }
            
            Destroy(gameObject);
        }

        if (debug)
        {
            SetUp();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Magia"))
        {
            magiaValues = other.GetComponent<MagiaUnit>();
            
            if (y && magiaValues.y == false || y == false && magiaValues.y)
            {
                currentHealth = currentHealth - magiaValues.attack;
            
                Destroy(other.gameObject);
            }

            if (y && magiaValues.y || y == false && magiaValues.y == false)
            {
                if (magiaValues.speciale)
                {
                    if (magiaValues.terra && i == 0)
                    {
                        currentHealth = currentHealth + 10;
                        i++;
                    }
                    else if (magiaValues.fuoco && i == 0)
                    {
                        currentHealth = currentHealth - 5;
                        i++;
                    }
                    else if (magiaValues.acqua && i == 0)
                    {
                        currentHealth = currentHealth + 5;
                        i++;
                    }
                }

                if (magiaValues.speciale && i == 0)
                {
                    currentHealth = currentHealth + 25;
                    i++;
                }
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
    
    
}
