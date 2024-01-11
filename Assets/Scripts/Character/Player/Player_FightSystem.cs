using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class Player 
{
    // 플레이어 최대값 설정
    public int P_TotalSTAT(int _nIndex)
    {
        return c_PlayerData.PlayerStat[_nIndex] + c_ItemData.Itemstat[_nIndex];
    }

    // 플레이어 현재값 설정
    public int P_NowSTAT(int _nIndex)
    {
        return P_TotalSTAT(_nIndex) + c_buf.Itemstat[_nIndex];
    }

    // 플레이어 현재 체력값 설정
    public int P_NowHPSTAT()
    {
        return P_NowSTAT((int)ePLAYERSTAT.ePLAYERSTAT_HP) + c_PlayerData.Shiled - c_PlayerData.Damage;
    }

    public void PlayerInit()    // 체력 초기화
    {
        c_PlayerData.Damage = 0;
        c_PlayerData.Shiled = 0;
    }

    // 플레이어 스테미너 현재값 설정
    public int P_NowSTSTAT()
    {
        return P_NowSTAT((int)ePLAYERSTAT.ePLAYERSTAT_ST) - c_PlayerData.STUsed;
    }

    public int P_StrDamage(Monster C_Monster) // 플레이어 공격력 피해
    {
        int i_Damage;
        i_Damage =
          // 공격력-방어력 또는 방어력이 높으면 0이들어감
          P_NowSTAT((int)ePLAYERSTAT.ePLAYERSTAT_STR) > C_Monster.M_TotalSTAT((int)eMONSTERSTAT.eMONSTERSTAT_DEF) ? P_NowSTAT((int)ePLAYERSTAT.ePLAYERSTAT_STR) - C_Monster.M_TotalSTAT((int)eMONSTERSTAT.eMONSTERSTAT_DEF) : 1;
        return i_Damage;
    }

    public int P_IntDamage(Monster C_Monster) // 플레이어 지능 피해
    {
        int i_Damage;
        i_Damage =
        // 지능-마법저항력 또는 마법저항력이 높으면 0이들어감
        P_NowSTAT((int)ePLAYERSTAT.ePLAYERSTAT_INT) > C_Monster.M_TotalSTAT((int)eMONSTERSTAT.eMONSTERSTAT_MEF) ? P_NowSTAT((int)ePLAYERSTAT.ePLAYERSTAT_INT) - C_Monster.M_TotalSTAT((int)eMONSTERSTAT.eMONSTERSTAT_MEF) : 1;
        return i_Damage;
    }

    public int P_HealDamage() // 플레이어 치유력 피해
    {
        int i_Damage;
        i_Damage =
             // 치유력은 1/3의 피해로 들어감
             P_NowSTAT((int)ePLAYERSTAT.ePLAYERSTAT_HEAL) / 3;
        return i_Damage;
    }

    public void P_NunSkill(Monster C_Monster)  // 기본스킬
    {
        int Damage;
        if (Playerjob >= 0 && Playerjob <= 3)
        {
            Damage = P_StrDamage(C_Monster);
        }
        else if (Playerjob == 4 || Playerjob == 6)
        {
            Damage = P_IntDamage(C_Monster);
        }
        else if (Playerjob == 5)
        {
            Damage = (P_StrDamage(C_Monster) / 2) + (P_IntDamage(C_Monster) / 2);
        }
        else
        {
            Damage = P_HealDamage();
        }
        if (Random.Range(0, 100) < P_NowSTAT((int)ePLAYERSTAT.ePLAYERSTAT_CRICHANCE))
        {
            Damage = (int)((float)Damage * ((float)P_NowSTAT((int)ePLAYERSTAT.ePLAYERSTAT_CRIDAMAGE) / 100));
        }
        C_Monster.c_MonsterData.Damage += Damage;
    }

    public void P_SpcSkill(Monster C_Monster)   // 특수공격
    {
        switch (Playerjob)
        {
            case (int)ePLAYER.ePLAYER_KNIGHT:
                {
                    int _nIndex = c_PlayerData.PlayerStat[(int)ePLAYERSTAT.ePLAYERSTAT_STR];
                    c_PlayerData.PlayerStat[(int)ePLAYERSTAT.ePLAYERSTAT_STR] += _nIndex / 2;
                    int Damage = P_StrDamage(C_Monster);
                    if (Random.Range(0, 100) < P_NowSTAT((int)ePLAYERSTAT.ePLAYERSTAT_CRICHANCE))
                    {
                        Damage = (int)((float)Damage * ((float)P_NowSTAT((int)ePLAYERSTAT.ePLAYERSTAT_CRIDAMAGE) / 100));
                    }
                    c_PlayerData.PlayerStat[(int)ePLAYERSTAT.ePLAYERSTAT_STR] -= _nIndex / 2;
                    C_Monster.c_MonsterData.Damage += Damage;
                    return;
                }
            case (int)ePLAYER.ePLAYER_WARRIOR:
                {
                    int _nIndex = c_ItemData.Itemstat[(int)eITEMSTAT.eITEMSTAT_STR];
                    c_ItemData.Itemstat[(int)eITEMSTAT.eITEMSTAT_STR] += _nIndex / 2;
                    int Damage = P_StrDamage(C_Monster);
                    if (Random.Range(0, 100) < P_NowSTAT((int)ePLAYERSTAT.ePLAYERSTAT_CRICHANCE))
                    {
                        Damage = (int)((float)Damage * ((float)P_NowSTAT((int)ePLAYERSTAT.ePLAYERSTAT_CRIDAMAGE) / 100));
                    }
                    c_ItemData.Itemstat[(int)eITEMSTAT.eITEMSTAT_STR] -= _nIndex / 2;
                    C_Monster.c_MonsterData.Damage += Damage;
                    return;
                }
            case (int)ePLAYER.ePLAYER_BERSERKER:
                {
                    int _nIndex = c_PlayerData.PlayerStat[(int)ePLAYERSTAT.ePLAYERSTAT_CRIDAMAGE];
                    c_PlayerData.PlayerStat[(int)ePLAYERSTAT.ePLAYERSTAT_CRIDAMAGE] += _nIndex / 2;
                    int Damage = P_StrDamage(C_Monster);
                    if (Random.Range(0, 100) < P_NowSTAT((int)ePLAYERSTAT.ePLAYERSTAT_CRICHANCE))
                    {
                        Damage = (int)((float)Damage * ((float)P_NowSTAT((int)ePLAYERSTAT.ePLAYERSTAT_CRIDAMAGE) / 100));
                    }
                    c_PlayerData.PlayerStat[(int)ePLAYERSTAT.ePLAYERSTAT_CRIDAMAGE] -= _nIndex / 2;
                    C_Monster.c_MonsterData.Damage += Damage;
                    return;
                }
            case (int)ePLAYER.ePLAYER_PALADIN:
                {
                    int _nIndex = c_PlayerData.PlayerStat[(int)ePLAYERSTAT.ePLAYERSTAT_MEF];
                    c_PlayerData.Shiled += _nIndex;
                    return;
                }
            case (int)ePLAYER.ePLAYER_WIZARD:
                {
                    int _nIndex = c_PlayerData.PlayerStat[(int)ePLAYERSTAT.ePLAYERSTAT_INT];
                    c_PlayerData.PlayerStat[(int)ePLAYERSTAT.ePLAYERSTAT_INT] += _nIndex / 2;
                    int Damage = P_IntDamage(C_Monster);
                    if (Random.Range(0, 100) < P_NowSTAT((int)ePLAYERSTAT.ePLAYERSTAT_CRICHANCE))
                    {
                        Damage = (int)((float)Damage * ((float)P_NowSTAT((int)ePLAYERSTAT.ePLAYERSTAT_CRIDAMAGE) / 100));
                    }
                    c_PlayerData.PlayerStat[(int)ePLAYERSTAT.ePLAYERSTAT_INT] -= _nIndex / 2;
                    C_Monster.c_MonsterData.Damage += Damage;
                    return;
                }
            case (int)ePLAYER.ePLAYER_ROGUE:
                {
                    int Damage = P_StrDamage(C_Monster) + P_IntDamage(C_Monster);
                    Damage = (int)((float)Damage * 1.5);
                    if (Random.Range(0, 100) < P_NowSTAT((int)ePLAYERSTAT.ePLAYERSTAT_CRICHANCE))
                    {
                        Damage = (int)((float)Damage * ((float)P_NowSTAT((int)ePLAYERSTAT.ePLAYERSTAT_CRIDAMAGE) / 100));
                    }
                    C_Monster.c_MonsterData.Damage += Damage;
                    return;
                }
            case (int)ePLAYER.ePLAYER_MAGICIAN:
                {
                    int _nIndex = c_PlayerData.PlayerStat[(int)ePLAYERSTAT.ePLAYERSTAT_INT];
                    c_PlayerData.Shiled += _nIndex;
                    return;
                }
            case (int)ePLAYER.ePLAYER_PRIST:
                {
                    int _nIndex = c_PlayerData.PlayerStat[(int)ePLAYERSTAT.ePLAYERSTAT_HEAL];
                    c_PlayerData.Damage -= _nIndex;
                    if (c_PlayerData.Damage < 0) { c_PlayerData.Damage = 0; }
                    return;
                }
        }
    }

    public void P_HilSkill(Monster C_Monster)   // 궁극기
    {
        switch (Playerjob)
        {
            case (int)ePLAYER.ePLAYER_KNIGHT:
                {
                    int _nIndex = c_PlayerData.PlayerStat[(int)ePLAYERSTAT.ePLAYERSTAT_STR];
                    c_PlayerData.Shiled += _nIndex * 2;
                    return;
                }
            case (int)ePLAYER.ePLAYER_WARRIOR:
                {
                    int Damage = P_StrDamage(C_Monster) * 2;
                    if (Random.Range(0, 100) < P_NowSTAT((int)ePLAYERSTAT.ePLAYERSTAT_CRICHANCE))
                    {
                        Damage = (int)((float)Damage * ((float)P_NowSTAT((int)ePLAYERSTAT.ePLAYERSTAT_CRIDAMAGE) / 100));
                    }
                    C_Monster.c_MonsterData.Damage += Damage;
                    return;
                }
            case (int)ePLAYER.ePLAYER_BERSERKER:
                {
                    int Damage = P_StrDamage(C_Monster);
                    Damage = (int)((float)Damage * ((float)P_NowSTAT((int)ePLAYERSTAT.ePLAYERSTAT_CRIDAMAGE) / 100));
                    C_Monster.c_MonsterData.Damage += Damage;
                    return;
                }
            case (int)ePLAYER.ePLAYER_PALADIN:
                {
                    int _nIndex = c_PlayerData.PlayerStat[(int)ePLAYERSTAT.ePLAYERSTAT_MEF];
                    c_PlayerData.Damage -= _nIndex;
                    if (c_PlayerData.Damage < 0) { c_PlayerData.Damage = 0; }
                    return;
                }
            case (int)ePLAYER.ePLAYER_WIZARD:
                {
                    int Damage = P_IntDamage(C_Monster) * 2;
                    if (Random.Range(0, 100) < P_NowSTAT((int)ePLAYERSTAT.ePLAYERSTAT_CRICHANCE))
                    {
                        Damage = (int)((float)Damage * ((float)P_NowSTAT((int)ePLAYERSTAT.ePLAYERSTAT_CRIDAMAGE) / 100));
                    }
                    C_Monster.c_MonsterData.Damage += Damage;
                    return;
                }
            case (int)ePLAYER.ePLAYER_ROGUE:
                {
                    int time = 2;
                    while (time != 0)
                    {
                        int Damage = P_StrDamage(C_Monster) + P_IntDamage(C_Monster);
                        if (Random.Range(0, 100) < P_NowSTAT((int)ePLAYERSTAT.ePLAYERSTAT_CRICHANCE))
                        {
                            Damage = (int)((float)Damage * ((float)P_NowSTAT((int)ePLAYERSTAT.ePLAYERSTAT_CRIDAMAGE) / 100));
                        }
                        C_Monster.c_MonsterData.Damage += Damage;
                        time--;
                    }
                    return;
                }
            case (int)ePLAYER.ePLAYER_MAGICIAN:
                {
                    int _nIndex = (C_Monster.M_NowSTAT((int)eMONSTERSTAT.eMONSTERSTAT_STR) > P_NowSTAT((int)ePLAYERSTAT.ePLAYERSTAT_DEF) ?
                        C_Monster.M_NowSTAT((int)eMONSTERSTAT.eMONSTERSTAT_STR) - P_NowSTAT((int)ePLAYERSTAT.ePLAYERSTAT_DEF) : 0) +
                        (C_Monster.M_NowSTAT((int)eMONSTERSTAT.eMONSTERSTAT_INT) > P_NowSTAT((int)ePLAYERSTAT.ePLAYERSTAT_MEF) ?
                        C_Monster.M_NowSTAT((int)eMONSTERSTAT.eMONSTERSTAT_INT) - P_NowSTAT((int)ePLAYERSTAT.ePLAYERSTAT_MEF) : 0);
                    c_PlayerData.Damage -= _nIndex;
                    return;
                }
            case (int)ePLAYER.ePLAYER_PRIST:
                {
                    c_PlayerData.Damage = 0;
                    return;
                }
        }
    }


}
