using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class UI_CharacterChoice : MonoBehaviour
{
    public UI_PlayerCharacter[] PC_Prefap;   // Ŭ�а�ü������
    public Table_PlayerBouns T_Player;  // �÷��̾� ���̺�
    int m_nIndex = 0;   // �ߺ�����

    bool[] m_boj = new bool[(int)ePLAYER.ePLAYER_END];  // ������ ����
    // Start is called before the first frame update
    void Start()
    {
        T_Player = SharedObject.g_TableMgr.m_PlayerBouns;
        for (int i = 0; i < T_Player.m_Dictionary.Count; i++)
        {
            PC_Prefap[i].SetText(T_Player.m_Dictionary[i].m_strSelect);
        }
        m_boj[(int)ePLAYER.ePLAYER_KNIGHT] = true;
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    public void OnToogleBtn(int _nIndex)
    {
        if (m_nIndex== _nIndex) return; // �ߺ�����
        m_boj[_nIndex] = !m_boj[_nIndex];
        m_boj[m_nIndex] = false;
        m_nIndex = _nIndex;
    }

    public void BntPC()
    {
       for(int i = 0; i < m_boj.Length; i++)
        {
            if (m_boj[i] == true)
            {
                SharedObject.g_SceneMgr.SetPlayerJob(SharedObject.g_SceneMgr.m_Player, i);  // �÷��̾� ����
                SharedObject.g_PlayerPrefsData.SaveFileData("D:DarkDices", "PlayerData");
                Debug.Log("������ ����");
                this.gameObject.SetActive(false);
            }
        }
    }
}
