using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item_Data // 아이템 들어가는 데이터
{
    private string m_nName;  // 이름
    private int m_nItemType;    // 아이템 종류
    public int[] Itemstat = new int[(int)eITEMSTAT.eITEMSTAT_END];  // 아이템 속성

    public string Name { get { return m_nName; } set { m_nName = value; } }
    public int ItemType { get { return m_nItemType; } set { m_nItemType = value; } }
}

public class Item : Item_Data   // 아이템
{
    private bool b_Used;    // 착용여부(장비류)

    public bool Used { get { return b_Used; } set { b_Used = value; } }
}

public class Potion : Item_Data     // 포션
{
    private int m_nPotionType;  // 포션 타입
    private int m_nCount;       // 포션 개수

    public int PotionType { get { return m_nPotionType; } set { m_nPotionType = value; } }
    public int Count { get { return m_nCount; } set { m_nCount = value; } }
}

public class Buf : Item_Data    // 버프
{
    private float m_nfTime; // 쿨타임(버프류)

    public float Time { get { return m_nfTime; } set { m_nfTime = value; } }
}


