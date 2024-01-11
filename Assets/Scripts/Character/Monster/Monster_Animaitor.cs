using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class Monster 
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

    public void NonAtkAnimation()
    {
        m_nAni.SetBool("IsNonAtk", true);
    }

    public void IdleAnimation()
    {
        m_nAni.SetBool("IsNonAtk", false);
        m_nAni.SetBool("IsGetHit", false);
    }
}
