using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class InGameMgr_FIGHT : MonoBehaviour
{
    public Table_Stage T_Stage = SharedObject.g_TableMgr.m_Stage; // 스테이지 테이블
    public Table_Monster T_Monster = SharedObject.g_TableMgr.m_Monster; // 몬스터 테이블

    public UI_FightSystem UIFIGHT;  // 전투시스템

    public Transform PTRGRID, MTRGRID;    // 부모 그리드

    SceneMgr SMGR = SharedObject.g_SceneMgr;


    private void Awake()
    {
        CreateCharacter(eCHARACTER.eCHARACTER_PLAYER);
        CreateCharacter(eCHARACTER.eCHARACTER_MONSTER);
    }


    private void Start()
    {
        UIFIGHT.gameObject.SetActive(true);
    }
    
    private void Update()
    {
       
    }

    public void CreateCharacter(eCHARACTER _e)
    {
        switch (_e)
        {
            case eCHARACTER.eCHARACTER_PLAYER:  // 플레이어 클론을 제작하는 함수
                Character newPlayer, ResourcePlayer;  // 몬스터 클론과 리소스를 가져올 몬스터
                int m_nPlayernumber = SharedObject.g_SceneMgr.m_nPlayerNumber;
                string m_strPrefab = SharedObject.g_TableMgr.m_PlayerBouns.m_Dictionary[m_nPlayernumber].m_strFightIMG;
                ResourcePlayer = Resources.Load<Character>("Prefab/Hero/"+ m_strPrefab);
                newPlayer = Instantiate(ResourcePlayer, PTRGRID);
                newPlayer = newPlayer.gameObject.AddComponent<Player>();
                Player player = (Player)newPlayer;
                player.c_PlayerData= SharedObject.g_SceneMgr.m_Player;  // 플레이어 정보구축
                UIFIGHT.m_cPlayer = (Player) newPlayer;
                break;
            case eCHARACTER.eCHARACTER_MONSTER: // 몬스터 클론을 제작하는 함수
                Character newCharacter, ResourceMonster;  // 몬스터 클론과 리소스를 가져올 몬스터
                int m_nNumber = SMGR.m_nMonsterNumber;  // 충돌한 몬스터의 번호를 가져옴
                string m_str = T_Monster.m_Dictionary[m_nNumber].m_strFightIMG;
                ResourceMonster = Resources.Load<Character>("Prefab/Monster/" + m_str); // 몬스터 프리펩을 설정
                newCharacter = Instantiate(ResourceMonster, MTRGRID); // 몬스터 클론을 생성
                newCharacter = newCharacter.gameObject.AddComponent<Monster>(); // 몬스터 스크립트 추가
                Monster newMonster = (Monster)newCharacter;
                newMonster.MonsterSet(m_nNumber);   // 몬스터 정보생성
                UIFIGHT.m_cMonster = (Monster) newCharacter;  // 정보넘기기
                break;
            case eCHARACTER.eCHARACTER_NPC:
                break;
            case eCHARACTER.eCHARACTER_PET:
                break;
        }
    }

   
   
}
