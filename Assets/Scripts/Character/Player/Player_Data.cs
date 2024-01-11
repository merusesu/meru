using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

[Serializable]
public class Player_Data  // ĳ���� ������
{
    // �̸��� ����
    private string m_nName; // �̸�
    private string m_nJob;  // ����
    private int m_nMoney;   // ������
    private int m_nLevel;   // ����
    private int m_nDamage;   // ������ 
    private int m_nSTUsed;   // ���׹̳� �Ҹ�
    private int m_nShiled;   // �ǵ�

    public int[] PlayerStat = new int[(int)ePLAYERSTAT.ePLAYERSTAT_END];  // �÷��̾��� ����

    // �̸��� ����
    public string Name { get { return m_nName; } set { m_nName = value; } }    // �̸�
    public string Job { get { return m_nJob; } set { m_nJob = value; } } // ����
    public int Money { get { return m_nMoney; } set { m_nMoney = value; } } // ������
    public int Level { get { return m_nLevel; } set { m_nLevel = value; } } // ����
    public int Damage { get { return m_nDamage; } set { m_nDamage = value; } } // ������
    public int STUsed { get { return m_nSTUsed; } set { m_nSTUsed = value; } } // ���׹̳� �Ҹ�
    public int Shiled { get { return m_nShiled; } set { m_nShiled = value; } } // �ǵ�

    
}


