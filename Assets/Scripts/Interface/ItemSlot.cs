using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSlot : MonoBehaviour
{

    [SerializeField] private int cost;
    [SerializeField] private GameConst.COST_TYPE costType;
    [SerializeField] private GameObject prefab;

    public void BuyItem()
    {
        if(PlayerStats.Builder.Curr == 0)
        {
            return;
        }

        switch(costType)
        {
            case GameConst.COST_TYPE.GOLD:
                {
                    if(PlayerStats.Gold.Curr >= cost && PlayerStats.Builder.Curr == 1)
                    {
                        // TODO: add checks to see if the player can purchase
                        GameObject g = Instantiate(prefab);
                        g.GetComponent<Building>().IsDragging = true;
                        UIManager.Instance.ChangeBuildMenu();
                    }
                    break;
                }
        }
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
