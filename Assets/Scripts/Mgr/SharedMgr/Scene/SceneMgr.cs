using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class SceneMgr : MonoBehaviour
{
    public int m_nSceen = (int)eSCENE.eSCENE_MAIN; // 현재 씬을 저장하는 변수
    public int m_nTeam = (int)eTEAM.NULL;  // 현재 나의 상태
    public int m_nTeam2 = (int)eTEAM.NULL;  // 상대의 상태

    private void Awake()
    {
        if (SharedObject.g_SceneMgr==null)    // 이 씬으로 다시돌아올 경우 사용
        {
            SharedObject.g_SceneMgr = this;

            b_Start = false;

            
            SharedObject.GetTable();
            m_nStageID = SharedObject.g_TableMgr.m_Stage.m_Dictionary[m_nStageID].m_nID;    // 첫번째 스테이지를 넣음

            DontDestroyOnLoad(gameObject);
        }
    }

    private void Start()
    {
        for (int i = 0; i < SharedObject.g_TableMgr.m_Item.m_nKeys.Count; i++)
        {
            int j = SharedObject.g_TableMgr.m_Item.m_nKeys[i];
            ItemSetting(SharedObject.g_TableMgr.m_Item.m_Dictionary[j].m_nType, SharedObject.g_TableMgr.m_Item.m_Dictionary[j].m_nID);
        }

    }
}
