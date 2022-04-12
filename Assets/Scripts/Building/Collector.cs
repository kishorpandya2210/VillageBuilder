using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Collector : Building, IInteractable
{
    
    [SerializeField] private float rate;
    [SerializeField] private int rateAmount;
    [SerializeField] private GameConst.COST_TYPE amountType;
    [SerializeField] private Resources amount;
    [SerializeField] private string startTime;
    [SerializeField] private float currTime;
    [SerializeField] private GameObject collection;
    [SerializeField] private string index;

    void Collect()
    {
        if(amountType == GameConst.COST_TYPE.GOLD)
                    PlayerStats.Gold.Curr += amount.Curr;
                
                amount.Curr = 0;
                currTime = 0;

                PlayerPrefs.SetString("Collect", DateTime.Now.Ticks.ToString());
                startTime = DateTime.Now.Ticks.ToString();
    }

    void IInteractable.Action()
    {
        // Debug.Log(gameObject.name + ": has been collected");
        // throw new NotImplementedException();
        if(amount.Curr > 0)
        {
            Collect();
        }
        else
        {
            BuildingPanel.SetActive(!BuildingPanel.activeInHierarchy);
            PlayerStats.ClearBuildings(this);
        }
        
    }


    public GameObject Collection
    {
        get { return collection; }
        set { collection = value; }
    }
    

    public float CurrTime 
    {
        get { return currTime; }
        set { currTime = value; }
    }

    public string StartTime 
    {
        get { return startTime; }
        set { startTime = value; }
    }

    public Resources Amount 
    {
        get { return amount; }
        set { amount = value; }
    }

    public GameConst.COST_TYPE AmountType 
    {
        get { return amountType; }
        set { amountType = value; }
    }

    public int RateAmount 
    {
        get { return rateAmount; }
        set { rateAmount = value; }
    }

    public float Rate 
    {
        get { return rate; }
        set { rate = value; }
    }

    void SetUp()
    {
        // index = gameObject.name;
        PlayerPrefs.SetString("Collect", DateTime.Now.Ticks.ToString());
        startTime = DateTime.Now.Ticks.ToString();
        GameFunc.CollectorSetup(this, index);
    }

    private void Awake() 
    {
        if(index != "")
            GameFunc.CollectorSetup(this, index);
    }


    private void Update() 
    {
        if(!IsCompleted)
        {
            UpdateBuilding();
        }
        else
        {
            if(startTime == "")
            {
                SetUp();
            }
            
            collection.SetActive(amount.Curr > 0);
            collection.GetComponent<Image>().color = GameFunc.UpdateCollection(amount.Curr < amount.Max && amount.Curr > 0); 
            if(amount.Curr < amount.Max)
                {
                    if(currTime >= rate)
                    {
                        amount.curr += rateAmount;
                        currTime = 0;
                    }
                    else 
                    {
                        currTime += Time.deltaTime;
                    }
                }
        }
    }

}
