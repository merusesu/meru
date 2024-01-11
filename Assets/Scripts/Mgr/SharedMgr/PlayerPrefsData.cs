using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class PlayerPrefsData : MonoBehaviour    // �÷��̾� ������ �����ϴ� Ŭ����(int,float,string)
{
    Player_Data g_PlayerData;

    public void SaveFileData(string _strPath, string _strName)  // ���� ����(��ο� �̸��� �ʿ�)
    {
        string _str = _strPath + _strName;
        g_PlayerData = SharedObject.g_SceneMgr.m_Player;
        
        var b = new BinaryFormatter();  // ���ڸ� ��ȣȭ ��Ŵ

        Stream stream = File.Open(_str, FileMode.OpenOrCreate, FileAccess.Write);   // ������ ������ ���� ������ ������ �����.

        if (null == stream) // ������ �ȸ�������� ����
            return;
        b.Serialize(stream, (object)g_PlayerData);

        stream.Close(); // ���� �ݱ�
    }

    public void LoadFileData(string _strPath, string _strName)  // ���� �б�(��ο� �̸��� �ʿ�)
    {
        string _str = _strPath + _strName;
        if (!File.Exists(_str)) // ������ ������ �ǵ��ư�
            return;
        var b = new BinaryFormatter();  // ���ڸ� ��ȣȭ ��Ŵ

        Stream stream = File.Open(_str, FileMode.OpenOrCreate, FileAccess.Read);   // ������ �д´�.

        if (null == stream) // ������ �ȸ�������� ����
            return;
        g_PlayerData = (Player_Data)b.Deserialize(stream);
        SharedObject.g_SceneMgr.m_Player = g_PlayerData;

        stream.Close(); // ���� �ݱ�
    }



   

    void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    public void SetPlayerPrefsIntKey(string _strKey,int _nValue)
    {
        PlayerPrefs.SetInt(_strKey, _nValue);
        PlayerPrefs.Save();
    }

    public int GetPlayerPrefsIntKey(string _strKey)
    {
        return PlayerPrefs.GetInt(_strKey);
    }

    public void SetPlayerPrefsFloatKey(string _strKey,float _nValue)
    {
        PlayerPrefs.SetFloat(_strKey, _nValue);
        PlayerPrefs.Save();
    }

    public float GetPlayerPrefsFloatKey(string _strKey)
    {
        return PlayerPrefs.GetFloat(_strKey);
    }

    public void SetPlayerPrefsStringKey(string _strKey,string _nValue)
    {
        PlayerPrefs.SetString(_strKey, _nValue);
        PlayerPrefs.Save();
    }

    public string GetPlayerPrefsStringKey(string _strKey)
    {
        return PlayerPrefs.GetString(_strKey);
    }

    
}
