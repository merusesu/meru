using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Table_SkillText : Table_Base
{
    [Serializable]
    public class Info
    {
        public int m_nID;   // 아이디
        public int m_nType;   // 종류
        public string m_strNonName;    // 기본이름
        public string m_strNonExp;     // 기본설명
        public string m_strSpcName;    // 특수이름
        public string m_strSpcExp;     // 특수설명
        public string m_strHilName;    // 궁극기이름
        public string m_strHilExp;     // 궁극기설명
    }

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
        _reader.get(_nRow, ref _info.m_nType);
        _reader.get(_nRow, ref _info.m_strNonName);
        _reader.get(_nRow, ref _info.m_strNonExp);
        _reader.get(_nRow, ref _info.m_strSpcName);
        _reader.get(_nRow, ref _info.m_strSpcExp);
        _reader.get(_nRow, ref _info.m_strHilName);
        _reader.get(_nRow, ref _info.m_strHilExp);

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
        }

        Debug.Log("[Table Load] " + _strName + " : " + m_Dictionary.Count);
    }
}
