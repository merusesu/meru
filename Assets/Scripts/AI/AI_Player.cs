using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI_Player : AI_Base
{
    public override void InitAI(Character _character, float _fCreateTime)    // ������ AI���� �𸣱� ������(�ʱ�ȭ)
    {
        base.InitAI(_character,_fCreateTime);
    }

    public override void SetRESET()  // ����
    {
        base.SetRESET();
    }

    public override void SetSEARCH() // �˻�
    {
        base.SetSEARCH();
    }
    public override void SetMOVE()   // �̵�
    {
        base.SetMOVE();
    }
    public override void SetATTACK() // ����   
    {
        base.SetATTACK();
    }
    public override void SetDIE()    // ����
    {
        base.SetDIE();
    }
}
