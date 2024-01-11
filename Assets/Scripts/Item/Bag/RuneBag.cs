using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class RuneBag    // 룬가방-룬의 자식클래스
{
    private string m_nWeaponName;    // 룬을 장착하고 있는 무기
    private int m_nBagNumber;        // 가방에서 무기의 번호
    private int m_nRuneNumber;    // 룬 가방 번호
    private bool b_Used;        // 착용 여부

    public RuneBag()  // 초기화
    {
        WeaponName = null; BagNumber = RuneNumber = 0; Used = false;
    }

    public string WeaponName { get { return m_nWeaponName; } set { m_nWeaponName = value; } }   // 룬을 장착하고 있는 무기 이름

    public int BagNumber { get { return m_nBagNumber; } set { m_nBagNumber = value; } }   // 가방에서 무기의 번호

    public int RuneNumber { get { return m_nRuneNumber; } set { m_nRuneNumber = value; } }    // 룬 가방 번호

    public bool Used { get { return b_Used; } set { b_Used = value; } }   // 착용여부
}


