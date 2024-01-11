using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_1Deapth_Option : MonoBehaviour
{
    public Player_Data C_Player;
    public Text UserID;
    public Text TEXTINPUT;
    // Start is called before the first frame update
    void Start()
    {
        C_Player = SharedObject.g_SceneMgr.m_Player;
        if (null == C_Player)
            Debug.Log("UI_Lobby Character null");
        UserID.text = C_Player.Name;
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(TEXTINPUT.text);
    }

    public void OnBtnBack()
    {
        transform.gameObject.SetActive(false);
    }
}
