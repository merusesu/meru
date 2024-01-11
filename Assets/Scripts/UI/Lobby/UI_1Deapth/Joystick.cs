using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Joystick : MonoBehaviour
{
    public Image IMGKEY;    // ��� Ű

    RectTransform m_RT; // �簢���� ��ġ��ǥ
    Image m_ImgBg;
    Vector3 m_vInput = Vector3.zero;
    Vector3 m_vPosition = Vector3.zero;

    public RectTransform GetRT() { return m_RT; }

    void Awake()
    {
        m_RT = GetComponent<RectTransform>();
        m_ImgBg = GetComponent<Image>();
    }

    public void OnDown(PointerEventData eventData)  // ���������� �θ��� ��ġ��ǥ
    {
        IMGKEY.rectTransform.anchoredPosition = Vector3.zero;
    }

    public void OnUP(PointerEventData eventData)    // ������ ������ ��ġ�� ���������� ���ؼ�
    {
        m_vInput = Vector3.zero;
        IMGKEY.rectTransform.anchoredPosition = Vector3.zero;
    }

    public void OnDrag(PointerEventData eventData,Character player)  // ��ũ����ġ�� ��ǥ�� �����ͼ� ���׶�̸� �߾ӿ� �׸��� ����
    {
        if (RectTransformUtility.ScreenPointToLocalPointInRectangle(IMGKEY.rectTransform,
            eventData.position, eventData.pressEventCamera, out Vector2 localPointer))  // localpointer�� x,y��ǥ�� �޾ƿ´�
        {
            localPointer.x = localPointer.x / IMGKEY.rectTransform.sizeDelta.x;
            localPointer.y = localPointer.y / IMGKEY.rectTransform.sizeDelta.y;

            m_vInput.x = localPointer.x;
            m_vInput.y = localPointer.y;
            m_vInput.z = 0;

           // Debug.Log("x=" + m_vInput.x);

            m_vInput = (m_vInput.magnitude > 1.0f) ? m_vInput.normalized : m_vInput;    // ��������

            m_vPosition.x = m_vInput.x * (IMGKEY.rectTransform.sizeDelta.x / 2f);
            m_vPosition.y = m_vInput.y * (IMGKEY.rectTransform.sizeDelta.y / 2f);

            IMGKEY.rectTransform.anchoredPosition = m_vPosition;
            // ĳ���Ϳ��� �̵����(�����ʿ�)
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
