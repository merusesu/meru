using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UI_FightSystem : MonoBehaviour
{
    public Player m_cPlayer;    // �÷��̾�
    public Monster m_cMonster; // ����
    public Table_Stage T_Stage = SharedObject.g_TableMgr.m_Stage; // �������� ���̺�
    public UI_FightBag UIFIGHTBAG;
    public GameObject UIWIN;    // ���� �¸�UI
    public RectTransform PlayerState;
    public GameObject FightSkill;
    public Text MonsterName, MonsterNHP, MonsterTHP;
    public Slider MonsterHP;
    public Text PlayerName, PlayerNHP, PlayerTHP;
    public Slider PlayerHP;

    public Image STSlider;
    public Text PlayerNST, PlayerTST;

    public UI_Skill_Button[] SkillBtn;

    public Image Miss_Explan;
    public Text Miss_Text;

    string[] m_jobname = { "���", "����", "������","�����","������","����","������","����" };

    int Playerjob;

    int TotalHP, NowHP, M_TotalHP, M_NowHP, TotalST, NowST;

    bool b_HilSkill;

    bool b_CheckMiss = false;

    bool b_CheckDead = false;

    bool b_PlayAni; // �ִϸ��̼� �۵���

    float m_fWaitTime;
    float m_fDuringTime = 2.0f;


    // Start is called before the first frame update
    void Start()
    {
        MonsterName.text = m_cMonster.c_MonsterData.Name;
        PlayerName.text = m_cPlayer.c_PlayerData.Name;
        Playerjob = SharedObject.g_SceneMgr.m_nPlayerNumber;

        TotalHP = m_cPlayer.P_TotalSTAT((int)ePLAYERSTAT.ePLAYERSTAT_HP);
        M_TotalHP = m_cMonster.M_TotalSTAT((int)eMONSTERSTAT.eMONSTERSTAT_HP);
        TotalST = m_cPlayer.P_TotalSTAT((int)ePLAYERSTAT.ePLAYERSTAT_ST);
        M_NowHP = m_cMonster.M_NowSTAT((int)eMONSTERSTAT.eMONSTERSTAT_HP);
        NowHP = m_cPlayer.P_NowHPSTAT();
        NowST = m_cPlayer.P_NowSTSTAT();

        m_cPlayer.c_PlayerData.STUsed = 0;
        b_HilSkill = false;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        M_NowHP = m_cMonster.M_NowHPSTAT();
        NowHP = m_cPlayer.P_NowHPSTAT();
        NowST = m_cPlayer.P_NowSTSTAT();
        MonsterHP.value = (float)M_NowHP / (float)M_TotalHP;
        MonsterNHP.text = M_NowHP.ToString();
        MonsterTHP.text = M_TotalHP.ToString();

        PlayerHP.value = (float)NowHP / (float)TotalHP;
        PlayerNHP.text = NowHP.ToString();
        PlayerTHP.text = TotalHP.ToString();

        STSlider.fillAmount = (float)NowST / (float)TotalST;
        PlayerNST.text = NowST.ToString();
        PlayerTST.text = TotalST.ToString();

        if (b_PlayAni) return;
        if (b_CheckDead) return;
        if (M_NowHP <= 0 && NowHP > 0)    // �÷��̾� �¸�
        {
            m_fWaitTime = m_cMonster.DeadAnimation();
            StartCoroutine(WaitAnimaition(m_fWaitTime));
            b_CheckDead = true;
            // ���罺�������� ������������ ���̵� ������� ����
            if (T_Stage.m_Dictionary[SharedObject.g_SceneMgr.m_nStageID].m_nNextID == SharedObject.g_SceneMgr.m_nStageID)
            {
                if (m_cMonster.c_MonsterData.Step == (int)eMONSTERSTEP.eMONSTERSTEP_BOSS)
                {
                    UIWIN.SetActive(true);
                    return;
                }
            }
            // ������ ����� ��� ���������� ���������� �ҷ���
            if (m_cMonster.c_MonsterData.Step == (int)eMONSTERSTEP.eMONSTERSTEP_BOSS)
            {
                SharedObject.g_SceneMgr.m_nStageID = T_Stage.m_Dictionary[SharedObject.g_SceneMgr.m_nStageID].m_nNextID;
                SharedObject.g_SceneMgr.b_Start = false; // ����1ȸ �ʱ�ȭ
                m_cPlayer.PlayerInit();
            }
            m_cPlayer.c_PlayerData.STUsed = 0;
            SharedObject.g_SceneMgr.MonsterLiveSet(m_cMonster.c_MonsterData.Number, false); // ���ó��
            SharedObject.g_SceneMgr.GetMoney(m_cPlayer.c_PlayerData, m_cMonster.c_MonsterData);
        }
        else if (NowHP <= 0)    // �÷��̾� �й��
        {
            m_cPlayer.c_PlayerData.STUsed = 0;
            m_cPlayer.c_PlayerData.Money = 0;
            m_cPlayer.PlayerInit();
            m_fWaitTime = m_cPlayer.DeadAnimation();
            StartCoroutine(WaitAnimaition(m_fWaitTime));
            b_CheckDead = true;
            SharedObject.g_SceneMgr.m_DMonsterLive.Clear();
            SharedObject.g_SceneMgr.b_Start = false; // ����1ȸ �ʱ�ȭ
        }
        // ����ó��
        SharedObject.g_SceneMgr.m_Player = m_cPlayer.c_PlayerData;
        SharedObject.g_SceneMgr.SaveMonsterData();
    }

    public void FightBtn()  // ���ݹ�ư
    {
        if (NowHP == 0 || M_NowHP == 0) return;
        FightSkill.SetActive(true);
        PlayerState.anchoredPosition = new Vector2(340, 15);
        for(int i = 0; i < 3; i++)
        {
            SkillBtn[i].Skill(Playerjob, i);
        }
    }

    public void BagBtn()    // ���� ��ư
    {
        UIFIGHTBAG.gameObject.SetActive(true);
        PlayerState.anchoredPosition = new Vector2(340, 15);
    }

    public void MissBtn() // ȸ�ǹ�ư
    {
        if (b_CheckMiss) return;
        int n_PlayerMiss = Random.Range(0, 100);    // �÷��̾� ȸ����
        int m_MonsterAttack = Random.Range(0, 100); // ���� ���߷�
        if (n_PlayerMiss > m_MonsterAttack) // ȸ�ǽ� ���׹̳� ȸ��
        {
            Miss_Text.text = "ȸ�Ǽ������� ���׹̳ʰ� 1 ȸ���˴ϴ�.";
            m_cPlayer.c_PlayerData.STUsed--;
            if(NowST >= TotalST) { m_cPlayer.c_PlayerData.STUsed = 0; }
        }
        else    // ���н� ���ظ� ����
        {
            Miss_Text.text = "ȸ�ǽ��з� "+ m_cMonster.c_MonsterData.Name+"���� ���ظ� �Ծ����ϴ�.";
            StartCoroutine(MonsterAttack());
        }
        Miss_Explan.gameObject.SetActive(true);
        b_CheckMiss = true;
    }

    public void OnBtnMissExplan()
    {
        Miss_Explan.gameObject.SetActive(false);
        b_CheckMiss = false;
    }

    public void BtnNon()    // �⺻����
    {
        m_cPlayer.c_PlayerData.STUsed++;
        if (m_cPlayer.P_NowSTSTAT() >= 0) 
        {
            StartCoroutine(NonAttack());
        }
        else
        {
            m_cPlayer.c_PlayerData.STUsed = 0;
            StartCoroutine(MonsterAttack());
        }
    }

    public void BtnSpc()    // Ư������
    {
        m_cPlayer.c_PlayerData.STUsed += 2;
        if (m_cPlayer.P_NowSTSTAT() >= 0)
        {
            StartCoroutine(SpcAttack());
        }
        else
        {
            m_cPlayer.c_PlayerData.STUsed = 0;
            StartCoroutine(MonsterAttack());
        }
    }

    public void BtnHil()    // �ñر�
    {
        if (((float)NowHP / 100 < 0.3f) && b_HilSkill == false) 
        {
            b_HilSkill = true;
            StartCoroutine(HilAttack());
        }
    }

    IEnumerator WaitAnimaition(float _fWaitTime)    // �ִϸ��̼� �Ŀ� ����ȯ
    {
        yield return new WaitForSeconds(_fWaitTime+ m_fDuringTime);
        SharedObject.g_ScenechangeMgr.SceneChange(eSCENE.eSCENE_LOBBY);
    }

    IEnumerator NonAttack() // �Ϲݰ���
    {
        b_PlayAni = true;
        m_cPlayer.P_NunSkill(m_cMonster);
        m_cPlayer.SpcAtkAnimation();
        m_fWaitTime = m_cMonster.GetHitAnimation();
        FightSkill.SetActive(false);
        PlayerState.anchoredPosition = new Vector2(340, -135);
        yield return new WaitForSecondsRealtime(m_fWaitTime);
        m_cMonster.M_NunSkill(m_cPlayer);
        m_cMonster.NonAtkAnimation();
        m_fWaitTime = m_cPlayer.GetHitAnimation();
        yield return new WaitForSecondsRealtime(m_fWaitTime);
        m_cPlayer.IdleAnimation();
        m_cMonster.IdleAnimation();
        b_PlayAni = false;
    }

    IEnumerator SpcAttack() // Ư������
    {
        b_PlayAni = true;
        m_cPlayer.P_SpcSkill(m_cMonster);
        m_cPlayer.SpcAtkAnimation();
        m_fWaitTime = m_cMonster.GetHitAnimation();
        FightSkill.SetActive(false);
        PlayerState.anchoredPosition = new Vector2(340, -135);
        yield return new WaitForSecondsRealtime(m_fWaitTime);
        m_cMonster.M_NunSkill(m_cPlayer);
        m_cMonster.NonAtkAnimation();
        m_fWaitTime = m_cPlayer.GetHitAnimation();
        yield return new WaitForSecondsRealtime(m_fWaitTime);
        m_cPlayer.IdleAnimation();
        m_cMonster.IdleAnimation();
        b_PlayAni = false;
    }

    IEnumerator HilAttack() // �ñر�
    {
        b_PlayAni = true;
        m_cPlayer.P_HilSkill(m_cMonster);
        m_cPlayer.HilAtkAnimation();
        m_fWaitTime = m_cMonster.GetHitAnimation();
        FightSkill.SetActive(false);
        PlayerState.anchoredPosition = new Vector2(340, -135);
        yield return new WaitForSecondsRealtime(m_fWaitTime);
        m_cMonster.M_NunSkill(m_cPlayer);
        m_cMonster.NonAtkAnimation();
        m_fWaitTime = m_cPlayer.GetHitAnimation();
        yield return new WaitForSecondsRealtime(m_fWaitTime);
        m_cPlayer.IdleAnimation();
        m_cMonster.IdleAnimation();
        b_PlayAni = false;
    }

    IEnumerator MonsterAttack() // ST������ ���� ����
    {
        b_PlayAni = true;
        m_cMonster.M_STSkill(m_cPlayer);
        m_cMonster.NonAtkAnimation();
        m_fWaitTime = m_cPlayer.GetHitAnimation();
        FightSkill.SetActive(false);
        PlayerState.anchoredPosition = new Vector2(340, -135);
        yield return new WaitForSecondsRealtime(m_fWaitTime);
        m_cPlayer.IdleAnimation();
        m_cMonster.IdleAnimation();
        b_PlayAni = false;
    }
}
