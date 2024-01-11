using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_FightBag : MonoBehaviour
{
    public RectTransform PlayerState;

    public ScrollRect SCRT;
    public Transform TRGRID;    // �θ� �׸���
    public RectTransform RTGRID;

    public UI_Bag_Button BAG_Button_PREFAB;    // ��ü�� ������

    List<UI_Bag_Button> mBag_Button_List = new List<UI_Bag_Button>();   // ��ü�� ����Ʈ

    Queue<int> m_Que = new Queue<int>();    // ������ ��ü�� ��ȣ�� �����ϴ� ť
    Stack<int> m_Stack = new Stack<int>();

    public List<Item_Data> BuyItem = new List<Item_Data>();

    // Start is called before the first frame update
    void Start()
    {
        BuyItem = SharedObject.g_SceneMgr.m_PotionItem;  // ����������� �ִ��� Ȯ���ϱ� ����
        for (int i = 0; i < BuyItem.Count; i++)
        {
            UI_Bag_Button newBagPotion = Instantiate(BAG_Button_PREFAB, TRGRID);  // Ŭ�л���
            newBagPotion.SetItem(BuyItem[i]);    // ����������
            mBag_Button_List.Add(newBagPotion); // ����Ʈ�� ����
            //RTGRID.sizeDelta += new Vector2(0, 100);
        }
        if (BuyItem.Count < 3)
        {
            RTGRID.sizeDelta = new Vector2(600, 300);
        }
        else
        {
            RTGRID.sizeDelta = new Vector2(600, (BuyItem.Count * 100));
        }
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < mBag_Button_List.Count; i++)
        {
            if (mBag_Button_List[i].m_nCount <= 0)  // ������ ������ ����
            {
                Destroy(mBag_Button_List[i].gameObject);
                mBag_Button_List.Remove(mBag_Button_List[i]);
                SharedObject.g_SceneMgr.m_PotionItem.Remove(SharedObject.g_SceneMgr.m_PotionItem[i]);
            }
        }
    }
    public void BackBtn()
    {
        PlayerState.anchoredPosition = new Vector2(340, -135);
        this.gameObject.SetActive(false);
    }
}
