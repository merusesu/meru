using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class SharedObject 
{
    static public SceneMgr g_SceneMgr = null;   // 모든 데이터를 저장

    static public SoundMgr g_SoundMgr = null;  // 사운드 정보를 사용

    static public VideoMgr g_VidioMgr = null;  // 비디오 정보를 사용

    static public TableMgr g_TableMgr = null;   // 테이블 정보를 사용

    static public SceneChangeMgr g_ScenechangeMgr = null;   // 씬 전환정보

    static public PhotonMgr g_PhotonMgr = null; // 포톤(통신)사용

    static public PlayerPrefsData g_PlayerPrefsData = new PlayerPrefsData();    // 플레이어의 데이터를 저장

    static public string m_strHttp = "http://58.78.211.147:3000/";  // "http:127.0.0.1:3000/"

    static public void Set()
    {

    }

    static public void GetTable()
    {
        if (g_TableMgr == null)
        {
            g_TableMgr = new TableMgr();
            g_TableMgr.Init_CSV();
        }
    }

}
