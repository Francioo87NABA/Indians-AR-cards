using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum BattleState { START, YTOTEM, ZTOTEM, YMAGIA, ZMAGIA }

public class BattleSystem : MonoBehaviour
{
    public BattleState State;

    public Image startInstructions;
    public Button fatto;
    
    void Start()
    {
        State = BattleState.START;
        StartCoroutine(SetUpBattle());
    }

    IEnumerator SetUpBattle()
    {
        startInstructions.gameObject.SetActive(true);
        
        yield return new WaitForSeconds(4f);
        
        fatto.gameObject.SetActive(true);
        
    }
    
}
