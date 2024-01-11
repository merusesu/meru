using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class Player 
{

    public override void Move()
    {

        base.Move();


        if (Input.GetKey(KeyCode.T))
        {
            m_nAni.SetTrigger("CubeMove");
        }
    }

    public override void LeftMove()
    {
        base.LeftMove();
    }

    public override void RightMove()
    {
        base.RightMove();
    }

    public override void UpMove()
    {
        base.UpMove();
    }

    public override void DownMove()
    {
        base.DownMove();
    }

}
