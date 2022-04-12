using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    private static UIManager instance;

    public static UIManager  Instance
    {
        get {return instance; }
        set { instance = value; }
    }

    [SerializeField] List<Image> playerImages;
    [SerializeField] List<Text> playerTexts;
    [SerializeField] List<GameObject> buildMenus;
    [SerializeField] GameObject buildMenu;

    
    public void ChangeBuildMenu()
    {
        buildMenu.SetActive(!buildMenu.activeInHierarchy);
        MouseManager.MouseState = 
        MouseManager.MouseState == GameConst.MOUSE_STATE.UI 
        ? GameConst.MOUSE_STATE.NONE : GameConst.MOUSE_STATE.CLICK;
    }

    public void ChangeMenu(int i)
    {
        GameFunc.ChangeMenu(buildMenus.ToArray(), i);
    }

    private void Awake() 
    {
        if(instance != this)
        {
            instance = this;
        }
    }

    private void Start()
    {
        PlayerStats.Gold.ResourceImage = playerImages[0];
        PlayerStats.Builder.ResourceImage = playerImages[1];

        PlayerStats.Gold.ResourceText = playerTexts[0];
        PlayerStats.Builder.ResourceText = playerTexts[1];
    }
}
