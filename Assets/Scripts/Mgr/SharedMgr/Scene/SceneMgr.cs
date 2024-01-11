using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class SceneMgr : MonoBehaviour
{
    public int m_nSceen = (int)eSCENE.eSCENE_MAIN; // ���� ���� �����ϴ� ����
    public int m_nTeam = (int)eTEAM.NULL;  // ���� ���� ����
    public int m_nTeam2 = (int)eTEAM.NULL;  // ����� ����

    private void Awake()
    {
        if (SharedObject.g_SceneMgr==null)    // �� ������ �ٽõ��ƿ� ��� ���
        {
            SharedObject.g_SceneMgr = this;

            b_Start = false;

            
            SharedObject.GetTable();
            m_nStageID = SharedObject.g_TableMgr.m_Stage.m_Dictionary[m_nStageID].m_nID;    // ù��° ���������� ����

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
