using System.Collections;
using System.Collections.Generic;
using UnityEngine;

enum eITEMSTATS  // ������ ����ǥ
{
    eITEMSTATS_NORMAL = 5, // �⺻ 5
    eITEMSTATS_LOW = 3,    // ���� 3
    eITEMSTATS_HIGH = 7,   // ���� 7
    eITEMSTATS_CC = 15,    // ũ��Ƽ�ɷ� 15
    eITEMSTATS_CD = 50,    // ũ��Ƽ�ɵ����� 50
    eITEMSTATS_nIndexND
}

public partial class SceneMgr : MonoBehaviour
{
    public Item_Data m_ItemData = new Item_Data();
    public List<Item_Data> m_UsedItem = new List<Item_Data>();  // ������ ó���� ��������� ����

    public List<Item_Data> m_PotionItem = new List<Item_Data>();    // ������ ó���� ���� ������ ����

    public List<Item_Data> m_Armor = new List<Item_Data>();   // ��

    public List<Item_Data> m_Weapon = new List<Item_Data>();  // ����
    
    public List<Item_Data> m_Accessories = new List<Item_Data>();  // ��ű�

    public List<Item_Data> m_Rune = new List<Item_Data>();  // ��

    public List<Item_Data> m_Potion = new List<Item_Data>();  // ����

    public List<Item_Data> m_Buf = new List<Item_Data>();  // ����

    public void ItemSetting(int _nIndexType,int _nIndexNumber)   // ���� ������ ������ ����
    {
        Item_Data newItemData = new Item    // ������ ������ ������
        {
            Name = SharedObject.g_TableMgr.m_Item.m_Dictionary[_nIndexNumber].m_strName,
            ItemType = _nIndexType,
            Itemstat = SharedObject.g_TableMgr.m_Item.m_Dictionary[_nIndexNumber].m_nStat
        };  
        switch (_nIndexType)
        {
            case (int)eITEMTYPE.eITEMTYPE_ARMOR: // ��
                {
                    m_Armor.Add(newItemData);
                    break;
                }
            case (int)eITEMTYPE.eITEMTYPE_WEAPON:    // ����
                {
                    m_Weapon.Add(newItemData);
                    break;
                }
            case (int)eITEMTYPE.eITEMTYPE_ACCESSORIES:  // �Ǽ��縮
                {
                    m_Accessories.Add(newItemData);
                    break;
                }
            case (int)eITEMTYPE.eITEMTYPE_RUNE: // ��
                {
                    m_Rune.Add(newItemData);
                    break;
                }
            case (int)eITEMTYPE.eITEMTYPE_POTION:   // ����
                {
                    newItemData = new Potion    // ������ ������ ������
                    {
                        Name = SharedObject.g_TableMgr.m_Item.m_Dictionary[_nIndexNumber].m_strName,
                        ItemType = _nIndexType,
                        Itemstat = SharedObject.g_TableMgr.m_Item.m_Dictionary[_nIndexNumber].m_nStat
                    };
                    m_Potion.Add(newItemData);
                    Potion newPotion = (Potion)newItemData;
                    for(int i = 0; i < newItemData.Itemstat.Length; i++)
                    {
                        if (0 != newItemData.Itemstat[i])
                            newPotion.PotionType = i;
                    }
                    newPotion.Count = 1;
                    break;
                }
            case (int)eITEMTYPE.eITEMTYPE_BUF:  // ����
                {
                    m_Buf.Add(newItemData);
                    break;
                }
        }
    }

    public void ItemChoose(int _Index) // ������ ����
    {
        int i;
        switch (_Index)
        {
            case (int)eITEMTYPE.eITEMTYPE_ARMOR:
                i = Random.Range(0, m_Armor.Count);
                m_ItemData = m_Armor[i];
                break;
            case (int)eITEMTYPE.eITEMTYPE_WEAPON:
                i = Random.Range(0, m_Weapon.Count);
                m_ItemData = m_Weapon[i];
                break;
            case (int)eITEMTYPE.eITEMTYPE_ACCESSORIES:
                i = Random.Range(0, m_Accessories.Count);
                m_ItemData = m_Accessories[i];
                break;
            case (int)eITEMTYPE.eITEMTYPE_RUNE:
                i = Random.Range(0, m_Rune.Count);
                m_ItemData = m_Rune[i];
                break;
            case (int)eITEMTYPE.eITEMTYPE_POTION:
                i = Random.Range(0, m_Potion.Count);
                m_ItemData = m_Potion[i];
                break;
            case (int)eITEMTYPE.eITEMTYPE_BUF:
                i = Random.Range(0, m_Buf.Count);
                m_ItemData = m_Buf[i];
                break;
        }
    }

    public void ItemSort()  // �������� �����ϴ� �Լ�(Ÿ�Ժ�������)
    {
        if (m_UsedItem.Count < 2) return;
        m_UsedItem.Sort(new Sort());
    }

    public void PotionSort(Item_Data _potion)
    {
        bool b_checkpotion = false;
        List<Potion> Potion_List = new List<Potion>();
        for (int k = 0; k < m_PotionItem.Count; k++)
        {
            Potion_List.Add((Potion)m_PotionItem[k]);
        }
        Potion newpotion = (Potion)_potion; // ���� ������ �־���
        for(int i = 0; i < Potion_List.Count; i++)
        {
            if (newpotion.PotionType == Potion_List[i].PotionType)  // ���� ������ ������ �־���
            {
                Potion_List[i].Count++;
                b_checkpotion = true;  
            }
        }
        if (!b_checkpotion)   // ���� ������ ������ �߰�
        {
            Potion_List.Add(newpotion);
        }
        Potion_List.Sort(new SortPotion()); // Ÿ�Ժ��� ����
        m_PotionItem = new List<Item_Data>();
        for(int u = 0; u < Potion_List.Count; u++)  // �ٽ� �־���
        {
            m_PotionItem.Add((Item_Data)Potion_List[u]);
        }
    }
    
}
