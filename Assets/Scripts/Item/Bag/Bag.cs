using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Bag    // 방어구
{
    private int m_nBagNumber; // 가방번호
    private bool b_Used;    // 착용여부

    public Bag()
    {
        BagNumber = 0;  Used = false;
    }
    public int BagNumber { get { return m_nBagNumber; } set { m_nBagNumber = value; } }   // 가방번호

    public bool Used { get { return b_Used; } set { b_Used = value; } } // 착용여부
}
