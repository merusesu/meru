using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public partial class Player :Character  // 캐릭터
{
    public Player_Data c_PlayerData = new Player_Data();
    public Item_Data c_ItemData = SharedObject.g_SceneMgr.m_PlayerItem;
    public Buf c_buf = new Buf();
    int Playerjob = SharedObject.g_SceneMgr.m_nPlayerNumber;
    int m_nNowSceen = SharedObject.g_SceneMgr.m_nSceen; // 현재씬을 알아오는 변수

    private void Awake()
    {
        if (m_nNowSceen == (int)eSCENE.eSCENE_LOBBY)
        {
            m_AI = new AI_Player();
        }
    }
    private void Start()
    {
        if (m_nNowSceen == (int)eSCENE.eSCENE_LOBBY)    // 로비씬일때만 생성
        {
            m_AI.InitAI(this, 3f); // 10초뒤에 몬스터 생성
        }
        if (m_nNowSceen == (int)eSCENE.eSCENE_FIGHT)    // 전투씬일떄만 생성
        {
            m_nAni = GetComponent<Animator>();
        }
        

    }
    private void Update()
    {
        if (m_nNowSceen == (int)eSCENE.eSCENE_LOBBY)    // 로비씬일때만 생성
        {
            Move();
        }
    }

    public override void Init()
    {
        base.Init();
    }

    
}


