using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Building : MonoBehaviour
{
    [SerializeField] private int cost;
    [SerializeField] private GameConst.COST_TYPE costType;
    [SerializeField] private float timeToMake;
    [SerializeField] private GameObject buildingPanel;
    [SerializeField] private bool isDragging;
    [SerializeField] private bool isBuilding;
    [SerializeField] private float buildTime;
    [SerializeField] private bool isCompleted;

    public bool IsCompleted
    {
        get { return isCompleted; }
        set { isCompleted = value; }
    }

    public bool IsBuilding
    {
        get { return isBuilding; }
        set { isBuilding = value; }
    }

    public bool IsDragging
    {
        get { return isDragging; }
        set { isDragging = value; }
    }

    public GameObject BuildingPanel
    {
        get { return buildingPanel; }
        set { buildingPanel = value; }
    }

    public float TimeToMake 
    {
        get { return timeToMake; }
        set { timeToMake = value; }
    }

    public GameConst.COST_TYPE CostType 
    {
        get { return costType; }
        set { costType = value; }
    }


    public int Cost
    {
        get { return cost; }
        set { cost = value; }
    }


    public void DeleteBuilding()
    {
        PlayerStats.RemoveBuilding(this);
        Destroy(this.gameObject);
    }

    public void DragBuilding()
    {
        PlayerStats.RemoveBuilding(this);
        PlayerStats.Gold.Curr += cost;
        isCompleted = false;
        isDragging = true;
    }

    

    public void UpdateBuilding()
    {
        if (isDragging)
        {
            Vector3 pos = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x,Input.mousePosition.y,1));
            transform.position = new Vector3(pos.x*5,0,pos.z*5);

            if(Input.GetMouseButtonDown(0))
            {
                // TODO: check to see if building can be placed there
                isDragging = false;
                isBuilding = true;
                PlayerStats.Builder.Curr = 0;
            }
        }
        else
        {
            if (isBuilding)
            {
                if(buildTime<timeToMake)
                {
                    buildTime += Time.deltaTime;
                }
                else
                {
                    isBuilding = false;
                    isCompleted = true;
                    PlayerStats.AddBuilding(this);
                    PlayerStats.Gold.Curr -= cost;
                    PlayerStats.Builder.Curr = 1;
                }
            }   
        }
    }

}
