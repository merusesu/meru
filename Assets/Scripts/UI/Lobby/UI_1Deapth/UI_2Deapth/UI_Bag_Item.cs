using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Bag_Item : MonoBehaviour
{
    public Item_Data m_ItemData = new Item();
    public Text Bag_Text;       // �̸�
    public Image Image_Icon;    // ������
    public Image Explanation;   // ����â
    public Text Explanation_Text;   // ����

    string[] ExplanText = { "ü��+", "���׹̳�+", "���ݷ�+", "����+", "ġ����+", "����+", "�������׷�+", "ġ��ŸȮ��+", "ġ��Ÿ������+", "�������+", "���������+" };
    string[] ItemType = { "��", "����", "�Ǽ��縮", "��", "����", "����" };

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

    public void OnBtnIcon() // �������� ������
    {
        Explanation.gameObject.SetActive(true); // ����â ����
    }

    public void OnBtnExplan()   // ����â�� ������
    {
        Explanation.gameObject.SetActive(false);    // ����â ����
    }

    void ExplanationText(Text _text, Item_Data _nItem)
    {
        _text.text = "������ ���� : " + ItemType[_nItem.ItemType] + "\n";    // ������ ����
        for (int i = 0; i < (int)eITEMSTAT.eITEMSTAT_END; i++)   // ��������� ������� �ʰ� ������� ������ ����Ѵ�.
        {
            _text.text += (_nItem.Itemstat[i] == 0 ? "" : ExplanText[i] + _nItem.Itemstat[i].ToString() + "\n");
        }
    }
}
