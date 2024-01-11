using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Lobby : MonoBehaviour
{
    public UI_1Deapth_Character UICHARACTER;
    public UI_1Deapth_Bag UIBAG;
    public UI_1Deapth_Rune_Bag UIRUNEBAG;
    public UI_1Deapth_Setting UISETTING;
    public UI_1Deapth_Option UIOPTION;
    public Transform PlayerTransform;   // 플레이어 위치

    bool[] m_boj = new bool[(int)eMENU.eMENU_END];  // 끝까지 생성
    // Start is called before the first frame update
    void Start()
    {
        m_boj[(int)eMENU.eMENU_CHARACTER] = false;
    }

    // Update is called once per frame
    void Update()
    {
      
    }
    public void OnBtnCharacter()
    {
        UICHARACTER.gameObject.SetActive(true);
    }
    public void OnBntBag() {
       UIBAG.gameObject.SetActive(true);
    }
    public void OnBNTRuneBag()
    {
       UIRUNEBAG.gameObject.SetActive(true);
    }
    public void OnBNTSetting()
    {
       UISETTING.gameObject.SetActive(true);
    }
    public void OnBNTOption()
    {
        UIOPTION.gameObject.SetActive(true);
    }
    public void OnBntPVP()
    {
        SharedObject.g_SceneMgr.PlayerNowPos = PlayerTransform.position;
        SharedObject.g_ScenechangeMgr.SceneChange(eSCENE.eSCENE_PVPLobby);
    }
    public void OnBtnBack()
    {
        transform.gameObject.SetActive(false);
    }

    //public void OnToogleBtn(int _nIndex)
    //{
    //    m_boj[_nIndex] = !m_boj[_nIndex];

    //    switch ((eMENU)_nIndex)
    //    {
    //        case eMENU.eMENU_CHARACTER:
    //            {
    //                UICHARACTER.gameObject.SetActive(m_boj[_nIndex]);
    //            }
    //            break;
    //        case eMENU.eMENU_BAG:
    //            {
    //                UIBAG.gameObject.SetActive(m_boj[_nIndex]);
    //            }
    //            break;
    //        case eMENU.eMENU_RUNEBAG:
    //            {
    //                UIRUNEBAG.gameObject.SetActive(m_boj[_nIndex]);
    //            }
    //            break;
    //        case eMENU.eMENU_SETTING:
    //            {
    //                UISETTING.gameObject.SetActive(m_boj[_nIndex]);
    //            }
    //            break;
    //    }
    //}
}
