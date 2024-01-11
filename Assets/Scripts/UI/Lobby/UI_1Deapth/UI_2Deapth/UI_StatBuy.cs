using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_StatBuy : MonoBehaviour
{
    public Player_Data c_Player;
    public List<Text> m_nName = new List<Text>();   // 이름 리스트
    string[] s_Name = { "레벨", "체력", "스테미너", "공격력", "지능", "치유력", "방어력", "마법저항력", "치명타 확률", "치명타 데미지" };
    public List<Text> m_nNowStat = new List<Text>();    // 현재 능력치 리스트
    public List<Text> m_nNewStat = new List<Text>();    // 업그레이드 능력치 리스트
    int[] m_nPlayerStat = new int[(int)ePLAYERSTAT.ePLAYERSTAT_END];  // 플레이어의 스텟
    bool b_check = false;   // 확인버튼
    int m_nCheckStat;
    // Start is called before the first frame update
    void Start()
    {
        c_Player = SharedObject.g_SceneMgr.m_Player;
        if (null == c_Player)
            Debug.Log("UI_Lobby Character null");
        // 이름표기
        for (int i = 0; i < s_Name.Length; i++)
        {
            m_nName[i].text = s_Name[i];
        }

        // 현재능력치 표시
        for(int i = 0; i < 11; i++)
        {
            if (i == 0) { m_nNowStat[i].text = c_Player.Level.ToString(); }
            else if (i == 10) { m_nNowStat[i].text = c_Player.Money.ToString(); }
            else { m_nNowStat[i].text = c_Player.PlayerStat[i - 1].ToString(); }
        }

        // 업그레이드 능력치 표시
        for (int i = 0; i < 11; i++)
        {
            if (i == 0) { m_nNewStat[i].text = (c_Player.Level).ToString(); }
            else if (i == 10) { m_nNewStat[i].text = (c_Player.Level + 1).ToString(); }
            else { m_nNewStat[i].text = (c_Player.PlayerStat[i - 1] + m_nPlayerStat[i - 1]).ToString(); }
        }

    }

    // Update is called once per frame
    void Update()
    {
        c_Player = SharedObject.g_SceneMgr.m_Player;
    }

    public void OnBtn_Level()   // 레벨업 버튼
    {
        if (b_check) return;
        if (c_Player.Money < (c_Player.Level + 1)) return;
        else    // 플레이어의 돈이 플레이어 다음레벨보다 높을 때
        {
            int _nIndex = SharedObject.g_SceneMgr.m_nPlayerNumber;  // 플레이어 번호를 받음
            m_nCheckStat = Random.Range(0, (int)ePLAYERSTAT.ePLAYERSTAT_END);
            if (m_nCheckStat == 0) { m_nPlayerStat[m_nCheckStat] += 7; }
            else if (m_nCheckStat == 1) { m_nPlayerStat[m_nCheckStat]++; }
            else if (m_nCheckStat > 1 && m_nCheckStat < 5) 
            {
                if ((_nIndex >= 0 && _nIndex < 4)||_nIndex==5) { m_nCheckStat = 2; }
                else if (_nIndex == 4 || _nIndex == 6) { m_nCheckStat = 3; }
                else { m_nCheckStat = 4; }
                m_nPlayerStat[m_nCheckStat] += 5; 
            }
            else if (m_nCheckStat > 4 && m_nCheckStat < 7) { m_nPlayerStat[m_nCheckStat] += 3; }
            else if (m_nCheckStat == 7) { m_nPlayerStat[m_nCheckStat] += 2; }
            else { m_nPlayerStat[m_nCheckStat] += 10; }
            b_check = true;
            // 레벨과 능력치가 상승하는것을 보여줌
            m_nNewStat[0].color = Color.red;
            m_nNewStat[m_nCheckStat+1].color = Color.red;
            m_nNewStat[0].text = (c_Player.Level + 1).ToString();   
            m_nNewStat[m_nCheckStat+1].text = (c_Player.PlayerStat[m_nCheckStat] + m_nPlayerStat[m_nCheckStat]).ToString();
        }
    }

    public void OnBtn_Check()   // 확인 버튼
    {
        if (!b_check) return;
        // 레벨과 능력치가 적용됨
        SharedObject.g_SceneMgr.SpendMoney(c_Player, c_Player.Level + 1);    // 돈을 결제
        c_Player.Level++;   
        c_Player.PlayerStat[m_nCheckStat] += m_nPlayerStat[m_nCheckStat];
        // 레벨과 능력치가 적용된것을 보여줌
        m_nNowStat[0].text= c_Player.Level.ToString();
        m_nNowStat[m_nCheckStat + 1].text = c_Player.PlayerStat[m_nCheckStat].ToString();
        m_nNowStat[10].text = c_Player.Money.ToString();
        m_nNewStat[10].text = (c_Player.Level + 1).ToString();
        // 업데이트 내역 초기화
        m_nNewStat[0].color = Color.white;
        m_nNewStat[m_nCheckStat+1].color = Color.white;
        m_nPlayerStat[m_nCheckStat] = 0;
        m_nNewStat[0].text = c_Player.Level.ToString();
        m_nNewStat[m_nCheckStat+1].text = (c_Player.PlayerStat[m_nCheckStat] + m_nPlayerStat[m_nCheckStat]).ToString();
        b_check = false;
    }

    public void OnBtn_Exit()    // 나가기 버튼
    {
        transform.gameObject.SetActive(false);
    }
}
