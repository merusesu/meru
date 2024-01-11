using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_ItemBuy : MonoBehaviour
{
    Player_Data c_PlayerData;
    int ItemMoney;      // ������ ����
    int PotionMoney;    // ���� ����
    public UI_Store UISTORE;
    public Text ItemBuy, PotionBuy;
    public GameObject ChoseItem;    // ������ Ȯ��â
    public UI_Bag_Item CheckItem;   // ���� ������
    bool b_ItemBuy = false; // �������� �����ߴ��� Ȯ��
    
    // Start is called before the first frame update
    void Start()
    {
        c_PlayerData = SharedObject.g_SceneMgr.m_Player;
        StageStore(SharedObject.g_SceneMgr.m_nStageID);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StageStore(int _nIndex)
    {
        ItemMoney = SharedObject.g_TableMgr.m_Stage.m_Dictionary[_nIndex].m_nItemMoney;
        PotionMoney = SharedObject.g_TableMgr.m_Stage.m_Dictionary[_nIndex].m_nPotionMoney;
        ItemBuy.text = ItemMoney.ToString() + " ��";
        PotionBuy.text = PotionMoney.ToString() + " ��";
    }

    public void ItemBuy_Btn()   // ������ ����
    {
        if (b_ItemBuy) return;
        if (c_PlayerData.Money < ItemMoney) return;
        else { SharedObject.g_SceneMgr.SpendMoney(c_PlayerData, ItemMoney); }
        int i = Random.Range((int)eITEMTYPE.eITEMTYPE_ARMOR, (int)eITEMTYPE.eITEMTYPE_RUNE); // ��,����,��ű��� ��������
        SharedObject.g_SceneMgr.ItemChoose(i);
        Item_Data BuyItem = SharedObject.g_SceneMgr.m_ItemData;
        SharedObject.g_SceneMgr.m_UsedItem.Add(BuyItem); // �����Ѿ����� ����
        SharedObject.g_SceneMgr.ItemSort();
        for (int j = 0; j < (int)eITEMSTAT.eITEMSTAT_END; j++)   // �������� �����Ŵ
        {
            SharedObject.g_SceneMgr.m_PlayerItem.Itemstat[j] += BuyItem.Itemstat[j];
        }
        CheckItem.SetItem(BuyItem);
        ChoseItem.SetActive(true);
        b_ItemBuy = true;
    }

    public void PotionBuy_Btn() // ���Ǳ���
    {
        if (b_ItemBuy) return;
        if (c_PlayerData.Money < PotionMoney) return;
        else { SharedObject.g_SceneMgr.SpendMoney(c_PlayerData, PotionMoney); }
        SharedObject.g_SceneMgr.ItemChoose((int)eITEMTYPE.eITEMTYPE_POTION);    // ���Ǳ���
        Item_Data BuyItem = SharedObject.g_SceneMgr.m_ItemData;
        SharedObject.g_SceneMgr.PotionSort(BuyItem); // ������ �������� ó��
        CheckItem.SetItem(BuyItem);
        ChoseItem.SetActive(true);
        b_ItemBuy = true;
    }

    public void Exit_Btn()  // ������
    {
        transform.gameObject.SetActive(false);
        UISTORE.gameObject.SetActive(true);
    }

    public void Check_Btn()
    {
        ChoseItem.SetActive(false);
        b_ItemBuy = false;
    }

}
