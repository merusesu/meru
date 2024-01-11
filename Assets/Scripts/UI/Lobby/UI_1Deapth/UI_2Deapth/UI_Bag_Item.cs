using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Bag_Item : MonoBehaviour
{
    public Item_Data m_ItemData = new Item();
    public Text Bag_Text;       // 이름
    public Image Image_Icon;    // 아이콘
    public Image Explanation;   // 설명창
    public Text Explanation_Text;   // 설명

    string[] ExplanText = { "체력+", "스테미너+", "공격력+", "지능+", "치유력+", "방어력+", "마법저항력+", "치명타확률+", "치명타데미지+", "방어구관통력+", "마법관통력+" };
    string[] ItemType = { "방어구", "무기", "악세사리", "룬", "포션", "버프" };

    public void SetItem(Item_Data _nItem)
    {
        Bag_Text.text = _nItem.Name;
        m_ItemData = _nItem;
        ExplanationText(Explanation_Text, _nItem);
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnBtnIcon() // 아이콘을 누르면
    {
        Explanation.gameObject.SetActive(true); // 설명창 켜짐
    }

    public void OnBtnExplan()   // 설명창을 누르면
    {
        Explanation.gameObject.SetActive(false);    // 설명창 꺼짐
    }

    void ExplanationText(Text _text, Item_Data _nItem)
    {
        _text.text = "아이템 종류 : " + ItemType[_nItem.ItemType] + "\n";    // 아이템 종류
        for (int i = 0; i < (int)eITEMSTAT.eITEMSTAT_END; i++)   // 비어있으면 출력하지 않고 비어있지 않으면 출력한다.
        {
            _text.text += (_nItem.Itemstat[i] == 0 ? "" : ExplanText[i] + _nItem.Itemstat[i].ToString() + "\n");
        }
    }
}
