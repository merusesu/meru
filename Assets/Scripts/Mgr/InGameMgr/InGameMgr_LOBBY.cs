using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;



public class InGameMgr_LOBBY : MonoBehaviour
{
    public Table_Stage T_Stage = SharedObject.g_TableMgr.m_Stage; // 스테이지 테이블
    public Table_Monster T_Monster = SharedObject.g_TableMgr.m_Monster; // 몬스터 테이블
    public Table_PlayerBouns T_Player = SharedObject.g_TableMgr.m_PlayerBouns;  // 플레이어 테이블

    public Transform TRGRID;    // 스테이지를 담는 그리드
    public Stage StagePrefab;   // 스테이지 프리팹

    public Camera CAMERA;   // 카메라

    public SafeZone SAFEZONE;   // 회복존
    bool b_Heal = true;    // 회복여부

    // 플레이어
    public Transform PTRGRID;    // 플레이어 그리드
    public Character m_Player;     // 플레이어 

    // 몬스터
    public List<Character> m_lMonster;  // 몬스터 리스트
    public List<Character> m_lSideBoss; // 중간보스 리스트

    public Character c_NPC;     // NPC
    public UI_Lobby UILOBBY;    // 로비메뉴
    public UI_Store UISTORE;    // 상점창
    public UI_Joystick UIJOYSTICK;  // 조이스틱


   //public Dictionary<eCHARACTER, Character> m_Dictionary = new Dictionary<eCHARACTER, Character>();

    private void Awake()
    {
        CreatePlayer();
        CheckStage(SharedObject.g_SceneMgr.m_nStageID);  // 스테이지를 확인하고 프리팹생성
    }

    private void Start()
    {
        UILOBBY.gameObject.SetActive(false);
        if (SharedObject.g_SceneMgr.b_Start) // 최초 1회 실행 후에 반복되는것
        {
            Player newPlayer = (Player)m_Player;
            if (newPlayer.P_NowHPSTAT() > 0) // 플레이어 체력이 0이상의 경우
            {
                newPlayer.gameObject.transform.position = SharedObject.g_SceneMgr.PlayerNowPos; // 저장된좌표로 이동
            }
        }
        else // 최초 1회에 실행할것
        {

        }
        if (SharedObject.g_SceneMgr.b_Start == false) { SharedObject.g_SceneMgr.b_Start = true; } // 최초1회
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            UILOBBY.gameObject.SetActive(true);
        }
        if (SAFEZONE.b_Heal&&b_Heal)   // 회복시 몬스터 부활
        {
            UISTORE.gameObject.SetActive(true);
            for (int i = 0; i < m_lMonster.Count; i++)
            {
                Player newPlayer = (Player)m_Player;
                newPlayer.PlayerInit();
                m_lMonster[i].gameObject.SetActive(true);
                Monster newMonster = (Monster)m_lMonster[i];
                SharedObject.g_SceneMgr.MonsterLiveSet(newMonster.c_MonsterData.Number, true);  // 몬스터 번호를 생존처리
            }
            b_Heal = false;
        }
    }



    public void CreatePlayer()  // 플레이어 생성
    {
        int _nPlayerNumber = SharedObject.g_SceneMgr.m_nPlayerNumber;
        //Character m_strPrefab = Resources.Load<Character>("Prefab/Hero/" + T_Player.m_Dictionary[_nPlayerNumber].m_strLobbyIMG);
        //Character newCharacter = Instantiate(m_strPrefab, PTRGRID); // 플레이어 클론 생성
        m_Player = m_Player.gameObject.AddComponent<Player>();  // 플레이어 스크립트 추가
        Player newPlayer = (Player)m_Player;    // 플레이어로 재설정
        newPlayer.c_PlayerData = SharedObject.g_SceneMgr.m_Player;  // 플레이어 정보구축
        AI_Player newAIPlayer = (AI_Player)m_Player.m_AI;   // AI설정
        //m_Player = newCharacter;
        UILOBBY.UICHARACTER.c_Player = (Player)m_Player;
        
    }

    public void CreateMonster(int _nMonsterNumber,Transform GRID,MonsterPos monsterPos)   // 몬스터 생성(번호와 위치값을 가져옴)
    {
        if (_nMonsterNumber == 0) return;   // 0이면 생성안함
        Character m_strPrefab = Resources.Load<Character>("Prefab/Monster/" + T_Monster.m_Dictionary[_nMonsterNumber].m_strLobbyIMG);  // 리소스 가져오기
        Character newCharacter = Instantiate(m_strPrefab, GRID);    // 몬스터 클론 생성
        newCharacter = newCharacter.gameObject.AddComponent<Monster>(); // 몬스터 스크립트 추가
        Monster newMonster = (Monster)newCharacter; // 몬스터로 재설정
        newMonster.MonsterSet(_nMonsterNumber); // 몬스터 정보구축
        if (!SharedObject.g_SceneMgr.MonsterLiveGet(_nMonsterNumber)) { newMonster.gameObject.SetActive(false); }  // 살아있지 않으면 비활성화
        AI_Monster newAIMonster = (AI_Monster)newCharacter.m_AI;    // AI설정
        newAIMonster.SetListPos(monsterPos.m_nPathNode);
        newAIMonster.targetTransform = m_Player.transform;
        if (T_Monster.m_Dictionary[_nMonsterNumber].m_nType == 0)   // 타입에 따라 구분
        {
            m_lMonster.Add(newCharacter);   // 몬스터 리스트에 저장
        }
        else
        {
            m_lSideBoss.Add(newCharacter);  // 중간보스리스트에 저장
        }
    }

    

    public void CheckStage(int _nIndex) // 현재스테이지를 불러옴
    {
        // 스테이지 프리팹정보를 불러옴
        string m_str = T_Stage.m_Dictionary[_nIndex].m_strPrefab;
        StagePrefab = Resources.Load<Stage>("Prefab/Map/" + m_str);
        Stage newstage = Instantiate(StagePrefab);  // 스테이지 생성

        // 스테이지 정보를 넘겨줌
        SAFEZONE = newstage.SAFEZONE;

        
        // 일반몬스터
        for(int i = 0; i < T_Stage.m_Dictionary[_nIndex].m_bMonster.Length; i++)
        {
            CreateMonster(T_Stage.m_Dictionary[_nIndex].m_bMonster[i], newstage.MTRGRID[i],newstage.m_listPos[i]);
        }
        for (int i = 0; i < T_Stage.m_Dictionary[_nIndex].m_bSideBoss.Length; i++)
        {
            CreateMonster(T_Stage.m_Dictionary[_nIndex].m_bSideBoss[i], newstage.SBTRGRID[i], newstage.m_SlistPos[i]);
        }
        CreateMonster(T_Stage.m_Dictionary[_nIndex].m_bBoss, newstage.BTRGRID, newstage.m_BlistPos);
    }
}
