using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI_Base 
{
    protected eAI m_eAI = eAI.eAI_END;

    protected Character m_Character = null;

    protected float m_fCreateTime;    // �����ð�
    protected float m_fCurTime;       // ����ð�
    
    

    public eAI AI { set { m_eAI = value; } get { return m_eAI; } }

    public virtual void InitAI(Character _character, float _fCreateTime)    // ������ AI���� �𸣱� ������(�ʱ�ȭ)
    {
        m_Character = _character;
        m_eAI = eAI.eAI_RESET;  // �ʱⰪ�� ������

        m_fCreateTime = _fCreateTime;   // ����� ���� �����ð�
        m_fCurTime = 0f;                // ����ǰ� �ִ� �ð�
    }

    public void UpdateState() //���� 
    {
        if (m_fCurTime < m_fCreateTime) // �ش�ð����� ������
        {
            m_fCurTime += Time.deltaTime;   // �ð��� ��� �帥��.
            return;
        }
        

        switch (m_eAI)
        {
            case eAI.eAI_RESET: // ����
                SetRESET();
                break;
            case eAI.eAI_SEARCH:    // �˻�
                SetSEARCH();
                break;
            case eAI.eAI_MOVE:  // �̵�
                SetMOVE();
                break;
            case eAI.eAI_ATTACK:    // ����
                SetATTACK();
                break;
            case eAI.eAI_DIE:   // ����
                SetDIE();
                break;
        }
    }

    protected virtual void FixedUpdate()    // �����������ϋ� ������Ʈ
    {

    }

    public virtual void SetRESET()  // ����
    {
        m_Character.gameObject.SetActive(true); // ��������� ����
        m_eAI = eAI.eAI_SEARCH; // �˻����� ����
    }

    public virtual void SetSEARCH() // �˻�
    {
        m_eAI = eAI.eAI_MOVE;   // �̵����� ����
    }
    public virtual void SetMOVE()   // �̵�
    {
        m_eAI = eAI.eAI_SEARCH; // �˻����� ����
    }
    public virtual void SetATTACK() // ����   
    {
        m_eAI = eAI.eAI_DIE;    // �������� �̵�
    }
    public virtual void SetDIE()    // ����
    {
        m_eAI = eAI.eAI_RESET;  // �������� �̵�
    }
}
