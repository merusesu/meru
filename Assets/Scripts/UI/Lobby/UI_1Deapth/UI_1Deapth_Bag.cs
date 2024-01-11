using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_1Deapth_Bag : MonoBehaviour
{
    public ScrollRect SCRT;
    public Transform TRGRID;    // 부모 그리드

    public UI_Bag_Item BAG_ITEM_PREFAB;    // 객체의 프리팹

    List<UI_Bag_Item> mBag_Item_List = new List<UI_Bag_Item>();   // 객체의 리스트

    public Text c_PlayerMoney;

    Queue<int> m_Que = new Queue<int>();    // 지워진 객체의 번호를 저장하는 큐
    Stack<int> m_Stack = new Stack<int>();

    public List<Item_Data> BuyItem = new List<Item_Data>(); 

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        c_PlayerMoney.text = SharedObject.g_SceneMgr.m_Player.Money.ToString();
        for (int i = BuyItem.Count; i < SharedObject.g_SceneMgr.m_UsedItem.Count; i++)
        {
            BuyItem.Add(SharedObject.g_SceneMgr.m_UsedItem[i]);  // 저장된 아이템을 추가
            if (BuyItem[i].ItemType >= (int)eITEMTYPE.eITEMTYPE_ARMOR && BuyItem[i].ItemType <= (int)eITEMTYPE.eITEMTYPE_ACCESSORIES)
            {
                UI_Bag_Item newBagItem = Instantiate(BAG_ITEM_PREFAB, TRGRID);  // 클론생성
                newBagItem.SetItem(BuyItem[i]);    // 아이템적용
                mBag_Item_List.Add(newBagItem); // 리스트에 넣음
            }
        }
    }

    public void OnBtnBack()
    {
        transform.gameObject.SetActive(false);
    }
}
