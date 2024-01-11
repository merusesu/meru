using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class InGameMgr_FIGHT : MonoBehaviour
{
    public Table_Stage T_Stage = SharedObject.g_TableMgr.m_Stage; // �������� ���̺�
    public Table_Monster T_Monster = SharedObject.g_TableMgr.m_Monster; // ���� ���̺�

    public UI_FightSystem UIFIGHT;  // �����ý���

    public Transform PTRGRID, MTRGRID;    // �θ� �׸���

    SceneMgr SMGR = SharedObject.g_SceneMgr;


    private void Awake()
    {
        CreateCharacter(eCHARACTER.eCHARACTER_PLAYER);
        CreateCharacter(eCHARACTER.eCHARACTER_MONSTER);
    }


    private void Start()
    {
        UIFIGHT.gameObject.SetActive(true);
    }
    
    private void Update()
    {
       
    }

    public void CreateCharacter(eCHARACTER _e)
    {
        switch (_e)
        {
            case eCHARACTER.eCHARACTER_PLAYER:  // �÷��̾� Ŭ���� �����ϴ� �Լ�
                Character newPlayer, ResourcePlayer;  // ���� Ŭ�а� ���ҽ��� ������ ����
                int m_nPlayernumber = SharedObject.g_SceneMgr.m_nPlayerNumber;
                string m_strPrefab = SharedObject.g_TableMgr.m_PlayerBouns.m_Dictionary[m_nPlayernumber].m_strFightIMG;
                ResourcePlayer = Resources.Load<Character>("Prefab/Hero/"+ m_strPrefab);
                newPlayer = Instantiate(ResourcePlayer, PTRGRID);
                newPlayer = newPlayer.gameObject.AddComponent<Player>();
                Player player = (Player)newPlayer;
                player.c_PlayerData= SharedObject.g_SceneMgr.m_Player;  // �÷��̾� ��������
                UIFIGHT.m_cPlayer = (Player) newPlayer;
                break;
            case eCHARACTER.eCHARACTER_MONSTER: // ���� Ŭ���� �����ϴ� �Լ�
                Character newCharacter, ResourceMonster;  // ���� Ŭ�а� ���ҽ��� ������ ����
                int m_nNumber = SMGR.m_nMonsterNumber;  // �浹�� ������ ��ȣ�� ������
                string m_str = T_Monster.m_Dictionary[m_nNumber].m_strFightIMG;
                ResourceMonster = Resources.Load<Character>("Prefab/Monster/" + m_str); // ���� �������� ����
                newCharacter = Instantiate(ResourceMonster, MTRGRID); // ���� Ŭ���� ����
                newCharacter = newCharacter.gameObject.AddComponent<Monster>(); // ���� ��ũ��Ʈ �߰�
                Monster newMonster = (Monster)newCharacter;
                newMonster.MonsterSet(m_nNumber);   // ���� ��������
                UIFIGHT.m_cMonster = (Monster) newCharacter;  // �����ѱ��
                break;
            case eCHARACTER.eCHARACTER_NPC:
                break;
            case eCHARACTER.eCHARACTER_PET:
                break;
        }
    }

   
   
}
