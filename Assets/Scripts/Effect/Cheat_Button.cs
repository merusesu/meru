using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cheat_Button : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void Cheat_Btn()
    {
        SharedObject.g_SceneMgr.m_Player.PlayerStat[(int)ePLAYERSTAT.ePLAYERSTAT_STR] += 100;
    }
}
