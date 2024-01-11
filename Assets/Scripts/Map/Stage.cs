using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 스테이지 정보만 보유
public class Stage : MonoBehaviour
{
    // 몬스터  (1~6마리)
    public List<Transform> MTRGRID; // 몬스터 스폰위치
    public List<MonsterPos> m_listPos;    // 몬스터 이동경로

    // 중간보스 (1~2마리)
    public List<Transform> SBTRGRID; // 중간보스 스폰위치
    public List<MonsterPos> m_SlistPos;    // 중간보스 이동경로

    // 최종보스 (1마리)
    public Transform BTRGRID; // 최종보스 스폰위치
    public MonsterPos m_BlistPos;    // 최종보스 이동경로

    public SafeZone SAFEZONE;   // 회복존
}
