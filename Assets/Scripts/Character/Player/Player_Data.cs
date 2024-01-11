using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

[Serializable]
public class Player_Data  // 캐릭터 데이터
{
    // 이름과 직업
    private string m_nName; // 이름
    private string m_nJob;  // 직업
    private int m_nMoney;   // 소지금
    private int m_nLevel;   // 레벨
    private int m_nDamage;   // 데미지 
    private int m_nSTUsed;   // 스테미너 소모량
    private int m_nShiled;   // 실드

    public int[] PlayerStat = new int[(int)ePLAYERSTAT.ePLAYERSTAT_END];  // 플레이어의 스텟

    // 이름과 직업
    public string Name { get { return m_nName; } set { m_nName = value; } }    // 이름
    public string Job { get { return m_nJob; } set { m_nJob = value; } } // 직업
    public int Money { get { return m_nMoney; } set { m_nMoney = value; } } // 소지금
    public int Level { get { return m_nLevel; } set { m_nLevel = value; } } // 레벨
    public int Damage { get { return m_nDamage; } set { m_nDamage = value; } } // 데미지
    public int STUsed { get { return m_nSTUsed; } set { m_nSTUsed = value; } } // 스테미너 소모량
    public int Shiled { get { return m_nShiled; } set { m_nShiled = value; } } // 실드

    
}


