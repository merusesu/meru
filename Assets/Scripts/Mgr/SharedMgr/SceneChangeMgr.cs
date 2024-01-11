using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChangeMgr : MonoBehaviour
{
    string[] m_nScene = { "Main", "Lobby", "Fight", "PVPLobby", "PVPFIght" };

    void Awake()
    {
        if (SharedObject.g_ScenechangeMgr == null)    // 이 씬으로 다시돌아올 경우 사용
        {
            SharedObject.g_ScenechangeMgr = this;

            DontDestroyOnLoad(gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SceneChange(eSCENE _e)
    {
        SceneManager.LoadScene(m_nScene[(int)_e]);
        SharedObject.g_SceneMgr.m_nSceen = (int)_e; // 현재씬을 알려줌
    }

}
