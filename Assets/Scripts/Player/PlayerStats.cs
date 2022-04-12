using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{

    private static PlayerStats instance;

    public static PlayerStats  Instance
    {
        get {return instance; }
        set { instance = value; }
    }


    [SerializeField] private Resources gold;

    public static Resources Gold
    {
        get { return Instance.gold; }
        // set { gold = value; }
    }

    [SerializeField] private Resources builder;

    public static Resources Builder
    {
        get { return Instance.builder; }
        // set { Instance.builder = value; }
    }

    [SerializeField] private List<Building> buildings;

    public static List<Building> Buildings 
    {
        get { return Instance.buildings; }
    }

    public static void ClearBuildings(Building building)
    {
        foreach (Building b in Buildings)
        {
            if(b!=building)
            {
                b.BuildingPanel.SetActive(false);
            }
        }
    }

    public static void AddBuilding(Building b)
    {
        Buildings.Add(b);
    }

    public static void RemoveBuilding(Building b)
    {
       if(Buildings.Contains(b))
       {
           Buildings.Remove(b);
       }
    }

    private void Awake() 
    {
        if(instance != this)
        {
            instance = this;
        }
    }

    private void Update()
    {
        gold.UpdateResource();
        builder.UpdateResource();
    }
}
