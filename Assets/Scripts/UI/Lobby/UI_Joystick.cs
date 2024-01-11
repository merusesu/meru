using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems; // ����Ƽ �̺�Ʈ

public class UI_Joystick : MonoBehaviour
{
    public Joystick JOYSTICK;
    public Character PLAYER;   // �÷��̾�����
    public UI_Lobby UILOBBY;    // �޴�â

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // ȭ�� ��ġ
    public void OnPointerDown(BaseEventData eventData)  // eventData�� ��ġ������ �˷���
    {
        JOYSTICK.gameObject.SetActive(true);
#if UNITY_EDITOR
#if UNITY_ANDROID
        JOYSTICK.GetRT().position = Input.mousePosition;    // PC������ ����
#else
        Touch touch = Input.GetTouch(0);    // ��ġ�� ������ŭ ������ ������
        JOYSTICK.GetRT().position = touch.position;
#endif
#endif
        JOYSTICK.OnDown((PointerEventData)eventData);
    }

    // ȭ�� ����ġ
    public void OnPointerUP(BaseEventData eventData)
    {
        PLAYER.State = Character.eSTATE.eSTATE_NONE;    // �������� �ʵ���
        JOYSTICK.gameObject.SetActive(false);
        JOYSTICK.OnUP((PointerEventData)eventData);
    }

    // ȭ�� ������
    public void OnPointerDrag(BaseEventData eventData)
    {
        JOYSTICK.OnDrag((PointerEventData)eventData,PLAYER);
    }

    public void OnBntMenu()
    {
        UILOBBY.gameObject.SetActive(true);
    }
}
