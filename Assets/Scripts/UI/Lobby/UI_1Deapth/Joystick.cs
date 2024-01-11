using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Joystick : MonoBehaviour
{
    public Image IMGKEY;    // 가운데 키

    RectTransform m_RT; // 사각형의 위치좌표
    Image m_ImgBg;
    Vector3 m_vInput = Vector3.zero;
    Vector3 m_vPosition = Vector3.zero;

    public RectTransform GetRT() { return m_RT; }

    void Awake()
    {
        m_RT = GetComponent<RectTransform>();
        m_ImgBg = GetComponent<Image>();
    }

    public void OnDown(PointerEventData eventData)  // 눌렸을때의 부모의 위치좌표
    {
        IMGKEY.rectTransform.anchoredPosition = Vector3.zero;
    }

    public void OnUP(PointerEventData eventData)    // 떗을때 원래의 위치로 돌려보내기 위해서
    {
        m_vInput = Vector3.zero;
        IMGKEY.rectTransform.anchoredPosition = Vector3.zero;
    }

    public void OnDrag(PointerEventData eventData,Character player)  // 스크린위치의 좌표를 가져와서 동그라미를 중앙에 그리는 역할
    {
        if (RectTransformUtility.ScreenPointToLocalPointInRectangle(IMGKEY.rectTransform,
            eventData.position, eventData.pressEventCamera, out Vector2 localPointer))  // localpointer로 x,y좌표를 받아온다
        {
            localPointer.x = localPointer.x / IMGKEY.rectTransform.sizeDelta.x;
            localPointer.y = localPointer.y / IMGKEY.rectTransform.sizeDelta.y;

            m_vInput.x = localPointer.x;
            m_vInput.y = localPointer.y;
            m_vInput.z = 0;

           // Debug.Log("x=" + m_vInput.x);

            m_vInput = (m_vInput.magnitude > 1.0f) ? m_vInput.normalized : m_vInput;    // 오차범위

            m_vPosition.x = m_vInput.x * (IMGKEY.rectTransform.sizeDelta.x / 2f);
            m_vPosition.y = m_vInput.y * (IMGKEY.rectTransform.sizeDelta.y / 2f);

            IMGKEY.rectTransform.anchoredPosition = m_vPosition;
            // 캐릭터에게 이동명령(수정필요)
            if (0 < m_vInput.x)
            {
                if (0 < m_vInput.y)
                    player.State = Character.eSTATE.eSTATE_RIGHTUPMOVE;
                else
                    player.State = Character.eSTATE.eSTATE_RIGHTDOWNMOVE;
            }
            else
            {
                if (0 < m_vInput.y)
                    player.State = Character.eSTATE.eSTATE_LEFTUPMOVE;
                else
                    player.State = Character.eSTATE.eSTATE_LEFTDOWNMOVE;
            }
        }
    }
}
