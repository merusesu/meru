using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public partial class Monster : Character
{
    Vector2 ColliderSize;

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(transform.position,ColliderSize);
    }

    private void Collier()
    {
        Collider2D hit = Physics2D.OverlapBox(transform.position, ColliderSize, 0);
        if (hit.tag == "Player")
        {
            SharedObject.g_SceneMgr.m_nMonsterNumber = c_MonsterData.Number;   // 몬스터 번호를 넘겨줌
            SharedObject.g_SceneMgr.PlayerNowPos = hit.gameObject.transform.position;   // 플레이어 위치정보를 넘겨줌
            SharedObject.g_ScenechangeMgr.SceneChange(eSCENE.eSCENE_FIGHT);
        }
    }

   
}
