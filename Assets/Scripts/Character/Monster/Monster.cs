using System.Collections;
using System.Collections.Generic;
using UnityEngine;

 public partial class Monster : Character
{
    public Monster_Data c_MonsterData = new Monster_Data();
    int m_nNowSceen = SharedObject.g_SceneMgr.m_nSceen; // ������� �˾ƿ��� ����

    private void Awake()
    {
        if (m_nNowSceen == (int)eSCENE.eSCENE_LOBBY)    // �κ���϶��� ����
        {
            m_AI = new AI_Monster();
        }
    }
    private void Start()
    {
        if (m_nNowSceen == (int)eSCENE.eSCENE_LOBBY)    // �κ���϶��� ����
        {
            ColliderSize.Set(2, 2);
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
            Collier();
        }
    }

    public void MonsterSet(int _nIndex) // ���͵����� ����
    {
        SharedObject.g_SceneMgr.SetMonster(c_MonsterData,_nIndex);  // ���� ����
    }

    public override void Init()
    {
        base.Init();
    }
}
