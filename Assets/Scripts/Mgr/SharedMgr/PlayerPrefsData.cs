using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class PlayerPrefsData : MonoBehaviour    // 플레이어 데이터 저장하는 클래스(int,float,string)
{
    Player_Data g_PlayerData;

    public void SaveFileData(string _strPath, string _strName)  // 파일 저장(경로와 이름이 필요)
    {
        string _str = _strPath + _strName;
        g_PlayerData = SharedObject.g_SceneMgr.m_Player;
        
        var b = new BinaryFormatter();  // 글자를 암호화 시킴

        Stream stream = File.Open(_str, FileMode.OpenOrCreate, FileAccess.Write);   // 파일이 있으면 쓰고 파일이 없으면 만든다.

        if (null == stream) // 파일이 안만들어지면 리턴
            return;
        b.Serialize(stream, (object)g_PlayerData);

        stream.Close(); // 파일 닫기
    }

    public void LoadFileData(string _strPath, string _strName)  // 파일 읽기(경로와 이름이 필요)
    {
        string _str = _strPath + _strName;
        if (!File.Exists(_str)) // 파일이 없으면 되돌아감
            return;
        var b = new BinaryFormatter();  // 글자를 암호화 시킴

        Stream stream = File.Open(_str, FileMode.OpenOrCreate, FileAccess.Read);   // 파일을 읽는다.

        if (null == stream) // 파일이 안만들어지면 리턴
            return;
        g_PlayerData = (Player_Data)b.Deserialize(stream);
        SharedObject.g_SceneMgr.m_Player = g_PlayerData;

        stream.Close(); // 파일 닫기
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
