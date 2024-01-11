using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class Monster_Data 
{
    // �̸��� ����
    private string m_nName; // �̸�
    private int m_nStep;    // ���� ����
    private int m_nNumber;  // ���� ��ȣ
    private int m_nMoney;   // ������
    private int m_nDamage;   // ������ ������ 

    public int[] MonsterStat = new int[(int)eMONSTERSTAT.eMONSTERSTAT_END];  // ������ ����

    // �̸��� ����
    public string Name { get { return m_nName; } set { m_nName = value; } }    // �̸�
    public int Step { get { return m_nStep; } set { m_nStep = value; } }        // ���� ����
    public int Number { get { return m_nNumber; } set { m_nNumber = value; } }        // ���� ����
    public int Money { get { return m_nMoney; } set { m_nMoney = value; } } // ������
    public int Damage { get { return m_nDamage; } set { m_nDamage = value; } } // ������ ������ 
}
