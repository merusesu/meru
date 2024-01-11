using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class Monster
{
    public bool MonsterLive()   // 몬스터 생존여부(전투씬에서 처리)
    {
        if (0 == M_NowHPSTAT())
            return false;

        return true;
    }

    public int M_TotalSTAT(int _nIndex) // 몬스터 최대값 설정
    {
        return c_MonsterData.MonsterStat[_nIndex];
    }

    public int M_NowSTAT(int _nIndex) // 몬스터 현재값 설정
    {
        return M_TotalSTAT(_nIndex);
    }

    public int M_NowHPSTAT()    // 몬스터 현재 체력값 설정
    {
        return M_NowSTAT((int)eMONSTERSTAT.eMONSTERSTAT_HP) - c_MonsterData.Damage;
    }

    public void M_NunSkill(Player C_Player)
    {
        int m_Damage;
        m_Damage = M_StrDamage(C_Player) + M_IntDamage(C_Player);
        C_Player.c_PlayerData.Damage += m_Damage;
    }

    public void M_STSkill(Player C_Player)  // ST부족시 공격방법
    {
        int m_Damage;
        m_Damage = M_NowSTAT((int)eMONSTERSTAT.eMONSTERSTAT_STR) + M_NowSTAT((int)eMONSTERSTAT.eMONSTERSTAT_INT);
        C_Player.c_PlayerData.Damage += m_Damage;
    }

    public int M_StrDamage(Player C_Player) // 몬스터 공격력 피해
    {
        int i_Damage;
        i_Damage =
           // 공격력-방어력 또는 방어력이 높으면 0이들어감
           M_NowSTAT((int)eMONSTERSTAT.eMONSTERSTAT_STR) > C_Player.P_NowSTAT((int)ePLAYERSTAT.ePLAYERSTAT_DEF) ? M_NowSTAT((int)eMONSTERSTAT.eMONSTERSTAT_STR) - C_Player.P_NowSTAT((int)ePLAYERSTAT.ePLAYERSTAT_DEF) : 0;
        return i_Damage;
    }

    public int M_IntDamage(Player C_Player) // 몬스터 지능 피해
    {
        int i_Damage;
        i_Damage =
            // 공격력-방어력 또는 방어력이 높으면 0이들어감
            M_NowSTAT((int)eMONSTERSTAT.eMONSTERSTAT_INT) > C_Player.P_NowSTAT((int)ePLAYERSTAT.ePLAYERSTAT_MEF) ? M_NowSTAT((int)eMONSTERSTAT.eMONSTERSTAT_INT) - C_Player.P_NowSTAT((int)ePLAYERSTAT.ePLAYERSTAT_MEF) : 0;
        return i_Damage;
    }
}
