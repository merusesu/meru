using System.Collections.Generic;
using UnityEngine;

public class AI_Monster : AI_Base
{
    int m_nIndex;
    public Transform targetTransform = null;   // ���� �÷��̾ ������ �� ���
    Vector3 StartPos;   // ������ǥ
    Vector3 EndPos;     // ������ǥ
    float wanderSpeed;   // ������ ���� �ӵ�
    float pursuitSpeed;  // ���� �÷��̾ �����ϴ� �ӵ�
    float currentSpeed;  // ���� �� �߿��� ������ ���� �ӵ��� ����
    List<PathNode> m_listPos = new List<PathNode>();

    public override void InitAI(Character _character, float _fCreateTime)    // ������ AI���� �𸣱� ������(�ʱ�ȭ)
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
    public override void SetRESET()  // ����
    {
        currentSpeed = wanderSpeed;
        if ((StartPos - targetTransform.position).magnitude < 15f)
        {
            base.SetRESET();
        }
    }

    public override void SetSEARCH() // �˻�
    {
        currentSpeed = wanderSpeed;
        EndPos = m_listPos[m_nIndex].m_PosNext.position;
        base.SetSEARCH();
    }
    public override void SetMOVE()   // �̵�
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
            m_eAI = eAI.eAI_ATTACK; // �������� ����
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
    public override void SetATTACK() // ����   
    {
        currentSpeed = pursuitSpeed;
        EndPos = targetTransform.position;
        base.SetSEARCH();
    }
    public override void SetDIE()    // ����
    {
        base.SetDIE();
    }
}
