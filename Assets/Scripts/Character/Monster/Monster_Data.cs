using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class Monster_Data 
{
    // 이름과 직업
    private string m_nName; // 이름
    private int m_nStep;    // 몬스터 종류
    private int m_nNumber;  // 몬스터 번호
    private int m_nMoney;   // 소지금
    private int m_nDamage;   // 몬스터의 데미지 

    public int[] MonsterStat = new int[(int)eMONSTERSTAT.eMONSTERSTAT_END];  // 몬스터의 스텟

    // 이름과 직업
    public string Name { get { return m_nName; } set { m_nName = value; } }    // 이름
    public int Step { get { return m_nStep; } set { m_nStep = value; } }        // 몬스터 종류
    public int Number { get { return m_nNumber; } set { m_nNumber = value; } }        // 몬스터 종류
    public int Money { get { return m_nMoney; } set { m_nMoney = value; } } // 소지금
    public int Damage { get { return m_nDamage; } set { m_nDamage = value; } } // 몬스터의 데미지 
}
