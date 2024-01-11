using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UI_PVPFightSystem : MonoBehaviour
{
    public GameObject m_cPlayer;    // �÷��̾�
    public GameObject m_cEnemyPlayer; // ����(2P)
    public UI_FightBag UIFIGHTBAG;
    PhotonMgr PHOTONMGR = SharedObject.g_PhotonMgr; // ����Ŵ���
    public GameObject UIWIN;    // ���� �¸�UI
    public RectTransform PlayerState;
    public GameObject FightSkill;
    public Text EnemyPlayerName, EnemyPlayerNHP, EnemyPlayerTHP;
    public Slider EnemyPlayerHP;
    public Text PlayerName, PlayerNHP, PlayerTHP;
    public Slider PlayerHP;

    public Image STSlider;
    public Text PlayerNST, PlayerTST;

    public UI_Skill_Button[] SkillBtn;

    public Image Miss_Explan;
    public Text Miss_Text;

    string[] m_jobname = { "���", "����", "������", "�����", "������", "����", "������", "����" };

    int Playerjob;

    int TotalHP, NowHP, TotalST, NowST;

    public int E_TotalHP, E_NowHP;

    bool b_HilSkill;

    bool b_CheckMiss = false;

    bool b_CheckDead = false;

    bool b_PlayAni; // �ִϸ��̼� �۵���

    float m_fWaitTime;
    float m_fDuringTime = 2.0f;


    // Start is called before the first frame update
    void Start()
    {
        PlayerName.text = m_cPlayer.GetComponent<Player>().c_PlayerData.Name;
        Playerjob = SharedObject.g_SceneMgr.m_nPlayerNumber;
        TotalHP = m_cPlayer.GetComponent<Player>().P_TotalSTAT((int)ePLAYERSTAT.ePLAYERSTAT_HP);
        NowHP = m_cPlayer.GetComponent<Player>().P_NowHPSTAT();
        TotalST = m_cPlayer.GetComponent<Player>().P_TotalSTAT((int)ePLAYERSTAT.ePLAYERSTAT_ST);
        NowST = m_cPlayer.GetComponent<Player>().P_NowSTSTAT();

        m_cPlayer.GetComponent<Player>().c_PlayerData.STUsed = 0;
        b_HilSkill = false;

        // �������� ���濡�� ������ ����
        PHOTONMGR.Enemy_Name(m_cPlayer.GetComponent<Player>().c_PlayerData.Name);
        PHOTONMGR.Enemy_TotalHP(m_cPlayer.GetComponent<Player>().P_TotalSTAT((int)ePLAYERSTAT.ePLAYERSTAT_HP));
        PHOTONMGR.Enemy_NowHP(m_cPlayer.GetComponent<Player>().P_NowHPSTAT());
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        NowHP = m_cPlayer.GetComponent<Player>().P_NowHPSTAT();
        NowST = m_cPlayer.GetComponent<Player>().P_NowSTSTAT();
        //PHOTONMGR.Enemy_NowHP(m_cPlayer.GetComponent<Player>().P_NowHPSTAT());
        //EnemyPlayerHP.value = (float)E_NowHP / (float)E_TotalHP;
        //EnemyPlayerNHP.text = E_NowHP.ToString();
        //EnemyPlayerTHP.text = E_TotalHP.ToString();

        PlayerHP.value = (float)NowHP / (float)TotalHP;
        PlayerNHP.text = NowHP.ToString();
        PlayerTHP.text = TotalHP.ToString();

        STSlider.fillAmount = (float)NowST / (float)TotalST;
        PlayerNST.text = NowST.ToString();
        PlayerTST.text = TotalST.ToString();

        if (b_PlayAni) return;
        if (b_CheckDead) return;
        if (E_NowHP <= 0 && NowHP > 0)    // �÷��̾� �¸�
        {
            m_fWaitTime = m_cEnemyPlayer.GetComponent<Player>().DeadAnimation();
            StartCoroutine(WaitAnimaition(m_fWaitTime));
            b_CheckDead = true;
            m_cPlayer.GetComponent<Player>().c_PlayerData.STUsed = 0;
            SharedObject.g_SceneMgr.PVPGetMoney(m_cPlayer.GetComponent<Player>().c_PlayerData, m_cEnemyPlayer.GetComponent<Player>().c_PlayerData);
        }
        else if (NowHP <= 0)    // �÷��̾� �й��
        {
            m_cPlayer.GetComponent<Player>().c_PlayerData.STUsed = 0;
            m_cPlayer.GetComponent<Player>().c_PlayerData.Money = 0;
            m_cPlayer.GetComponent<Player>().PlayerInit();
            m_fWaitTime = m_cPlayer.GetComponent<Player>().DeadAnimation();
            StartCoroutine(WaitAnimaition(m_fWaitTime));
            b_CheckDead = true;
            SharedObject.g_SceneMgr.b_Start = false; // ����1ȸ �ʱ�ȭ
        }
        // ����ó��
        SharedObject.g_SceneMgr.m_Player = m_cPlayer.GetComponent<Player>().c_PlayerData;
        SharedObject.g_SceneMgr.SaveMonsterData();
    }

    public void FightBtn()  // ���ݹ�ư
    {
        FightSkill.SetActive(true);
        PlayerState.anchoredPosition = new Vector2(340, 15);
        for (int i = 0; i < 3; i++)
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
            m_cPlayer.GetComponent<Player>().c_PlayerData.STUsed--;
            if (NowST >= TotalST) { m_cPlayer.GetComponent<Player>().c_PlayerData.STUsed = 0; }
        }
        else    // ���н� ���ظ� ����
        {
            Miss_Text.text = "ȸ�ǽ��з� " + m_cEnemyPlayer.name + "���� ���ظ� �Ծ����ϴ�.";
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
        m_cPlayer.GetComponent<Player>().c_PlayerData.STUsed++;
        if (m_cPlayer.GetComponent<Player>().P_NowSTSTAT() >= 0)
        {
            StartCoroutine(NonAttack());
        }
        else
        {
            m_cPlayer.GetComponent<Player>().c_PlayerData.STUsed = 0;
            StartCoroutine(MonsterAttack());
        }
    }

    public void BtnSpc()    // Ư������
    {
        m_cPlayer.GetComponent<Player>().c_PlayerData.STUsed += 2;
        if (m_cPlayer.GetComponent<Player>().P_NowSTSTAT() >= 0)
        {
            StartCoroutine(SpcAttack());
        }
        else
        {
            m_cPlayer.GetComponent<Player>().c_PlayerData.STUsed = 0;
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
        yield return new WaitForSeconds(_fWaitTime + m_fDuringTime);
        SharedObject.g_ScenechangeMgr.SceneChange(eSCENE.eSCENE_LOBBY);
    }

    IEnumerator NonAttack() // �Ϲݰ���
    {
        //b_PlayAni = true;
        //m_cPlayer.GetComponent<Player>().P_NunSkill(m_cEnemyPlayer);
        //m_cPlayer.SpcAtkAnimation();
        //m_fWaitTime = m_cEnemyPlayer.GetHitAnimation();
        //FightSkill.SetActive(false);
        //PlayerState.anchoredPosition = new Vector2(340, -135);
        yield return new WaitForSecondsRealtime(m_fWaitTime);
        //m_cEnemyPlayer.M_NunSkill(m_cPlayer);
        //m_cEnemyPlayer.NonAtkAnimation();
        //m_fWaitTime = m_cPlayer.GetHitAnimation();
        //yield return new WaitForSecondsRealtime(m_fWaitTime);
        //m_cPlayer.IdleAnimation();
        //m_cEnemyPlayer.IdleAnimation();
        //b_PlayAni = false;
    }

    IEnumerator SpcAttack() // Ư������
    {
        //b_PlayAni = true;
        //m_cPlayer.P_SpcSkill(m_cEnemyPlayer);
        //m_cPlayer.SpcAtkAnimation();
        //m_fWaitTime = m_cEnemyPlayer.GetHitAnimation();
        //FightSkill.SetActive(false);
        //PlayerState.anchoredPosition = new Vector2(340, -135);
        yield return new WaitForSecondsRealtime(m_fWaitTime);
        //m_cEnemyPlayer.M_NunSkill(m_cPlayer);
        //m_cEnemyPlayer.NonAtkAnimation();
        //m_fWaitTime = m_cPlayer.GetHitAnimation();
        //yield return new WaitForSecondsRealtime(m_fWaitTime);
        //m_cPlayer.IdleAnimation();
        //m_cEnemyPlayer.IdleAnimation();
        //b_PlayAni = false;
    }

    IEnumerator HilAttack() // �ñر�
    {
        //b_PlayAni = true;
        //m_cPlayer.P_HilSkill(m_cEnemyPlayer);
        //m_cPlayer.HilAtkAnimation();
        //m_fWaitTime = m_cEnemyPlayer.GetHitAnimation();
        //FightSkill.SetActive(false);
        //PlayerState.anchoredPosition = new Vector2(340, -135);
        yield return new WaitForSecondsRealtime(m_fWaitTime);
        //m_cEnemyPlayer.M_NunSkill(m_cPlayer);
        //m_cEnemyPlayer.NonAtkAnimation();
        //m_fWaitTime = m_cPlayer.GetHitAnimation();
        //yield return new WaitForSecondsRealtime(m_fWaitTime);
        //m_cPlayer.IdleAnimation();
        //m_cEnemyPlayer.IdleAnimation();
        //b_PlayAni = false;
    }

    IEnumerator MonsterAttack() // ���� ����
    {
        //b_PlayAni = true;
        //m_cEnemyPlayer.M_NunSkill(m_cPlayer);
        //m_cEnemyPlayer.NonAtkAnimation();
        //m_fWaitTime = m_cPlayer.GetHitAnimation();
        yield return new WaitForSecondsRealtime(m_fWaitTime);
        //m_cPlayer.IdleAnimation();
        //m_cEnemyPlayer.IdleAnimation();
        //b_PlayAni = false;
    }
}
