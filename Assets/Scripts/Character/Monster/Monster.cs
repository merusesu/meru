using System.Collections;
using System.Collections.Generic;
using UnityEngine;

 public partial class Monster : Character
{
    public Monster_Data c_MonsterData = new Monster_Data();
    int m_nNowSceen = SharedObject.g_SceneMgr.m_nSceen; // 현재씬을 알아오는 변수

    private void Awake()
    {
        if (m_nNowSceen == (int)eSCENE.eSCENE_LOBBY)    // 로비씬일때만 생성
        {
            m_AI = new AI_Monster();
        }
    }
    private void Start()
    {
        if (m_nNowSceen == (int)eSCENE.eSCENE_LOBBY)    // 로비씬일때만 생성
        {
            ColliderSize.Set(2, 2);
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
            Collier();
        }
    }

    public void MonsterSet(int _nIndex) // 몬스터데이터 설정
    {
        SharedObject.g_SceneMgr.SetMonster(c_MonsterData,_nIndex);  // 몬스터 생성
    }

    public override void Init()
    {
        base.Init();
    }
}
