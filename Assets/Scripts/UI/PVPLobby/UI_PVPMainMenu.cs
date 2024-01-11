using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_PVPMainMenu : MonoBehaviour
{
    public GameObject m_Loading;   // 로딩
    public GameObject m_Start;     // 시작
    public GameObject m_Fail;      // 실패

    public bool b_Isroom = true;
 
    // Start is called before the first frame update
    void Start()
    {
        SharedObject.g_PhotonMgr.OnLobby(); // 로비접속
        SharedObject.g_PhotonMgr.JoinLobbyRoom("11");
        
    }

    // Update is called once per frame
    void Update()
    {
        if (SharedObject.g_SceneMgr.m_nTeam == (int)eTEAM.MASTER)   // 방장
        {
            if ((int)eTEAM.NULL != SharedObject.g_SceneMgr.m_nTeam2)     // PunPRC가 호출되었다.
            {
                SharedObject.g_PhotonMgr.PlayerNumber();    // 방장의 정보를 넘겨줌
                Debug.Log("Player2 : "+ SharedObject.g_SceneMgr.m_nPlayerNumber2);
                GameStart();
            }
        }
        if (SharedObject.g_SceneMgr.m_nTeam == (int)eTEAM.SLAVE)   // 참가자
        {
            SharedObject.g_PhotonMgr.PlayerNumber();    // 방장의 정보를 넘겨줌
            Debug.Log("Player2 : " + SharedObject.g_SceneMgr.m_nPlayerNumber2);
            if ((int)eTEAM.NULL != SharedObject.g_SceneMgr.m_nTeam2)
                GameStart();
        }
    }

    void GameStart()    // 게임시작
    {
        SharedObject.g_ScenechangeMgr.SceneChange(eSCENE.eSCENE_PVPFight);
    }

    void GameFail() // 로비로 돌아감
    {
        SharedObject.g_ScenechangeMgr.SceneChange(eSCENE.eSCENE_LOBBY);
    }

}
