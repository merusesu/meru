using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_1Deapth_Bag : MonoBehaviour
{
    public ScrollRect SCRT;
    public Transform TRGRID;    // �θ� �׸���

    public UI_Bag_Item BAG_ITEM_PREFAB;    // ��ü�� ������

    List<UI_Bag_Item> mBag_Item_List = new List<UI_Bag_Item>();   // ��ü�� ����Ʈ

    public Text c_PlayerMoney;

    Queue<int> m_Que = new Queue<int>();    // ������ ��ü�� ��ȣ�� �����ϴ� ť
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
            BuyItem.Add(SharedObject.g_SceneMgr.m_UsedItem[i]);  // ����� �������� �߰�
            if (BuyItem[i].ItemType >= (int)eITEMTYPE.eITEMTYPE_ARMOR && BuyItem[i].ItemType <= (int)eITEMTYPE.eITEMTYPE_ACCESSORIES)
            {
                UI_Bag_Item newBagItem = Instantiate(BAG_ITEM_PREFAB, TRGRID);  // Ŭ�л���
                newBagItem.SetItem(BuyItem[i]);    // ����������
                mBag_Item_List.Add(newBagItem); // ����Ʈ�� ����
            }
        }
    }

    public void OnBtnBack()
    {
        transform.gameObject.SetActive(false);
    }
}
