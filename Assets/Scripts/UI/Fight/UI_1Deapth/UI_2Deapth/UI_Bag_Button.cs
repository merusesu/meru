using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Bag_Button : MonoBehaviour
{
    public Item_Data m_ItemData = new Item();   // ������ ������
    public int m_nCount;    // ���ళ��
    public Image Bag_Icon;  // ������
    public Text Bag_Name;   // �����̸�
    public Text Bag_Count;  // ����ǥ��
    public Text Bag_Explanation;    // ����
    bool m_bUsed = false;

    string[] ExplanText = { "ü���� +", "���׹̳ʸ� +", "���ݷ��� +", "������ +", "ġ������ +", "������ +", "�������׷��� +"};

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
        for (int i = 0; i < (int)eITEMSTAT.eITEMSTAT_CRICHANCE; i++)   // ��������� ������� �ʰ� ������� ������ ����Ѵ�.
        {
            _text.text += (_nItem.Itemstat[i] == 0 ? "" : ExplanText[i] + _nItem.Itemstat[i].ToString() + "��ŭ �ø���.");
        }
    }

    public void Onclick()
    {
        if (m_bUsed) return;
        m_nCount--;
        Bag_Count.text = m_nCount.ToString();
        for (int i = 0; i < (int)eITEMSTAT.eITEMSTAT_CRICHANCE; i++)   // ��������� ������� �ʰ� ������� ������ ����Ѵ�.
        {
            SharedObject.g_SceneMgr.m_Player.PlayerStat[i] += m_ItemData.Itemstat[i];    // ��������
        }
    }
}
