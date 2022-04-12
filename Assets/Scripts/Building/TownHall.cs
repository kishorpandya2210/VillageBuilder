using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TownHall : Building, IInteractable
{

    void IInteractable.Action()
    {
        BuildingPanel.SetActive(!BuildingPanel.activeInHierarchy);
            PlayerStats.ClearBuildings(this);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
