using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems; // 유니티 이벤트

public class UI_Joystick : MonoBehaviour
{
    public Joystick JOYSTICK;
    public Character PLAYER;   // 플레이어정보
    public UI_Lobby UILOBBY;    // 메뉴창

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // 화면 터치
    public void OnPointerDown(BaseEventData eventData)  // eventData는 위치정보를 알려줌
    {
        JOYSTICK.gameObject.SetActive(true);
#if UNITY_EDITOR
#if UNITY_ANDROID
        JOYSTICK.GetRT().position = Input.mousePosition;    // PC에서만 가능
#else
        Touch touch = Input.GetTouch(0);    // 터치한 개수만큼 정보를 가져옴
        JOYSTICK.GetRT().position = touch.position;
#endif
#endif
        JOYSTICK.OnDown((PointerEventData)eventData);
    }

    // 화면 비터치
    public void OnPointerUP(BaseEventData eventData)
    {
        PLAYER.State = Character.eSTATE.eSTATE_NONE;    // 움직이지 않도록
        JOYSTICK.gameObject.SetActive(false);
        JOYSTICK.OnUP((PointerEventData)eventData);
    }

    // 화면 움직임
    public void OnPointerDrag(BaseEventData eventData)
    {
        JOYSTICK.OnDrag((PointerEventData)eventData,PLAYER);
    }

    public void OnBntMenu()
    {
        UILOBBY.gameObject.SetActive(true);
    }
}
