using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI_Base 
{
    protected eAI m_eAI = eAI.eAI_END;

    protected Character m_Character = null;

    protected float m_fCreateTime;    // 생성시간
    protected float m_fCurTime;       // 현재시간
    
    

    public eAI AI { set { m_eAI = value; } get { return m_eAI; } }

    public virtual void InitAI(Character _character, float _fCreateTime)    // 누구의 AI인지 모르기 때문에(초기화)
    {
        m_Character = _character;
        m_eAI = eAI.eAI_RESET;  // 초기값은 생성값

        m_fCreateTime = _fCreateTime;   // 만들기 위한 최종시간
        m_fCurTime = 0f;                // 진행되고 있는 시간
    }

    public void UpdateState() //상태 
    {
        if (m_fCurTime < m_fCreateTime) // 해당시간보다 작으면
        {
            m_fCurTime += Time.deltaTime;   // 시간이 계속 흐른다.
            return;
        }
        

        switch (m_eAI)
        {
            case eAI.eAI_RESET: // 생성
                SetRESET();
                break;
            case eAI.eAI_SEARCH:    // 검색
                SetSEARCH();
                break;
            case eAI.eAI_MOVE:  // 이동
                SetMOVE();
                break;
            case eAI.eAI_ATTACK:    // 공격
                SetATTACK();
                break;
            case eAI.eAI_DIE:   // 죽음
                SetDIE();
                break;
        }
    }

    protected virtual void FixedUpdate()    // 고정프레임일떄 업데이트
    {

    }

    public virtual void SetRESET()  // 생성
    {
        m_Character.gameObject.SetActive(true); // 만들었으면 생성
        m_eAI = eAI.eAI_SEARCH; // 검색으로 변경
    }

    public virtual void SetSEARCH() // 검색
    {
        m_eAI = eAI.eAI_MOVE;   // 이동으로 변경
    }
    public virtual void SetMOVE()   // 이동
    {
        m_eAI = eAI.eAI_SEARCH; // 검색으로 변경
    }
    public virtual void SetATTACK() // 공격   
    {
        m_eAI = eAI.eAI_DIE;    // 죽음으로 이동
    }
    public virtual void SetDIE()    // 죽음
    {
        m_eAI = eAI.eAI_RESET;  // 생성으로 이동
    }
}
