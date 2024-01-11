using System.Collections.Generic;
using UnityEngine;

public class AI_Monster : AI_Base
{
    int m_nIndex;
    public Transform targetTransform = null;   // 적이 플레이어를 추적할 때 사용
    Vector3 StartPos;   // 시작좌표
    Vector3 EndPos;     // 도착좌표
    float wanderSpeed;   // 평상시의 적의 속도
    float pursuitSpeed;  // 적이 플레이어를 추적하는 속도
    float currentSpeed;  // 앞의 둘 중에서 선택할 현재 속도를 설정
    List<PathNode> m_listPos = new List<PathNode>();

    public override void InitAI(Character _character, float _fCreateTime)    // 누구의 AI인지 모르기 때문에(초기화)
    {
        base.InitAI(_character, _fCreateTime);
        m_nIndex = 0;
        StartPos = m_Character.transform.position;
        wanderSpeed = 1f;
        pursuitSpeed = 3f;
    }
    public void SetListPos(List<PathNode> _PathNode)
    {
        m_listPos = _PathNode;
    }
    public override void SetRESET()  // 생성
    {
        currentSpeed = wanderSpeed;
        if ((StartPos - targetTransform.position).magnitude < 15f)
        {
            base.SetRESET();
        }
    }

    public override void SetSEARCH() // 검색
    {
        currentSpeed = wanderSpeed;
        EndPos = m_listPos[m_nIndex].m_PosNext.position;
        base.SetSEARCH();
    }
    public override void SetMOVE()   // 이동
    {

        Vector3 vec = m_Character.transform.position;
        if (vec.x < EndPos.x)
        {
            vec += Vector3.right * currentSpeed * Time.fixedDeltaTime;
        }
        else if (Mathf.Abs(vec.x - EndPos.x) < 0.3f)
        {

        }
        else
        {
            vec += Vector3.left * currentSpeed * Time.fixedDeltaTime;
        }

        if (vec.y < EndPos.y)
        {
            vec += Vector3.up * currentSpeed * Time.fixedDeltaTime;
        }
        else if (Mathf.Abs(vec.y - EndPos.y) < 0.3f)
        {

        }
        else
        {
            vec += Vector3.down * currentSpeed * Time.fixedDeltaTime;
        }
        m_Character.transform.position = vec;

        if ((vec - targetTransform.position).magnitude < 3f)
        {
            m_eAI = eAI.eAI_ATTACK; // 공격으로 변경
            return;
        }

        if ((vec - EndPos).magnitude < 1f)
        {
            int i = Random.Range(0, m_listPos.Count);
            while (i == m_nIndex)
            {
                i = Random.Range(0, m_listPos.Count);
            }
            m_nIndex = i;

            base.SetMOVE();
        }
    }
    public override void SetATTACK() // 공격   
    {
        currentSpeed = pursuitSpeed;
        EndPos = targetTransform.position;
        base.SetSEARCH();
    }
    public override void SetDIE()    // 죽음
    {
        base.SetDIE();
    }
}
