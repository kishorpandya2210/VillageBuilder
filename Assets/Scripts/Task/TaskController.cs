using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TaskController : MonoBehaviour
{
    private bool goldFarmExists = false;
    private bool hospitalExists = false;
    private bool schoolExists = false;
    private bool theatreExists = false;
    private bool farmMarketExists = false;
    private bool builderHouseExists = false;

    [SerializeField] private GameObject FinishedTasks;

    public GameObject FinishedTasksF
    {
        get { return FinishedTasks; }
        set { FinishedTasks = value; }
    }

    [SerializeField] private GameObject MinerTask;

    public GameObject MinerTaskF
    {
        get { return MinerTask; }
        set { MinerTask = value; }
    }
    [SerializeField] private GameObject HospitalTask;
    public GameObject HospitalTaskF
    {
        get { return HospitalTask; }
        set { HospitalTask = value; }
    }

    [SerializeField] public GameObject SchoolTask;
    public GameObject SchoolTaskF
    {
        get { return SchoolTask; }
        set { SchoolTask = value; }
    }

    [SerializeField] public GameObject TheatreTask;
    public GameObject TheatreTaskF
    {
        get { return TheatreTask; }
        set { TheatreTask = value; }
    }

    [SerializeField] public GameObject FarmerMarketTask;
    public GameObject FarmerMarketTaskF
    {
        get { return FarmerMarketTask; }
        set { FarmerMarketTask = value; }
    }

    [SerializeField] public GameObject BuilderHouseTask;
    public GameObject BuilderHouseTaskF
    {
        get { return BuilderHouseTask; }
        set { BuilderHouseTask = value; }
    }
    //this method starts the game
    private void Awake()
    {
    
    }
    //this method has no use
    private void Start()
    {
        
    }
    // Update is called once per frame
    private void Update()
    {
        // Debug.Log("Started");
        List<Building> bList = PlayerStats.Buildings;
        foreach (Building b in bList)
        {
            if (b.name == "GoldFarm(Clone)")
            {
                // Debug.Log("Gold farm exists");
                if(!goldFarmExists)
                {
                    //Debug.Log("Amount updated");
                 PlayerStats.Gold.Curr += 100;   
                }
                goldFarmExists = true;
                MinerTask.SetActive(false);  
            }
            //another if statement for the other buildings
            if(b.name == "Hospital(Clone)")
            {
                //Debug.Log("Hospital exists");
                if(!hospitalExists)
                {
                    //Debug.Log("Amount updated");
                 PlayerStats.Gold.Curr += 100;   
                }
                hospitalExists = true;
                HospitalTask.SetActive(false);
            }
            //another if statement for the other buildings
            if(b.name == "School(Clone)")
            {
                //Debug.Log("School exists");
                if(!schoolExists)
                {
                    //Debug.Log("Amount updated");
                 PlayerStats.Gold.Curr += 100;   
                }
                schoolExists = true;
                SchoolTask.SetActive(false);
            }
            //another if statement for the other buildings
            if(b.name == "Theatre(Clone)")
            {
                //Debug.Log("Theatre exists");
                if(!theatreExists)
                {
                    //Debug.Log("Amount updated");
                 PlayerStats.Gold.Curr += 100;   
                }
                theatreExists = true;
                TheatreTask.SetActive(false);
            }
            //another if statement for the other buildings
            if(b.name == "FarmerMarket(Clone)")
            {
                //Debug.Log("Farmer`s Market exists");
                if(!farmMarketExists)
                {
                    //Debug.Log("Amount updated");
                 PlayerStats.Gold.Curr += 100;   
                }
                farmMarketExists = true;
                FarmerMarketTask.SetActive(false);
            }
            //another if statement for the other buildings
            if(b.name == "House(Clone)")
            {
                //Debug.Log("Builder House exists");
                if(!builderHouseExists)
                {
                    //Debug.Log("Amount updated");
                 PlayerStats.Gold.Curr += 100;   
                }
                builderHouseExists = true;
                BuilderHouseTask.SetActive(false);
            }
        }


        if(goldFarmExists && farmMarketExists && hospitalExists && builderHouseExists && schoolExists && theatreExists)
        {
            FinishedTasks.SetActive(true);
        }
    }
}
