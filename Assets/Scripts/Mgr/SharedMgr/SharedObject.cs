using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class SharedObject 
{
    static public SceneMgr g_SceneMgr = null;   // ��� �����͸� ����

    static public SoundMgr g_SoundMgr = null;  // ���� ������ ���

    static public VideoMgr g_VidioMgr = null;  // ���� ������ ���

    static public TableMgr g_TableMgr = null;   // ���̺� ������ ���

    static public SceneChangeMgr g_ScenechangeMgr = null;   // �� ��ȯ����

    static public PhotonMgr g_PhotonMgr = null; // ����(���)���

    static public PlayerPrefsData g_PlayerPrefsData = new PlayerPrefsData();    // �÷��̾��� �����͸� ����

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
