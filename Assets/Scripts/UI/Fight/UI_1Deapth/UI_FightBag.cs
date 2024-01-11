using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_FightBag : MonoBehaviour
{
    public RectTransform PlayerState;

    public ScrollRect SCRT;
    public Transform TRGRID;    // 부모 그리드
    public RectTransform RTGRID;

    public UI_Bag_Button BAG_Button_PREFAB;    // 객체의 프리팹

    List<UI_Bag_Button> mBag_Button_List = new List<UI_Bag_Button>();   // 객체의 리스트

    Queue<int> m_Que = new Queue<int>();    // 지워진 객체의 번호를 저장하는 큐
    Stack<int> m_Stack = new Stack<int>();

    public List<Item_Data> BuyItem = new List<Item_Data>();

    // Start is called before the first frame update
    void Start()
    {
        BuyItem = SharedObject.g_SceneMgr.m_PotionItem;  // 공용아이템이 있는지 확인하기 위함
        for (int i = 0; i < BuyItem.Count; i++)
        {
            UI_Bag_Button newBagPotion = Instantiate(BAG_Button_PREFAB, TRGRID);  // 클론생성
            newBagPotion.SetItem(BuyItem[i]);    // 아이템적용
            mBag_Button_List.Add(newBagPotion); // 리스트에 넣음
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
            if (mBag_Button_List[i].m_nCount <= 0)  // 물약이 없으면 삭제
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
