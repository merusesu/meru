using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;


public class InGameMgr_PVPFIGHT : MonoBehaviourPunCallbacks
{
    public Table_Stage T_Stage = SharedObject.g_TableMgr.m_Stage; // 스테이지 테이블
    public Table_Monster T_Monster = SharedObject.g_TableMgr.m_Monster; // 몬스터 테이블

    public UI_PVPFightSystem UIPVPFIGHT;  // 전투시스템

    public Transform PTRGRID, MTRGRID;    // 부모 그리드


    private void Awake()
    {
        CreateCharacter(eCHARACTER.eCHARACTER_PLAYER);
    }


    private void Start()
    {
        UIPVPFIGHT.gameObject.SetActive(true);
    }
    
    private void Update()
    {
       
    }

    public void CreateCharacter(eCHARACTER _e)
    {
        switch (_e)
        {
            case eCHARACTER.eCHARACTER_PLAYER:  // 플레이어 클론을 제작하는 함수
                GameObject newPlayer, ResourcePlayer;  // 몬스터 클론과 리소스를 가져올 몬스터
                int m_nPlayernumber = SharedObject.g_SceneMgr.m_nPlayerNumber;
                string m_strPrefab = SharedObject.g_TableMgr.m_PlayerBouns.m_Dictionary[m_nPlayernumber].m_strFightIMG;
                if (SharedObject.g_SceneMgr.m_nTeam == (int)eTEAM.MASTER)
                {
                   newPlayer= PhotonNetwork.Instantiate("Prefab/Hero/PVPFight/" + m_strPrefab, PTRGRID.position, PTRGRID.rotation);
                }
                else
                {
                   newPlayer= PhotonNetwork.Instantiate("Prefab/Hero/PVPFight/" + m_strPrefab, MTRGRID.position, MTRGRID.rotation);
                }
                newPlayer.AddComponent<Player>();
                newPlayer.GetComponent<Player>().c_PlayerData = SharedObject.g_SceneMgr.m_Player;
                UIPVPFIGHT.m_cPlayer = newPlayer;
                break;
        }
    }

   
   
}
