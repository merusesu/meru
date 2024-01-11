using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Table_Item : Table_Base
{
    [Serializable]
    public class Info
    {
        public int m_nID;   // 아이디
        public int[] m_nStat = new int[(int)eITEMSTAT.eITEMSTAT_END];  // 스텟
        public int m_nType;   // 종류
        public string m_strName;    // 이름
    }
    public List<int> m_nKeys = new List<int>(); // 키값을 저장하는 리스트

    public Dictionary<int, Info> m_Dictionary = new Dictionary<int, Info>();


    public Info Get(int _nID)   // 테이블을 가져올때 있으면 출력 없으면 null
    {
        if (m_Dictionary.ContainsKey(_nID))
            return m_Dictionary[_nID];
        return null;
    }

    public void Init_Binary(string _strName)    // 테이블 로드
    {
        Load_Binary<Dictionary<int, Info>>(_strName, ref m_Dictionary); // 값을 내보낸다
    }

    public void Save_Binary(string _strName)    // 테이블 저장
    {
        Save_Binary(_strName, m_Dictionary);
        Debug.Log("[Table Save]" + _strName + ":" + m_Dictionary.Count);
    }

    protected bool _Read(CSVReader _reader,Info _info,int _nRow,int _nstartCol) // 테이블의 정보를 읽어오는 함수
    {
        if (_reader.reset_row(_nRow, _nstartCol) == false)
            return false;
        _reader.get(_nRow, ref _info.m_nID);
        for(int i=0;i<_info.m_nStat.Length;i++)
        {
            _reader.get(_nRow, ref _info.m_nStat[i]);
        }
        _reader.get(_nRow, ref _info.m_nType);
        _reader.get(_nRow, ref _info.m_strName);

        return true;
    }

    public void Init_CSV(string _strName,int _nStartRow,int _nStartCol) // 테이블을 읽는 함수
    {
        CSVReader reader = GetCSVReader(_strName);
        for(int row = _nStartRow; row < reader.row; row++)
        {
            Info info = new Info();
            if (_Read(reader, info, row, _nStartCol) == false)
                break;
            //Debug.Log("ID = " + info.m_nID + "해당아이디 중복사용");

            m_Dictionary.Add(info.m_nID, info);
            m_nKeys.Add(info.m_nID);
        }

        Debug.Log("[Table Load] " + _strName + " : " + m_Dictionary.Count);
    }
}
