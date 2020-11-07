using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagiaUnit : MonoBehaviour
{
    public bool y;
    public bool fuoco;
    public bool acqua;
    public bool aria;
    public bool terra;
    public bool nullify;
    public bool efficace;
    public bool speciale;
    public bool cura;

    public int attack;
    private int i;
    
    private float speed = 0.3f;

    public Transform instantiationTransformY;
    public Transform instantiationTransformZ;
    public Transform destinationTransformToZ;
    public Transform destinationTransformToY;

    private MagiaUnit otherMagia;

    public bool debug;
    public bool goDebug;
    
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        if (BattleSystem.Singleton.go || goDebug)
        {
            if (y)
            {
                print("doesndoencde");
                
                transform.position = Vector3.MoveTowards(transform.position, destinationTransformToZ.position, Time.deltaTime * speed);
            }
            else
            {
                print("dde");
                
                transform.position = Vector3.MoveTowards(transform.position, destinationTransformToY.position, Time.deltaTime * speed);
            }
        }
        
        if (debug)
        {
            SetUp();
        }
    }

    public void SetUp()
    {
        if (i == 0)
        {
            i++;
            
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

    #region MyRegion

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Magia"))
        {
            otherMagia = gameObject.GetComponent<MagiaUnit>();

            if (fuoco)
            {
                if (otherMagia.acqua)
                    attack = attack / 2;
            }
            else if (acqua)
            {
                if (otherMagia.terra)
                    attack = attack / 2;
            }
            else if (aria)
            {
                if (otherMagia.fuoco)
                    attack = attack / 2;
            }
            else if (terra)
            {
                if (otherMagia.terra)
                    attack = attack / 2;
            }

            if (otherMagia.nullify)
            {
                if (fuoco)
                {
                    if (otherMagia.acqua)
                        Destroy(gameObject);
                    
                }
                else if (acqua)
                {
                    if (otherMagia.terra)
                        Destroy(gameObject);
                }
                else if (aria)
                {
                    if (otherMagia.fuoco)
                        Destroy(gameObject);
                }
                else if (terra)
                {
                    if (otherMagia.terra)
                        Destroy(gameObject);
                }
            }

            if (efficace)
            {
                if (fuoco)
                {
                    if (otherMagia.acqua)
                        attack = attack * 2;
                }
                else if (acqua)
                {
                    if (otherMagia.terra)
                        attack = attack * 2;
                }
                else if (aria)
                {
                    if (otherMagia.fuoco)
                        attack = attack * 2;
                }
                else if (terra)
                {
                    if (otherMagia.terra)
                        attack = attack * 2;
                }
            }

            if (speciale)
            {
                if (fuoco)
                {
                    attack = attack + 5;
                }
                else if (acqua)
                {
                    attack = attack - 5;
                }
                else if (aria)
                {
                    attack = attack + 10;
                }
            }

            if (cura)
            {
                Destroy(gameObject);
            }
        }
    }
    
    #endregion
}
