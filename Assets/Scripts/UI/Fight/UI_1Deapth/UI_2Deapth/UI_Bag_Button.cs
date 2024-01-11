using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Bag_Button : MonoBehaviour
{
    public Item_Data m_ItemData = new Item();   // 물약의 데이터
    public int m_nCount;    // 물약개수
    public Image Bag_Icon;  // 아이콘
    public Text Bag_Name;   // 물약이름
    public Text Bag_Count;  // 개수표시
    public Text Bag_Explanation;    // 설명
    bool m_bUsed = false;

    string[] ExplanText = { "체력을 +", "스테미너를 +", "공격력을 +", "지능을 +", "치유력을 +", "방어력을 +", "마법저항력을 +"};

    public void SetItem(Item_Data _nItem)
    {
        Potion newPotion = (Potion)_nItem;
        Bag_Name.text = newPotion.Name;
        m_ItemData = newPotion;
        m_nCount = newPotion.Count;
        Bag_Count.text = m_nCount.ToString();
        ExplanationText(Bag_Explanation, newPotion);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        m_bUsed = false;
    }

    void ExplanationText(Text _text, Item_Data _nItem)
    {
        for (int i = 0; i < (int)eITEMSTAT.eITEMSTAT_CRICHANCE; i++)   // 비어있으면 출력하지 않고 비어있지 않으면 출력한다.
        {
            _text.text += (_nItem.Itemstat[i] == 0 ? "" : ExplanText[i] + _nItem.Itemstat[i].ToString() + "만큼 올린다.");
        }
    }

    public void Onclick()
    {
        if (m_bUsed) return;
        m_nCount--;
        Bag_Count.text = m_nCount.ToString();
        for (int i = 0; i < (int)eITEMSTAT.eITEMSTAT_CRICHANCE; i++)   // 비어있으면 출력하지 않고 비어있지 않으면 출력한다.
        {
            SharedObject.g_SceneMgr.m_Player.PlayerStat[i] += m_ItemData.Itemstat[i];    // 스텟증가
        }
    }
}
