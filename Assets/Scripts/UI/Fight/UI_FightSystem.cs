using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UI_FightSystem : MonoBehaviour
{
    public Player m_cPlayer;    // 플레이어
    public Monster m_cMonster; // 몬스터
    public Table_Stage T_Stage = SharedObject.g_TableMgr.m_Stage; // 스테이지 테이블
    public UI_FightBag UIFIGHTBAG;
    public GameObject UIWIN;    // 게임 승리UI
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

    string[] m_jobname = { "기사", "전사", "광전사","성기사","마법사","도적","마술사","사제" };

    int Playerjob;

    int TotalHP, NowHP, M_TotalHP, M_NowHP, TotalST, NowST;

    bool b_HilSkill;

    bool b_CheckMiss = false;

    bool b_CheckDead = false;

    bool b_PlayAni; // 애니메이션 작동중

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
        if (M_NowHP <= 0 && NowHP > 0)    // 플레이어 승리
        {
            m_fWaitTime = m_cMonster.DeadAnimation();
            StartCoroutine(WaitAnimaition(m_fWaitTime));
            b_CheckDead = true;
            // 현재스테이지와 다음스테이지 아이디가 같을경우 엔딩
            if (T_Stage.m_Dictionary[SharedObject.g_SceneMgr.m_nStageID].m_nNextID == SharedObject.g_SceneMgr.m_nStageID)
            {
                if (m_cMonster.c_MonsterData.Step == (int)eMONSTERSTEP.eMONSTERSTEP_BOSS)
                {
                    UIWIN.SetActive(true);
                    return;
                }
            }
            // 보스를 잡았을 경우 스테이지가 다음정보로 불러옴
            if (m_cMonster.c_MonsterData.Step == (int)eMONSTERSTEP.eMONSTERSTEP_BOSS)
            {
                SharedObject.g_SceneMgr.m_nStageID = T_Stage.m_Dictionary[SharedObject.g_SceneMgr.m_nStageID].m_nNextID;
                SharedObject.g_SceneMgr.b_Start = false; // 최초1회 초기화
                m_cPlayer.PlayerInit();
            }
            m_cPlayer.c_PlayerData.STUsed = 0;
            SharedObject.g_SceneMgr.MonsterLiveSet(m_cMonster.c_MonsterData.Number, false); // 사망처리
            SharedObject.g_SceneMgr.GetMoney(m_cPlayer.c_PlayerData, m_cMonster.c_MonsterData);
        }
        else if (NowHP <= 0)    // 플레이어 패배시
        {
            m_cPlayer.c_PlayerData.STUsed = 0;
            m_cPlayer.c_PlayerData.Money = 0;
            m_cPlayer.PlayerInit();
            m_fWaitTime = m_cPlayer.DeadAnimation();
            StartCoroutine(WaitAnimaition(m_fWaitTime));
            b_CheckDead = true;
            SharedObject.g_SceneMgr.m_DMonsterLive.Clear();
            SharedObject.g_SceneMgr.b_Start = false; // 최초1회 초기화
        }
        // 추후처리
        SharedObject.g_SceneMgr.m_Player = m_cPlayer.c_PlayerData;
        SharedObject.g_SceneMgr.SaveMonsterData();
    }

    public void FightBtn()  // 공격버튼
    {
        if (NowHP == 0 || M_NowHP == 0) return;
        FightSkill.SetActive(true);
        PlayerState.anchoredPosition = new Vector2(340, 15);
        for(int i = 0; i < 3; i++)
        {
            SkillBtn[i].Skill(Playerjob, i);
        }
    }

    public void BagBtn()    // 가방 버튼
    {
        UIFIGHTBAG.gameObject.SetActive(true);
        PlayerState.anchoredPosition = new Vector2(340, 15);
    }

    public void MissBtn() // 회피버튼
    {
        if (b_CheckMiss) return;
        int n_PlayerMiss = Random.Range(0, 100);    // 플레이어 회피율
        int m_MonsterAttack = Random.Range(0, 100); // 몬스터 명중률
        if (n_PlayerMiss > m_MonsterAttack) // 회피시 스테미너 회복
        {
            Miss_Text.text = "회피성공으로 스테미너가 1 회복됩니다.";
            m_cPlayer.c_PlayerData.STUsed--;
            if(NowST >= TotalST) { m_cPlayer.c_PlayerData.STUsed = 0; }
        }
        else    // 실패시 피해를 입음
        {
            Miss_Text.text = "회피실패로 "+ m_cMonster.c_MonsterData.Name+"에게 피해를 입었습니다.";
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

    public void BtnNon()    // 기본공격
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

    public void BtnSpc()    // 특수공격
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

    public void BtnHil()    // 궁극기
    {
        if (((float)NowHP / 100 < 0.3f) && b_HilSkill == false) 
        {
            b_HilSkill = true;
            StartCoroutine(HilAttack());
        }
    }

    IEnumerator WaitAnimaition(float _fWaitTime)    // 애니메이션 후에 씬전환
    {
        yield return new WaitForSeconds(_fWaitTime+ m_fDuringTime);
        SharedObject.g_ScenechangeMgr.SceneChange(eSCENE.eSCENE_LOBBY);
    }

    IEnumerator NonAttack() // 일반공격
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

    IEnumerator SpcAttack() // 특수공격
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

    IEnumerator HilAttack() // 궁극기
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

    IEnumerator MonsterAttack() // ST부족시 몬스터 공격
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
