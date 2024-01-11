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

    public void OnBtnNewGame()  // ���� ���� ��ư
    {
        PlayerPrefs.DeleteAll();
        Play_Button.SetActive(false);
        CheckName.SetActive(true);
    }

    public void OnBtnLoadGame() // �ҷ����� ��ư
    {
        SharedObject.g_PlayerPrefsData.LoadFileData("D:DarkDices", "PlayerData");
        if (null==SharedObject.g_SceneMgr.m_Player.Name) return;
        //SharedObject.g_SceneMgr.GetPlayerData();
        Play_Button.SetActive(false);
        Start_Btn.gameObject.SetActive(true);
        Debug.Log("�����͸� �ε��մϴ�");
    }

    public void OnBtnQuit() // ������ ��ư
    {
        Application.Quit();
    }

    public void OnBtnCheckName()    // �̸�üũ ��ư
    {
        SharedObject.g_SceneMgr.SetPlayer(Input_PlayerName.text);
        CheckName.SetActive(false);
        UI_PC.gameObject.SetActive(true);
        Start_Btn.gameObject.SetActive(true);
    }

    public void OnBtnStart() // ���۹�ư
    {
        if (!b_Click)
        {
            b_Click = true;
            Video.SetActive(true);
            VIDEOMGR.VIDEOPlay();   // ���� �÷��̾�
        }
        
    }

    private void OnApplicationQuit()
    {
        SharedObject.g_PlayerPrefsData.SaveFileData("D:DarkDices", "PlayerData");
    }

}
