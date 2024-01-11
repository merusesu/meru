using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_MainMenu : MonoBehaviour
{
    public Text Input_PlayerName;
    public UI_CharacterChoice UI_PC;
    public GameObject Video;
    public GameObject Play_Button;
    public GameObject CheckName;
    public Button Start_Btn;
    bool b_Click = false;

    VideoMgr VIDEOMGR;
    // Start is called before the first frame update
    void Start()
    {
        VIDEOMGR = SharedObject.g_VidioMgr;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnBtnNewGame()  // 새로 시작 버튼
    {
        PlayerPrefs.DeleteAll();
        Play_Button.SetActive(false);
        CheckName.SetActive(true);
    }

    public void OnBtnLoadGame() // 불러오기 버튼
    {
        SharedObject.g_PlayerPrefsData.LoadFileData("D:DarkDices", "PlayerData");
        if (null==SharedObject.g_SceneMgr.m_Player.Name) return;
        //SharedObject.g_SceneMgr.GetPlayerData();
        Play_Button.SetActive(false);
        Start_Btn.gameObject.SetActive(true);
        Debug.Log("데이터를 로드합니다");
    }

    public void OnBtnQuit() // 나가기 버튼
    {
        Application.Quit();
    }

    public void OnBtnCheckName()    // 이름체크 버튼
    {
        SharedObject.g_SceneMgr.SetPlayer(Input_PlayerName.text);
        CheckName.SetActive(false);
        UI_PC.gameObject.SetActive(true);
        Start_Btn.gameObject.SetActive(true);
    }

    public void OnBtnStart() // 시작버튼
    {
        if (!b_Click)
        {
            b_Click = true;
            Video.SetActive(true);
            VIDEOMGR.VIDEOPlay();   // 비디오 플레이어
        }
        
    }

    private void OnApplicationQuit()
    {
        SharedObject.g_PlayerPrefsData.SaveFileData("D:DarkDices", "PlayerData");
    }

}
