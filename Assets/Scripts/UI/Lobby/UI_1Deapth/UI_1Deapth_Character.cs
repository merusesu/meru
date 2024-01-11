using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_1Deapth_Character : MonoBehaviour
{
    public Player c_Player;
    public Text m_nName, m_nJob;
    public Text m_nHPName, m_nTotalHP, m_nNowHP;
    public Text m_nSTName, m_nTotalST, m_nNowST;
    public Slider SLIDERHP, SLIDERST;
    public Text m_nSTRName, m_nTotalSTR, m_nNowSTR;
    public Text m_nINTName, m_nTotalINT, m_nNowINT;
    public Text m_nHEALName, m_nTotalHEAL, m_nNowHEAL;
    public Text m_nDEFName, m_nTotalDEF, m_nNowDEF;
    public Text m_nMEFName, m_nTotalMEF, m_nNowMEF;
    public Text m_nCRICANCEName, m_nTotalCRICANCE, m_nNowCRICANCE;
    public Text m_nCRIDAMAGEName, m_nTotalCRIDAMAGE, m_nNowCRIDAMAGE;
    public Text m_nITEMPName, m_nItemPDEF, m_nItemPMEF;

    int TotalHP, NowHP, TotalST, NowST;

    // Start is called before the first frame update
    void Start()
    {
        if (null == c_Player)
            Debug.Log("UI_Lobby Character null");   
        TotalHP = c_Player.P_TotalSTAT((int)ePLAYERSTAT.ePLAYERSTAT_HP);
        TotalST = c_Player.P_TotalSTAT((int)ePLAYERSTAT.ePLAYERSTAT_ST);
        NowHP = c_Player.P_NowHPSTAT();
        NowST = c_Player.P_NowSTSTAT();
    }
    
    // Update is called once per frame
    void Update()
    {
        NowHP = c_Player.P_NowHPSTAT();
        NowST = c_Player.P_NowSTSTAT();
        // �̸��� ����
        m_nName.text = c_Player.c_PlayerData.Name;
        m_nJob.text = c_Player.c_PlayerData.Job;

        // ü�°� ���׹̳�
        SLIDERHP.value = (float)NowHP / (float)TotalHP;
        SLIDERST.value = (float)NowST / (float)TotalST;

        m_nHPName.text = "ü��";
        m_nTotalHP.text = TotalHP.ToString();
        m_nNowHP.text = c_Player.P_NowHPSTAT().ToString();

        m_nSTName.text = "���׹̳�";
        m_nTotalST.text = TotalST.ToString();
        m_nNowST.text = NowST.ToString();

        m_nSTRName.text = "���ݷ�";
        m_nTotalSTR.text = c_Player.P_TotalSTAT((int)ePLAYERSTAT.ePLAYERSTAT_STR).ToString();
        m_nNowSTR.text = c_Player.P_NowSTAT((int)ePLAYERSTAT.ePLAYERSTAT_STR).ToString();

        m_nINTName.text = "����";
        m_nTotalINT.text = c_Player.P_TotalSTAT((int)ePLAYERSTAT.ePLAYERSTAT_INT).ToString();
        m_nNowINT.text = c_Player.P_NowSTAT((int)ePLAYERSTAT.ePLAYERSTAT_INT).ToString();

        m_nHEALName.text = "ġ����";
        m_nTotalHEAL.text = c_Player.P_TotalSTAT((int)ePLAYERSTAT.ePLAYERSTAT_HEAL).ToString();
        m_nNowHEAL.text = c_Player.P_NowSTAT((int)ePLAYERSTAT.ePLAYERSTAT_HEAL).ToString();

        m_nDEFName.text = "����";
        m_nTotalDEF.text = c_Player.P_TotalSTAT((int)ePLAYERSTAT.ePLAYERSTAT_DEF).ToString();
        m_nNowDEF.text = c_Player.P_NowSTAT((int)ePLAYERSTAT.ePLAYERSTAT_DEF).ToString();

        m_nMEFName.text = "�������׷�";
        m_nTotalMEF.text = c_Player.P_TotalSTAT((int)ePLAYERSTAT.ePLAYERSTAT_MEF).ToString();
        m_nNowMEF.text = c_Player.P_NowSTAT((int)ePLAYERSTAT.ePLAYERSTAT_MEF).ToString();

        m_nCRICANCEName.text = "ġ��Ÿ Ȯ��";
        m_nTotalCRICANCE.text = c_Player.P_TotalSTAT((int)ePLAYERSTAT.ePLAYERSTAT_CRICHANCE).ToString();
        m_nNowCRICANCE.text = c_Player.P_NowSTAT((int)ePLAYERSTAT.ePLAYERSTAT_CRICHANCE).ToString();

        m_nCRIDAMAGEName.text = "ġ��Ÿ ������";
        m_nTotalCRIDAMAGE.text = c_Player.P_TotalSTAT((int)ePLAYERSTAT.ePLAYERSTAT_CRIDAMAGE).ToString();
        m_nNowCRIDAMAGE.text = c_Player.P_NowSTAT((int)ePLAYERSTAT.ePLAYERSTAT_CRIDAMAGE).ToString();

        m_nITEMPName.text = "��/�� �����";
        m_nItemPDEF.text = c_Player.c_ItemData.Itemstat[(int)eITEMSTAT.eITEMSTAT_DEFPEN].ToString();
        m_nItemPMEF.text = c_Player.c_ItemData.Itemstat[(int)eITEMSTAT.eITEMSTAT_MEFPEN].ToString();
    }
    public void OnBtnBack()
    {
        transform.gameObject.SetActive(false);
    }
}
