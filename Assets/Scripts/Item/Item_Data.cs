using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item_Data // ������ ���� ������
{
    private string m_nName;  // �̸�
    private int m_nItemType;    // ������ ����
    public int[] Itemstat = new int[(int)eITEMSTAT.eITEMSTAT_END];  // ������ �Ӽ�

    public string Name { get { return m_nName; } set { m_nName = value; } }
    public int ItemType { get { return m_nItemType; } set { m_nItemType = value; } }
}

public class Item : Item_Data   // ������
{
    private bool b_Used;    // ���뿩��(����)

    public bool Used { get { return b_Used; } set { b_Used = value; } }
}

public class Potion : Item_Data     // ����
{
    private int m_nPotionType;  // ���� Ÿ��
    private int m_nCount;       // ���� ����

    public int PotionType { get { return m_nPotionType; } set { m_nPotionType = value; } }
    public int Count { get { return m_nCount; } set { m_nCount = value; } }
}

public class Buf : Item_Data    // ����
{
    private float m_nfTime; // ��Ÿ��(������)

    public float Time { get { return m_nfTime; } set { m_nfTime = value; } }
}


