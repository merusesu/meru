using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Table_Stage : Table_Base
{
    [Serializable]
    public class Info
    {
        public int m_nID;
        public int m_nNextID;
        public int m_nType;
        public int[] m_bMonster = new int[6];
        public int[] m_bSideBoss = new int[2];
        public int m_bBoss;
        public int m_nItemMoney;    // ������ ����
        public int m_nPotionMoney;        // ���ǰ���
        public string m_strPrefab;
        public string m_strName;
    }

    public Dictionary<int, Info> m_Dictionary = new Dictionary<int, Info>();


    public Info Get(int _nID)   // ���̺��� �����ö� ������ ��� ������ null
    {
        if (m_Dictionary.ContainsKey(_nID))
            return m_Dictionary[_nID];
        return null;
    }

    public void Init_Binary(string _strName)    // ���̺� �ε�
    {
        Load_Binary<Dictionary<int, Info>>(_strName, ref m_Dictionary); // ���� ��������
    }

    public void Save_Binary(string _strName)    // ���̺� ����
    {
        Save_Binary(_strName, m_Dictionary);
        Debug.Log("[Table Save]" + _strName + ":" + m_Dictionary.Count);
    }

    protected bool _Read(CSVReader _reader,Info _info,int _nRow,int _nstartCol) // ���̺��� ������ �о���� �Լ�
    {
        if (_reader.reset_row(_nRow, _nstartCol) == false)
            return false;
        _reader.get(_nRow, ref _info.m_nID);
        _reader.get(_nRow, ref _info.m_nNextID);
        _reader.get(_nRow, ref _info.m_nType);
        for(int i=0;i<_info.m_bMonster.Length;i++)
        {
            _reader.get(_nRow, ref _info.m_bMonster[i]);
        }
        for (int i = 0; i < _info.m_bSideBoss.Length; i++)
        {
            _reader.get(_nRow, ref _info.m_bSideBoss[i]);
        }
        _reader.get(_nRow, ref _info.m_bBoss);
        _reader.get(_nRow, ref _info.m_nItemMoney);
        _reader.get(_nRow, ref _info.m_nPotionMoney);
        _reader.get(_nRow, ref _info.m_strPrefab);
        _reader.get(_nRow, ref _info.m_strName);

        return true;
    }

    public void Init_CSV(string _strName,int _nStartRow,int _nStartCol) // ���̺��� �д� �Լ�
    {
        CSVReader reader = GetCSVReader(_strName);
        for(int row = _nStartRow; row < reader.row; row++)
        {
            Info info = new Info();
            if (_Read(reader, info, row, _nStartCol) == false)
                break;
            //Debug.Log("ID = " + info.m_nID + "�ش���̵� �ߺ����");

            m_Dictionary.Add(info.m_nID, info);
        }

        Debug.Log("[Table Load] " + _strName + " : " + m_Dictionary.Count);
    }
}
