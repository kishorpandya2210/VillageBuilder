using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseManager : MonoBehaviour
{
    private static MouseManager instance;

    public static MouseManager  Instance
    {
        get {return instance; }
        set { instance = value; }
    }

    [SerializeField] GameConst.MOUSE_STATE mouseState;

    private void Awake() 
    {
        if(instance != this)
        {
            instance = this;
        }
    }

    
    public static GameConst.MOUSE_STATE MouseState 
    {
        get { return Instance.mouseState; }
        set { Instance.mouseState = value; }
    }

    void Update() 
    {
        switch(mouseState)
        {
            case GameConst.MOUSE_STATE.NONE:
                {
                    NoState();
                    break;
                }
            case GameConst.MOUSE_STATE.CLICK:
                {
                    ClickState();
                    break;
                }
        }
    }

    void NoState()
    {
        if(Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if(Physics.Raycast(ray, out hit))
            {
                // Debug.Log(hit.collider.gameObject.name);
                Component obj = hit.collider.gameObject.GetComponent(typeof(IInteractable));
                (obj as IInteractable).Action();
                
            }
            else if(Input.GetMouseButton(0))
            {
                Debug.Log("start drag");
                mouseState = GameConst.MOUSE_STATE.CLICK;
            }
        }
        
    }

    void ClickState()
    {
        if(Input.GetMouseButtonUp(0))
        {
            mouseState = GameConst.MOUSE_STATE.NONE;
        }
    }
}
