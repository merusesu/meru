using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


public partial class SceneMgr : MonoBehaviour
{
    public Vector3 PlayerNowPos = new Vector3(); // 플레이어 현재위치

    public int m_nStageID = 0;  // 스테이지 아이디(맨처음 시작시 0)

    public bool b_Start;    // 시작여부

    string[] DataIntKey =
    {
        "PHP","PST","PSTR","PINT","PHEAL","PDEF","PMEF","PCC","PCD"
    };

    string[] MDataIntKey =
    {
        "MHP","MST","MSTR","MINT","MDEF","MMEF","MCC","MCD"
    };

    public void SavePlayerData()    // 데이터 저장
    {
        if (m_Player.Name == null) return;
        g_Player.SetPlayerPrefsStringKey("Name", m_Player.Name);
        g_Player.SetPlayerPrefsStringKey("Job", m_Player.Job);
        for (int i = 0; i < m_Player.PlayerStat.Length; i++)
        {
            g_Player.SetPlayerPrefsIntKey(DataIntKey[i], m_Player.PlayerStat[i]);
        }
    }

    public void GetPlayerData() // 데이터 불러오기
    {
        m_Player.Name = g_Player.GetPlayerPrefsStringKey("Name");
        m_Player.Job = g_Player.GetPlayerPrefsStringKey("Job");
        for (int i = 0; i < m_Player.PlayerStat.Length; i++)
        {
            m_Player.PlayerStat[i] = g_Player.GetPlayerPrefsIntKey(DataIntKey[i]);
        }
    }

    public void SaveMonsterData()    // 몬스터 데이터 저장
    {
        if (m_Monster.Name == null) return;
        g_Player.SetPlayerPrefsStringKey("MName", m_Monster.Name);
        g_Player.SetPlayerPrefsIntKey("MStep", m_Monster.Step);
        for (int i = 0; i < m_Monster.MonsterStat.Length; i++)
        {
            g_Player.SetPlayerPrefsIntKey(MDataIntKey[i], m_Monster.MonsterStat[i]);
        }
    }

    public void GetMonsterData() // 몬스터 데이터 불러오기
    {
        m_Monster.Name = g_Player.GetPlayerPrefsStringKey("MName");
        if (m_Monster.Name == null) return;
        m_Monster.Step = g_Player.GetPlayerPrefsIntKey("MStep");
        for (int i = 0; i < m_Monster.MonsterStat.Length; i++)
        {
            m_Monster.MonsterStat[i] = g_Player.GetPlayerPrefsIntKey(MDataIntKey[i]);
        }
    }

}
