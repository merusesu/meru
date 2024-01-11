using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class Player 
{
    Animator m_nAni;
    public float DeadAnimation()
    {
        m_nAni.SetBool("IsDead", true);
        float m_fAniTime = m_nAni.GetCurrentAnimatorStateInfo(0).length;
        return m_fAniTime;
    }

    public float GetHitAnimation()
    {
        m_nAni.SetBool("IsGetHit", true);
        float m_fAniTime = m_nAni.GetCurrentAnimatorStateInfo(0).length;
        return m_fAniTime;
    }

    public void SpcAtkAnimation()
    {
        m_nAni.SetBool("IsSpcAtk", true);
    }

    public void HilAtkAnimation()
    {
        m_nAni.SetBool("IsHilAtk", true);
    }

    public void IdleAnimation()
    {
        m_nAni.SetBool("IsGetHit", false);
        m_nAni.SetBool("IsSpcAtk", false);
        m_nAni.SetBool("IsHilAtk", false);
    }
}
