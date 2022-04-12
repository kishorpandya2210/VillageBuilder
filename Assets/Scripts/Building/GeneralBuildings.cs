using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneralBuildings : Building, IInteractable
{


    [SerializeField] private string startTime;
    [SerializeField] private float currTime;

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



    void IInteractable.Action()
    {
        
        BuildingPanel.SetActive(!BuildingPanel.activeInHierarchy);
        PlayerStats.ClearBuildings(this);
        
    }

    void SetUp()
    {
        PlayerPrefs.SetString("Collect", DateTime.Now.Ticks.ToString());
        startTime = DateTime.Now.Ticks.ToString();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
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
        }
    }
}
