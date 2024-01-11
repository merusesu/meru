using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI_Player : AI_Base
{
    public override void InitAI(Character _character, float _fCreateTime)    // 누구의 AI인지 모르기 때문에(초기화)
    {
        base.InitAI(_character,_fCreateTime);
    }

    public override void SetRESET()  // 생성
    {
        base.SetRESET();
    }

    public override void SetSEARCH() // 검색
    {
        base.SetSEARCH();
    }
    public override void SetMOVE()   // 이동
    {
        base.SetMOVE();
    }
    public override void SetATTACK() // 공격   
    {
        base.SetATTACK();
    }
    public override void SetDIE()    // 죽음
    {
        base.SetDIE();
    }
}
