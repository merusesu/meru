using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_ItemBuy : MonoBehaviour
{
    Player_Data c_PlayerData;
    int ItemMoney;      // 아이템 가격
    int PotionMoney;    // 포션 가격
    public UI_Store UISTORE;
    public Text ItemBuy, PotionBuy;
    public GameObject ChoseItem;    // 아이템 확인창
    public UI_Bag_Item CheckItem;   // 나온 아이템
    bool b_ItemBuy = false; // 아이템을 구매했는지 확인
    
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
        ItemBuy.text = ItemMoney.ToString() + " 원";
        PotionBuy.text = PotionMoney.ToString() + " 원";
    }

    public void ItemBuy_Btn()   // 아이템 구매
    {
        if (b_ItemBuy) return;
        if (c_PlayerData.Money < ItemMoney) return;
        else { SharedObject.g_SceneMgr.SpendMoney(c_PlayerData, ItemMoney); }
        int i = Random.Range((int)eITEMTYPE.eITEMTYPE_ARMOR, (int)eITEMTYPE.eITEMTYPE_RUNE); // 방어구,무기,장신구중 랜덤선택
        SharedObject.g_SceneMgr.ItemChoose(i);
        Item_Data BuyItem = SharedObject.g_SceneMgr.m_ItemData;
        SharedObject.g_SceneMgr.m_UsedItem.Add(BuyItem); // 구매한아이템 저장
        SharedObject.g_SceneMgr.ItemSort();
        for (int j = 0; j < (int)eITEMSTAT.eITEMSTAT_END; j++)   // 아이템을 적용시킴
        {
            SharedObject.g_SceneMgr.m_PlayerItem.Itemstat[j] += BuyItem.Itemstat[j];
        }
        CheckItem.SetItem(BuyItem);
        ChoseItem.SetActive(true);
        b_ItemBuy = true;
    }

    public void PotionBuy_Btn() // 포션구매
    {
        if (b_ItemBuy) return;
        if (c_PlayerData.Money < PotionMoney) return;
        else { SharedObject.g_SceneMgr.SpendMoney(c_PlayerData, PotionMoney); }
        SharedObject.g_SceneMgr.ItemChoose((int)eITEMTYPE.eITEMTYPE_POTION);    // 포션구매
        Item_Data BuyItem = SharedObject.g_SceneMgr.m_ItemData;
        SharedObject.g_SceneMgr.PotionSort(BuyItem); // 구매한 아이템을 처리
        CheckItem.SetItem(BuyItem);
        ChoseItem.SetActive(true);
        b_ItemBuy = true;
    }

    public void Exit_Btn()  // 나가기
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
