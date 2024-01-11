using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_PVPMainMenu : MonoBehaviour
{
    public GameObject m_Loading;   // �ε�
    public GameObject m_Start;     // ����
    public GameObject m_Fail;      // ����

    public bool b_Isroom = true;
 
    // Start is called before the first frame update
    void Start()
    {
        SharedObject.g_PhotonMgr.OnLobby(); // �κ�����
        SharedObject.g_PhotonMgr.JoinLobbyRoom("11");
        
    }

    // Update is called once per frame
    void Update()
    {
        if (SharedObject.g_SceneMgr.m_nTeam == (int)eTEAM.MASTER)   // ����
        {
            if ((int)eTEAM.NULL != SharedObject.g_SceneMgr.m_nTeam2)     // PunPRC�� ȣ��Ǿ���.
            {
                SharedObject.g_PhotonMgr.PlayerNumber();    // ������ ������ �Ѱ���
                Debug.Log("Player2 : "+ SharedObject.g_SceneMgr.m_nPlayerNumber2);
                GameStart();
            }
        }
        if (SharedObject.g_SceneMgr.m_nTeam == (int)eTEAM.SLAVE)   // ������
        {
            SharedObject.g_PhotonMgr.PlayerNumber();    // ������ ������ �Ѱ���
            Debug.Log("Player2 : " + SharedObject.g_SceneMgr.m_nPlayerNumber2);
            if ((int)eTEAM.NULL != SharedObject.g_SceneMgr.m_nTeam2)
                GameStart();
        }
    }

    void GameStart()    // ���ӽ���
    {
        SharedObject.g_ScenechangeMgr.SceneChange(eSCENE.eSCENE_PVPFight);
    }

    void GameFail() // �κ�� ���ư�
    {
        SharedObject.g_ScenechangeMgr.SceneChange(eSCENE.eSCENE_LOBBY);
    }

}
