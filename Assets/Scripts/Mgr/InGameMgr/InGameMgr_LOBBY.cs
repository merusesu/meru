using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;



public class InGameMgr_LOBBY : MonoBehaviour
{
    public Table_Stage T_Stage = SharedObject.g_TableMgr.m_Stage; // �������� ���̺�
    public Table_Monster T_Monster = SharedObject.g_TableMgr.m_Monster; // ���� ���̺�
    public Table_PlayerBouns T_Player = SharedObject.g_TableMgr.m_PlayerBouns;  // �÷��̾� ���̺�

    public Transform TRGRID;    // ���������� ��� �׸���
    public Stage StagePrefab;   // �������� ������

    public Camera CAMERA;   // ī�޶�

    public SafeZone SAFEZONE;   // ȸ����
    bool b_Heal = true;    // ȸ������

    // �÷��̾�
    public Transform PTRGRID;    // �÷��̾� �׸���
    public Character m_Player;     // �÷��̾� 

    // ����
    public List<Character> m_lMonster;  // ���� ����Ʈ
    public List<Character> m_lSideBoss; // �߰����� ����Ʈ

    public Character c_NPC;     // NPC
    public UI_Lobby UILOBBY;    // �κ�޴�
    public UI_Store UISTORE;    // ����â
    public UI_Joystick UIJOYSTICK;  // ���̽�ƽ


   //public Dictionary<eCHARACTER, Character> m_Dictionary = new Dictionary<eCHARACTER, Character>();

    private void Awake()
    {
        CreatePlayer();
        CheckStage(SharedObject.g_SceneMgr.m_nStageID);  // ���������� Ȯ���ϰ� �����ջ���
    }

    private void Start()
    {
        UILOBBY.gameObject.SetActive(false);
        if (SharedObject.g_SceneMgr.b_Start) // ���� 1ȸ ���� �Ŀ� �ݺ��Ǵ°�
        {
            Player newPlayer = (Player)m_Player;
            if (newPlayer.P_NowHPSTAT() > 0) // �÷��̾� ü���� 0�̻��� ���
            {
                newPlayer.gameObject.transform.position = SharedObject.g_SceneMgr.PlayerNowPos; // �������ǥ�� �̵�
            }
        }
        else // ���� 1ȸ�� �����Ұ�
        {

        }
        if (SharedObject.g_SceneMgr.b_Start == false) { SharedObject.g_SceneMgr.b_Start = true; } // ����1ȸ
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            UILOBBY.gameObject.SetActive(true);
        }
        if (SAFEZONE.b_Heal&&b_Heal)   // ȸ���� ���� ��Ȱ
        {
            UISTORE.gameObject.SetActive(true);
            for (int i = 0; i < m_lMonster.Count; i++)
            {
                Player newPlayer = (Player)m_Player;
                newPlayer.PlayerInit();
                m_lMonster[i].gameObject.SetActive(true);
                Monster newMonster = (Monster)m_lMonster[i];
                SharedObject.g_SceneMgr.MonsterLiveSet(newMonster.c_MonsterData.Number, true);  // ���� ��ȣ�� ����ó��
            }
            b_Heal = false;
        }
    }



    public void CreatePlayer()  // �÷��̾� ����
    {
        int _nPlayerNumber = SharedObject.g_SceneMgr.m_nPlayerNumber;
        //Character m_strPrefab = Resources.Load<Character>("Prefab/Hero/" + T_Player.m_Dictionary[_nPlayerNumber].m_strLobbyIMG);
        //Character newCharacter = Instantiate(m_strPrefab, PTRGRID); // �÷��̾� Ŭ�� ����
        m_Player = m_Player.gameObject.AddComponent<Player>();  // �÷��̾� ��ũ��Ʈ �߰�
        Player newPlayer = (Player)m_Player;    // �÷��̾�� �缳��
        newPlayer.c_PlayerData = SharedObject.g_SceneMgr.m_Player;  // �÷��̾� ��������
        AI_Player newAIPlayer = (AI_Player)m_Player.m_AI;   // AI����
        //m_Player = newCharacter;
        UILOBBY.UICHARACTER.c_Player = (Player)m_Player;
        
    }

    public void CreateMonster(int _nMonsterNumber,Transform GRID,MonsterPos monsterPos)   // ���� ����(��ȣ�� ��ġ���� ������)
    {
        if (_nMonsterNumber == 0) return;   // 0�̸� ��������
        Character m_strPrefab = Resources.Load<Character>("Prefab/Monster/" + T_Monster.m_Dictionary[_nMonsterNumber].m_strLobbyIMG);  // ���ҽ� ��������
        Character newCharacter = Instantiate(m_strPrefab, GRID);    // ���� Ŭ�� ����
        newCharacter = newCharacter.gameObject.AddComponent<Monster>(); // ���� ��ũ��Ʈ �߰�
        Monster newMonster = (Monster)newCharacter; // ���ͷ� �缳��
        newMonster.MonsterSet(_nMonsterNumber); // ���� ��������
        if (!SharedObject.g_SceneMgr.MonsterLiveGet(_nMonsterNumber)) { newMonster.gameObject.SetActive(false); }  // ������� ������ ��Ȱ��ȭ
        AI_Monster newAIMonster = (AI_Monster)newCharacter.m_AI;    // AI����
        newAIMonster.SetListPos(monsterPos.m_nPathNode);
        newAIMonster.targetTransform = m_Player.transform;
        if (T_Monster.m_Dictionary[_nMonsterNumber].m_nType == 0)   // Ÿ�Կ� ���� ����
        {
            m_lMonster.Add(newCharacter);   // ���� ����Ʈ�� ����
        }
        else
        {
            m_lSideBoss.Add(newCharacter);  // �߰���������Ʈ�� ����
        }
    }

    

    public void CheckStage(int _nIndex) // ���罺�������� �ҷ���
    {
        // �������� ������������ �ҷ���
        string m_str = T_Stage.m_Dictionary[_nIndex].m_strPrefab;
        StagePrefab = Resources.Load<Stage>("Prefab/Map/" + m_str);
        Stage newstage = Instantiate(StagePrefab);  // �������� ����

        // �������� ������ �Ѱ���
        SAFEZONE = newstage.SAFEZONE;

        
        // �Ϲݸ���
        for(int i = 0; i < T_Stage.m_Dictionary[_nIndex].m_bMonster.Length; i++)
        {
            CreateMonster(T_Stage.m_Dictionary[_nIndex].m_bMonster[i], newstage.MTRGRID[i],newstage.m_listPos[i]);
        }
        for (int i = 0; i < T_Stage.m_Dictionary[_nIndex].m_bSideBoss.Length; i++)
        {
            CreateMonster(T_Stage.m_Dictionary[_nIndex].m_bSideBoss[i], newstage.SBTRGRID[i], newstage.m_SlistPos[i]);
        }
        CreateMonster(T_Stage.m_Dictionary[_nIndex].m_bBoss, newstage.BTRGRID, newstage.m_BlistPos);
    }
}
