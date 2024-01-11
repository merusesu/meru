using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    public enum eSTATE  // 움직임 상태
    {
        eSTATE_NONE,
        eSTATE_LEFTUPMOVE,
        eSTATE_LEFTDOWNMOVE,
        eSTATE_RIGHTUPMOVE,
        eSTATE_RIGHTDOWNMOVE,
        eSTATE_END
    }

    eSTATE m_eState = eSTATE.eSTATE_NONE;   // 상태

    public AI_Base m_AI = null;
    float m_fMoveSpeed = 5f;
    // 캐릭터 타입을 만들고 가상화를 시켜라
    private void Start()
    {

    }
    private void Update()
    {

    }

    private void FixedUpdate()    // 고정프레임일떄 업데이트
    {
        if (null != m_AI)   // AI가 있을때 상태를 실행
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

    public eSTATE State // 상태를 설정하는 함수
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





