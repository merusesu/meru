using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public partial class Player :Character  // ĳ����
{
    public Player_Data c_PlayerData = new Player_Data();
    public Item_Data c_ItemData = SharedObject.g_SceneMgr.m_PlayerItem;
    public Buf c_buf = new Buf();
    int Playerjob = SharedObject.g_SceneMgr.m_nPlayerNumber;
    int m_nNowSceen = SharedObject.g_SceneMgr.m_nSceen; // ������� �˾ƿ��� ����

    private void Awake()
    {
        if (m_nNowSceen == (int)eSCENE.eSCENE_LOBBY)
        {
            m_AI = new AI_Player();
        }
    }
    private void Start()
    {
        if (m_nNowSceen == (int)eSCENE.eSCENE_LOBBY)    // �κ���϶��� ����
        {
            m_AI.InitAI(this, 3f); // 10�ʵڿ� ���� ����
        }
        if (m_nNowSceen == (int)eSCENE.eSCENE_FIGHT)    // �������ϋ��� ����
        {
            m_nAni = GetComponent<Animator>();
        }
        

    }
    private void Update()
    {
        if (m_nNowSceen == (int)eSCENE.eSCENE_LOBBY)    // �κ���϶��� ����
        {
            Move();
        }
    }

    public override void Init()
    {
        base.Init();
    }

    
}


