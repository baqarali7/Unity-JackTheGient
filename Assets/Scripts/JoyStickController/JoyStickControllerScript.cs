using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class JoyStickControllerScript : MonoBehaviour,IPointerUpHandler, IPointerDownHandler
{

    private PlayerMoveWithJoyStick playerMove;

    void Start()
    {
        playerMove = GameObject.Find("Jack").GetComponent<PlayerMoveWithJoyStick>();
    }



    public void OnPointerDown(PointerEventData eventData)
    {
        if (gameObject.name == "Left")
        {
            playerMove.setMoveLeft(true);
        }
        else
        {
            playerMove.setMoveLeft(false);
        }
    }

    public void OnPointerUp (PointerEventData data)
    {
        playerMove.StopMoving();
    }

    
}
