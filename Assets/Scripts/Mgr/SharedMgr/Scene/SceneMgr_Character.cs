using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class SceneMgr : MonoBehaviour
{
    public Player_Data m_Player = new Player_Data();
    public Player_Data m_Player2 = new Player_Data();   // 2P������

    public Monster_Data m_Monster = new Monster_Data();

    public Item_Data m_PlayerItem = new Item(); // �÷��̾� ������ ����

    public Item_Data m_PlayerBuf = new Buf();   // �÷��̾� ���� ����

    public NPC_Data m_NPC = new NPC_Data();

    public PlayerPrefsData g_Player;

    public int m_nPlayerNumber, m_nPlayerNumber2;     // �÷��̾� ��ȣ

    public int m_nMonsterNumber;    // ������ ��ȣ

    public Dictionary<int, bool> m_DMonsterLive = new Dictionary<int, bool>();  // ������ ��������� ��� �Լ�

    string[] m_jobname = { "���", "����", "������", "�����", "������", "����", "������", "����" };

    string[] MonsterName = { "����Ʈ�޾�", "�ҿ�����", "�׷��긵��", "��Ż�巡��", "��", "������", "�źϽ�����" };

    public int CheckPlayertype(string _string)  // �÷��̾� ������ Ȯ���ϴ� �Լ�
    {
        int i;
        for (i = 0; i < m_jobname.Length; i++)   // �÷��̾��� ������ �������� �Լ�
        {
            if (string.Compare(_string, m_jobname[i], false) == 0)
            {
                return i;
            }
        }
        return i + 1;
    }

    public int CheckMonstertype(string _string) // ���� ������ Ȯ���ϴ� �Լ�
    {
        int i;
        for (i = 0; i < MonsterName.Length; i++)  // ������ ������ �������� �Լ�
        {
            if (string.Compare(_string, MonsterName[i], false) == 0)
            {
                return i;
            }
        }
        return i + 1;
    }

    public void SetPlayer(string _sName)  // ���嵥���ͷ� ���� || �¶��� ���� �����ͷ� ����
    {
        m_Player.Name = _sName;
    }

    public void SetPlayerJob(Player_Data _playerdata,int _nIndex)   // �÷��̾��� ������ �����ϰ� �ɷ�ġ ���ʽ��� �޴� �Լ�
    {
        _playerdata.Money = 0;
        _playerdata.Level = 1;
        m_nPlayerNumber = _nIndex;  // �÷��̾� ��ȣ ����
        for (int i = 0; i < _playerdata.PlayerStat.Length; i++)
        {
            _playerdata.PlayerStat[i] = SharedObject.g_TableMgr.m_CharacterStat.m_Dictionary[SharedObject.g_TableMgr.m_PlayerBouns.m_Dictionary[_nIndex].m_ncharacterstat].m_nStat[i];    // �⺻����
            _playerdata.PlayerStat[i] += SharedObject.g_TableMgr.m_PlayerBouns.m_Dictionary[_nIndex].m_nStat[i];     // �߰�����
        }
        _playerdata.Job = SharedObject.g_TableMgr.m_PlayerBouns.m_Dictionary[_nIndex].m_strSelect;   // ����
    }
    
    

    public void SetMonster(Monster_Data _monsterdata,int _nIndex)  // ���� ����
    {
        _monsterdata.Name = SharedObject.g_TableMgr.m_Monster.m_Dictionary[_nIndex].m_strName;
        _monsterdata.Money = SharedObject.g_TableMgr.m_Monster.m_Dictionary[_nIndex].m_nMoney;
        _monsterdata.Step = SharedObject.g_TableMgr.m_Monster.m_Dictionary[_nIndex].m_nType;
        _monsterdata.Number = _nIndex;   // ��ȣ����
        for(int i = 0; i < (int)eMONSTERSTAT.eMONSTERSTAT_END; i++)
        {
            _monsterdata.MonsterStat[i] = SharedObject.g_TableMgr.m_Monster.m_Dictionary[_nIndex].m_nStat[i];
        }
    }

    

    public void MonsterLiveSet(int _nIndex, bool _bool) // ���� �������μ���(���������� ���)
    {
        if (!m_DMonsterLive.ContainsKey(_nIndex))    // Ű��������
        {
            m_DMonsterLive.Add(_nIndex, _bool);
        }
        else    // ������ ��������
        {
            m_DMonsterLive[_nIndex] = _bool;
        }
    }

    public bool MonsterLiveGet(int _nIndex) // ���� ��������ȹ��(�κ������ ���)
    {
        if (!m_DMonsterLive.ContainsKey(_nIndex))    // Ű�������� ������ ���ѻ����̹Ƿ� ����
        {
            return true;
        }
        else    // ������ ������������
        {
            return m_DMonsterLive[_nIndex];
        }
    }

    public void GetMoney(Player_Data _playerdata,Monster_Data _monsterdata) // ���� ȹ���ϴ� �Լ�
    {
        _playerdata.Money += _monsterdata.Money;
    }

    public void PVPGetMoney(Player_Data _playerdata, Player_Data _enemydata) // ���� ȹ���ϴ� �Լ�
    {
        _playerdata.Money += _enemydata.Money;
    }

    public void SpendMoney(Player_Data _playerdata,int _nIndex) // ���� ����ϴ� �Լ�
    {
        _playerdata.Money -= _nIndex;
    }


}
