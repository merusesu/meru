﻿using UnityEngine;
[System.Serializable]
public enum eMENU
{
	eMENU_CHARACTER,
	eMENU_BAG,
	eMENU_RUNEBAG,
	eMENU_SETTING,
	eMENU_OPTION,
	eMENU_END
}

public enum eCHARACTER
{
	eCHARACTER_PLAYER,
	eCHARACTER_MONSTER,
	eCHARACTER_NPC,
	eCHARACTER_PET,
	eCHARACTER_END
}

 public enum ePLAYER // 직업 생성함수
{
	ePLAYER_KNIGHT,
	ePLAYER_WARRIOR,
	ePLAYER_BERSERKER,
	ePLAYER_PALADIN,
	ePLAYER_WIZARD,
	ePLAYER_ROGUE,
	ePLAYER_MAGICIAN,
	ePLAYER_PRIST,
	ePLAYER_END
}

public enum ePLAYERSTAT	// 플레이어 스텟
{
	ePLAYERSTAT_HP,  // 체력
	ePLAYERSTAT_ST,  // 스테미너
	ePLAYERSTAT_STR,  // 공격력
	ePLAYERSTAT_INT,  // 지능
	ePLAYERSTAT_HEAL,  // 치유력
	ePLAYERSTAT_DEF,  // 방어력
	ePLAYERSTAT_MEF,  // 마법 저항력
	ePLAYERSTAT_CRICHANCE,   // 치명타 확률
	ePLAYERSTAT_CRIDAMAGE,  // 치명타 데미지
	ePLAYERSTAT_END
}

public enum eMONSTERSTEP	// 몬스터 스텝(타입종류)
{
	eMONSTERSTEP_NOMER,		// 일반 몬스터
	eMONSTERSTEP_SIDEBOSS,	// 중간보스
	eMONSTERSTEP_BOSS,		// 보스
	eMONSTERSTEP_END
}

public enum eMONSTERTYPE	// 몬스터 종류
{
	eMONSTERTYPE_DNIGHTMARE,
	eMONSTERTYPE_DSOULEATER,
	eMONSTERTYPE_DTERRORBRINGER,
	eMONSTERTYPE_DUSURPER,
	eMONSTERTYPE_GOLEM,
	eMONSTERTYPE_SLIME,
	eMONSTERTYPE_TURTLESHELL,
	eMONSTERTYPE_END
}

public enum eMONSTERSTAT // 몬스터 스텟
{
	eMONSTERSTAT_HP,  // 체력
	eMONSTERSTAT_STR,  // 공격력
	eMONSTERSTAT_INT,  // 지능
	eMONSTERSTAT_DEF,  // 방어력
	eMONSTERSTAT_MEF,  // 마법 저항력
	eMONSTERSTAT_CRICHANCE,   // 치명타 확률
	eMONSTERSTAT_CRIDAMAGE,  // 치명타 데미지
	eMONSTERSTAT_END
}

public enum eNPCSTAT // NPC 스텟
{
	eNPCSTAT_STR,	// 공격력
	eNPCSTAT_INT,	// 지능
	eNPCSTAT_DEF,	// 방어력
	eNPCSTAT_MEF,	// 마법저항력
	eNPCSTAT_END
}

public enum ePETSTAT	// 펫 스텟
{
	ePETSTAT_HP,	// 체력
	ePETSTAT_STR,	// 공격력
	ePETSTAT_INT,	// 지능
	ePETSTAT_HEAL,	// 치유력
	ePETSTAT_DEF,	// 방어력
	ePETSTAT_MEF,	// 마법저항력
	ePETSTAT_TIME,	// 쿨타임
	ePETSTAT_END
}


public enum eSKILL	// 스킬의 종류
{
	eSKILL_NOMAL, // 기본
	eSKILL_SPECIAL, // 특수
	eSKILL_HIGHLIGHT,    // 궁극기
	eSKILL_END
}

public enum eITEMTYPE	// 아이템 종류
{
	eITEMTYPE_ARMOR,    // 방어구
	eITEMTYPE_WEAPON,   // 무기
	eITEMTYPE_ACCESSORIES,  // 장신구
	eITEMTYPE_RUNE,		// 룬
	eITEMTYPE_POTION,   // 포션
	eITEMTYPE_BUF,		// 버프
	eITEMTYPE_END
}

public enum eITEMSTAT	// 아이템 스텟
{
	eITEMSTAT_HP,
	eITEMSTAT_ST,
	eITEMSTAT_STR,
	eITEMSTAT_INT, 
	eITEMSTAT_HEAL,
	eITEMSTAT_DEF,
	eITEMSTAT_MEF,
	eITEMSTAT_CRICHANCE,
	eITEMSTAT_CRIDAMAGE,
	eITEMSTAT_DEFPEN,
	eITEMSTAT_MEFPEN,
	eITEMSTAT_END
}

public enum ePOTIONSTAT // 포션
{
	ePOTIONSTAT_HP,
	ePOTIONSTAT_ST,
	ePOTIONSTAT_STR,
	ePOTIONSTAT_INT,
	ePOTIONSTAT_HEAL,
	ePOTIONSTAT_DEF,
	ePOTIONSTAT_MEF,
	ePOTIONSTAT_END
}

public enum eBUFSTAT // 버프
{
	eBUFSTAT_HP,
	eBUFSTAT_ST,
	eBUFSTAT_STR,
	eBUFSTAT_INT,
	eBUFSTAT_HEAL,
	eBUFSTAT_DEF,
	eBUFSTAT_MEF,
	eBUFSTAT_CRICHANCE,
	eBUFSTAT_CRIDAMAGE,
	eBUF_END
}

public enum eAI // AI시스템
{
	eAI_RESET,	// 생성
	eAI_SEARCH,	// 검색
	eAI_MOVE,	// 이동
	eAI_ATTACK,	// 공격
	eAI_DIE,	// 죽음
	eAI_END
}

public enum eSTAGE	// 스테이지 종류
{
	eSTAGE_LANDOFBEGINNINGS,    // 시초의 땅(튜토리얼)
	eSTAGE_CURSEDGARDEN,        // 저주받은 가덴(1스테이지)
	eSTAGE_END
}

public enum eSCENE	// 씬 종류
{
	eSCENE_MAIN,	// 메인
	eSCENE_LOBBY,	// 로비
	eSCENE_FIGHT,   // 전투
	eSCENE_PVPLobby,// PVP로비
	eSCENE_PVPFight,// PVP전투
	eSCENE_END
}

public enum eENCODING   // [kks][Language] : 파싱타입
{
	eDEFAULT,   // ANSI
	eUTF8,      // UTF
	eUNICODE,   // 유니코드
	END
}
