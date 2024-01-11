using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;


public class InGameMgr_PVPFIGHT : MonoBehaviourPunCallbacks
{
    public Table_Stage T_Stage = SharedObject.g_TableMgr.m_Stage; // �������� ���̺�
    public Table_Monster T_Monster = SharedObject.g_TableMgr.m_Monster; // ���� ���̺�

    public UI_PVPFightSystem UIPVPFIGHT;  // �����ý���

    public Transform PTRGRID, MTRGRID;    // �θ� �׸���


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
            case eCHARACTER.eCHARACTER_PLAYER:  // �÷��̾� Ŭ���� �����ϴ� �Լ�
                GameObject newPlayer, ResourcePlayer;  // ���� Ŭ�а� ���ҽ��� ������ ����
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
