using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.SocialPlatforms;
using Random = System.Random;


public enum BattleState { START, TOTEMS, YMAGIA, ZMAGIA }

public class BattleSystem : MonoBehaviour
{
    public BattleState State;

    public Image instructionsPanel;
    public Text startText;
    public Text totemText;
    public Text magieText;
    public Button fatto;

    public bool isThereYTotem;
    public bool isThereZTotem;
    
    

    void Start()
    {
        State = BattleState.START;
        StartCoroutine(SetUpBattle());
    }

    private void Update()
    {
        if (State != BattleState.TOTEMS) return;
        if (isThereYTotem && isThereZTotem)
        {
            State = BattleState.YMAGIA;
            Magie();
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
        isThereYTotem = true; //fallo chiamare dai marker del totem
    }

    public void ZTotem()
    {
        isThereZTotem = true;
    }
    
    #endregion

    void Magie()
    {
        totemText.gameObject.SetActive(false);
        
        
        magieText.text = "gioca una magia" + " risponde";

    }
    
}
