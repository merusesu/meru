using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    public enum eSTATE  // ������ ����
    {
        eSTATE_NONE,
        eSTATE_LEFTUPMOVE,
        eSTATE_LEFTDOWNMOVE,
        eSTATE_RIGHTUPMOVE,
        eSTATE_RIGHTDOWNMOVE,
        eSTATE_END
    }

    eSTATE m_eState = eSTATE.eSTATE_NONE;   // ����

    public AI_Base m_AI = null;
    float m_fMoveSpeed = 5f;
    // ĳ���� Ÿ���� ����� ����ȭ�� ���Ѷ�
    private void Start()
    {

    }
    private void Update()
    {

    }

    private void FixedUpdate()    // �����������ϋ� ������Ʈ
    {
        if (null != m_AI)   // AI�� ������ ���¸� ����
            m_AI.UpdateState();

        switch (m_eState)
        {
            case eSTATE.eSTATE_LEFTUPMOVE:
                LeftMove();
                UpMove();
                break;
            case eSTATE.eSTATE_LEFTDOWNMOVE:
                LeftMove();
                DownMove();
                break;
            case eSTATE.eSTATE_RIGHTUPMOVE:
                RightMove();
                UpMove();
                break;
            case eSTATE.eSTATE_RIGHTDOWNMOVE:
                RightMove(); 
                DownMove();
                break;
        }
    }

    public virtual void Init()
    {

    }

    public eSTATE State // ���¸� �����ϴ� �Լ�
    {
        set { m_eState = value; }
    }

    public virtual void Move()
    {
        if (Input.GetKey(KeyCode.A))
        {
            Vector3 vec = this.transform.position;
            vec += Vector3.left * m_fMoveSpeed * Time.deltaTime;
            this.transform.position = vec;
        }

        if (Input.GetKey(KeyCode.D))
        {
            Vector3 vec = this.transform.position;
            vec += Vector3.right * m_fMoveSpeed * Time.deltaTime;
            this.transform.position = vec;
        }

        if (Input.GetKey(KeyCode.W))
        {
            Vector3 vec = this.transform.position;
            vec += Vector3.up * m_fMoveSpeed * Time.deltaTime;
            this.transform.position = vec;
        }

        if (Input.GetKey(KeyCode.S))
        {
            Vector3 vec = this.transform.position;
            vec += Vector3.down * m_fMoveSpeed * Time.deltaTime;
            this.transform.position = vec;
        }
    }

    public virtual void LeftMove()
    {
        Vector3 vec = this.transform.position;
        vec += Vector3.left * (m_fMoveSpeed/2) * Time.deltaTime;
        this.transform.position = vec;
    }

    public virtual void RightMove()
    {
        Vector3 vec = this.transform.position;
        vec += Vector3.right * (m_fMoveSpeed/2) * Time.deltaTime;
        this.transform.position = vec;
    }

    public virtual void UpMove()
    {
        Vector3 vec = this.transform.position;
        vec += Vector3.up * (m_fMoveSpeed/2) * Time.deltaTime;
        this.transform.position = vec;
    }

    public virtual void DownMove()
    {
        Vector3 vec = this.transform.position;
        vec += Vector3.down * (m_fMoveSpeed / 2) * Time.deltaTime;
        this.transform.position = vec;
    }
}





