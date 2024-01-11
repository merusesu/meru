using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SafeZone : MonoBehaviour
{
    public Vector2 ColliderSize;
    public LayerMask whatISLayer;

    public bool b_Heal;

    private void Start()
    {
        b_Heal = false;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(transform.position, ColliderSize);
    }

    private void Update()
    {
        Collier();
    }

    private void Collier()
    {
        Collider2D hit = Physics2D.OverlapBox(transform.position, ColliderSize, 0, whatISLayer);
        if (hit == null) return;
        if (hit.tag == "Player" && b_Heal == false) 
        {
            b_Heal = true;  // 회복불가
        }
    }
}
