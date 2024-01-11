using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_StatBuy : MonoBehaviour
{
    public Player_Data c_Player;
    public List<Text> m_nName = new List<Text>();   // �̸� ����Ʈ
    string[] s_Name = { "����", "ü��", "���׹̳�", "���ݷ�", "����", "ġ����", "����", "�������׷�", "ġ��Ÿ Ȯ��", "ġ��Ÿ ������" };
    public List<Text> m_nNowStat = new List<Text>();    // ���� �ɷ�ġ ����Ʈ
    public List<Text> m_nNewStat = new List<Text>();    // ���׷��̵� �ɷ�ġ ����Ʈ
    int[] m_nPlayerStat = new int[(int)ePLAYERSTAT.ePLAYERSTAT_END];  // �÷��̾��� ����
    bool b_check = false;   // Ȯ�ι�ư
    int m_nCheckStat;
    // Start is called before the first frame update
    void Start()
    {
        c_Player = SharedObject.g_SceneMgr.m_Player;
        if (null == c_Player)
            Debug.Log("UI_Lobby Character null");
        // �̸�ǥ��
        for (int i = 0; i < s_Name.Length; i++)
        {
            m_nName[i].text = s_Name[i];
        }

        // ����ɷ�ġ ǥ��
        for(int i = 0; i < 11; i++)
        {
            if (i == 0) { m_nNowStat[i].text = c_Player.Level.ToString(); }
            else if (i == 10) { m_nNowStat[i].text = c_Player.Money.ToString(); }
            else { m_nNowStat[i].text = c_Player.PlayerStat[i - 1].ToString(); }
        }

        // ���׷��̵� �ɷ�ġ ǥ��
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

    public void OnBtn_Level()   // ������ ��ư
    {
        if (b_check) return;
        if (c_Player.Money < (c_Player.Level + 1)) return;
        else    // �÷��̾��� ���� �÷��̾� ������������ ���� ��
        {
            int _nIndex = SharedObject.g_SceneMgr.m_nPlayerNumber;  // �÷��̾� ��ȣ�� ����
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
            // ������ �ɷ�ġ�� ����ϴ°��� ������
            m_nNewStat[0].color = Color.red;
            m_nNewStat[m_nCheckStat+1].color = Color.red;
            m_nNewStat[0].text = (c_Player.Level + 1).ToString();   
            m_nNewStat[m_nCheckStat+1].text = (c_Player.PlayerStat[m_nCheckStat] + m_nPlayerStat[m_nCheckStat]).ToString();
        }
    }

    public void OnBtn_Check()   // Ȯ�� ��ư
    {
        if (!b_check) return;
        // ������ �ɷ�ġ�� �����
        SharedObject.g_SceneMgr.SpendMoney(c_Player, c_Player.Level + 1);    // ���� ����
        c_Player.Level++;   
        c_Player.PlayerStat[m_nCheckStat] += m_nPlayerStat[m_nCheckStat];
        // ������ �ɷ�ġ�� ����Ȱ��� ������
        m_nNowStat[0].text= c_Player.Level.ToString();
        m_nNowStat[m_nCheckStat + 1].text = c_Player.PlayerStat[m_nCheckStat].ToString();
        m_nNowStat[10].text = c_Player.Money.ToString();
        m_nNewStat[10].text = (c_Player.Level + 1).ToString();
        // ������Ʈ ���� �ʱ�ȭ
        m_nNewStat[0].color = Color.white;
        m_nNewStat[m_nCheckStat+1].color = Color.white;
        m_nPlayerStat[m_nCheckStat] = 0;
        m_nNewStat[0].text = c_Player.Level.ToString();
        m_nNewStat[m_nCheckStat+1].text = (c_Player.PlayerStat[m_nCheckStat] + m_nPlayerStat[m_nCheckStat]).ToString();
        b_check = false;
    }

    public void OnBtn_Exit()    // ������ ��ư
    {
        transform.gameObject.SetActive(false);
    }
}
