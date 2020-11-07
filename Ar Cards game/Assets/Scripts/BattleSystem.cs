using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.SocialPlatforms;
using Random = System.Random;


public enum BattleState { START, TOTEMS, MAGIE, YLOSEROUND, ZLOSEROUND, END }

public class BattleSystem : MonoBehaviour
{
    public static BattleSystem Singleton;
    
    public BattleState State;

    public int yPoints;
    public int zPoints;
    private int i;
    
    public Image instructionsPanel;
    public Text startText;
    public Text totemText;
    public Text magieText;
    public Text yLoseRound;
    public Text zLoseRound;
    public Button fatto;
    public Button fatto2;

    public bool isThereYTotem;
    public bool isThereZTotem;
    public bool isThereYMagia;
    public bool isThereZMagia;
    public bool go;
    

    private void OnEnable()
    {
        Singleton = this;
    }

    void Start()
    {
        State = BattleState.START;
        StartCoroutine(SetUpBattle());
    }

    private void Update()
    {
        if (yPoints >= 2)
        {
            // y ha vinto
        }

        if (zPoints >= 2)
        {
            // z ha vinto
        }
        
        if (State == BattleState.TOTEMS)
        {
            if (isThereYTotem && isThereZTotem)
            {
                State = BattleState.MAGIE;
                Magie();
            }
        }

        if (State == BattleState.MAGIE)
        {
            if (isThereYMagia && isThereZMagia)
            {
                StartCoroutine(LancioMagie());
            }
        }
    }

    IEnumerator SetUpBattle()
    {
        instructionsPanel.gameObject.SetActive(true);
        startText.gameObject.SetActive(true);
        
        yield return new WaitForSeconds(4f);
        
        fatto.gameObject.SetActive(true);
    }

    #region Totems

    public void Totems()
    {
        State = BattleState.TOTEMS;
        
        startText.gameObject.SetActive(false);
        fatto.gameObject.SetActive(false); //aggiungere un ienumerator per migliorare la transizione da un ins all altro

        totemText.gameObject.SetActive(true);
    }

    public void YTotem()
    {
        isThereYTotem = true; 
    }

    public void ZTotem()
    {
        isThereZTotem = true;
    }
    
    #endregion

    #region Magie

    void Magie()
    {
        totemText.gameObject.SetActive(false);
        instructionsPanel.gameObject.SetActive(true);
        magieText.gameObject.SetActive(true);
    }
    
    public void YMagia()
    {
        isThereYMagia = true;
    }

    public void ZMagia()
    {
        isThereZMagia = true;
    }

    IEnumerator LancioMagie()
    {
        go = true;
        
        yield return new WaitForSeconds(1f);

        isThereYMagia = false;
        isThereZMagia = false;
                
        //go = false;
        
        if (isThereYTotem == false && i == 0)
        {
            zPoints++;
            i++;
            YLoseRound();
            State = BattleState.ZLOSEROUND;
        }

        if (isThereZTotem == false && i == 0)
        {
            yPoints++;
            i++;
            ZLoseRound();
            State = BattleState.YLOSEROUND;
        }
    }
    
    #endregion

    private void YLoseRound()
    {
        magieText.gameObject.SetActive(false);
        yLoseRound.gameObject.SetActive(true);
        fatto2.gameObject.SetActive(true);
        i = 0;
    }
    
    private void ZLoseRound()
    {
        magieText.gameObject.SetActive(false);
        zLoseRound.gameObject.SetActive(true);
        fatto2.gameObject.SetActive(true);
        i = 0;
    }

    public void NextRound()
    {
        yLoseRound.gameObject.SetActive(false);
        zLoseRound.gameObject.SetActive(false);
        instructionsPanel.gameObject.SetActive(false);
        fatto2.gameObject.SetActive(false);
        State = BattleState.TOTEMS;
    }
    
}
