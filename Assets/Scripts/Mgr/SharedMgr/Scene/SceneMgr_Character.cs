using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class SceneMgr : MonoBehaviour
{
    public Player_Data m_Player = new Player_Data();
    public Player_Data m_Player2 = new Player_Data();   // 2P데이터

    public Monster_Data m_Monster = new Monster_Data();

    public Item_Data m_PlayerItem = new Item(); // 플레이어 아이템 정보

    public Item_Data m_PlayerBuf = new Buf();   // 플레이어 버프 정보

    public NPC_Data m_NPC = new NPC_Data();

    public PlayerPrefsData g_Player;

    public int m_nPlayerNumber, m_nPlayerNumber2;     // 플레이어 번호

    public int m_nMonsterNumber;    // 몬스터의 번호

    public Dictionary<int, bool> m_DMonsterLive = new Dictionary<int, bool>();  // 몬스터의 사망정보를 담는 함수

    string[] m_jobname = { "기사", "전사", "광전사", "성기사", "마법사", "도적", "마술사", "사제" };

    string[] MonsterName = { "나이트메어", "소울이터", "테러브링거", "약탈드래곤", "골렘", "슬라임", "거북슬라임" };

    public int CheckPlayertype(string _string)  // 플레이어 종류를 확인하는 함수
    {
        int i;
        for (i = 0; i < m_jobname.Length; i++)   // 플레이어의 직업을 가져오는 함수
        {
            if (string.Compare(_string, m_jobname[i], false) == 0)
            {
                return i;
            }
        }
        return i + 1;
    }

    public int CheckMonstertype(string _string) // 몬스터 종류를 확인하는 함수
    {
        int i;
        for (i = 0; i < MonsterName.Length; i++)  // 몬스터의 직업을 가져오는 함수
        {
            if (string.Compare(_string, MonsterName[i], false) == 0)
            {
                return i;
            }
        }
        return i + 1;
    }

    public void SetPlayer(string _sName)  // 저장데이터로 세팅 || 온라인 서버 데이터로 세팅
    {
        m_Player.Name = _sName;
    }

    public void SetPlayerJob(Player_Data _playerdata,int _nIndex)   // 플레이어의 직업을 선택하고 능력치 보너스를 받는 함수
    {
        _playerdata.Money = 0;
        _playerdata.Level = 1;
        m_nPlayerNumber = _nIndex;  // 플레이어 번호 저장
        for (int i = 0; i < _playerdata.PlayerStat.Length; i++)
        {
            _playerdata.PlayerStat[i] = SharedObject.g_TableMgr.m_CharacterStat.m_Dictionary[SharedObject.g_TableMgr.m_PlayerBouns.m_Dictionary[_nIndex].m_ncharacterstat].m_nStat[i];    // 기본스텟
            _playerdata.PlayerStat[i] += SharedObject.g_TableMgr.m_PlayerBouns.m_Dictionary[_nIndex].m_nStat[i];     // 추가스텟
        }
        _playerdata.Job = SharedObject.g_TableMgr.m_PlayerBouns.m_Dictionary[_nIndex].m_strSelect;   // 직업
    }
    
    

    public void SetMonster(Monster_Data _monsterdata,int _nIndex)  // 몬스터 설정
    {
        _monsterdata.Name = SharedObject.g_TableMgr.m_Monster.m_Dictionary[_nIndex].m_strName;
        _monsterdata.Money = SharedObject.g_TableMgr.m_Monster.m_Dictionary[_nIndex].m_nMoney;
        _monsterdata.Step = SharedObject.g_TableMgr.m_Monster.m_Dictionary[_nIndex].m_nType;
        _monsterdata.Number = _nIndex;   // 번호저장
        for(int i = 0; i < (int)eMONSTERSTAT.eMONSTERSTAT_END; i++)
        {
            _monsterdata.MonsterStat[i] = SharedObject.g_TableMgr.m_Monster.m_Dictionary[_nIndex].m_nStat[i];
        }
    }

    

    public void MonsterLiveSet(int _nIndex, bool _bool) // 몬스터 생존여부설정(전투씬에서 사용)
    {
        if (!m_DMonsterLive.ContainsKey(_nIndex))    // 키가없으면
        {
            m_DMonsterLive.Add(_nIndex, _bool);
        }
        else    // 있으면 정보저장
        {
            m_DMonsterLive[_nIndex] = _bool;
        }
    }

    public bool MonsterLiveGet(int _nIndex) // 몬스터 생존여부획득(로비씬에서 사용)
    {
        if (!m_DMonsterLive.ContainsKey(_nIndex))    // 키가없으면 전투를 안한상태이므로 생존
        {
            return true;
        }
        else    // 있으면 정보가져오기
        {
            return m_DMonsterLive[_nIndex];
        }
    }

    public void GetMoney(Player_Data _playerdata,Monster_Data _monsterdata) // 돈을 획득하는 함수
    {
        _playerdata.Money += _monsterdata.Money;
    }

    public void PVPGetMoney(Player_Data _playerdata, Player_Data _enemydata) // 돈을 획득하는 함수
    {
        _playerdata.Money += _enemydata.Money;
    }

    public void SpendMoney(Player_Data _playerdata,int _nIndex) // 돈을 사용하는 함수
    {
        _playerdata.Money -= _nIndex;
    }


}
