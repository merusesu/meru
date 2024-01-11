using System.Collections;
using System.Collections.Generic;
using UnityEngine;

enum eITEMSTATS  // 아이템 기준표
{
    eITEMSTATS_NORMAL = 5, // 기본 5
    eITEMSTATS_LOW = 3,    // 저점 3
    eITEMSTATS_HIGH = 7,   // 고점 7
    eITEMSTATS_CC = 15,    // 크리티걸률 15
    eITEMSTATS_CD = 50,    // 크리티걸데미지 50
    eITEMSTATS_nIndexND
}

public partial class SceneMgr : MonoBehaviour
{
    public Item_Data m_ItemData = new Item_Data();
    public List<Item_Data> m_UsedItem = new List<Item_Data>();  // 아이템 처리전 착용아이템 저장

    public List<Item_Data> m_PotionItem = new List<Item_Data>();    // 아이템 처리전 포션 아이템 저장

    public List<Item_Data> m_Armor = new List<Item_Data>();   // 방어구

    public List<Item_Data> m_Weapon = new List<Item_Data>();  // 무기
    
    public List<Item_Data> m_Accessories = new List<Item_Data>();  // 장신구

    public List<Item_Data> m_Rune = new List<Item_Data>();  // 룬

    public List<Item_Data> m_Potion = new List<Item_Data>();  // 포션

    public List<Item_Data> m_Buf = new List<Item_Data>();  // 버프

    public void ItemSetting(int _nIndexType,int _nIndexNumber)   // 게임 시작전 아이템 세팅
    {
        Item_Data newItemData = new Item    // 아이템 데이터 프리펩
        {
            Name = SharedObject.g_TableMgr.m_Item.m_Dictionary[_nIndexNumber].m_strName,
            ItemType = _nIndexType,
            Itemstat = SharedObject.g_TableMgr.m_Item.m_Dictionary[_nIndexNumber].m_nStat
        };  
        switch (_nIndexType)
        {
            case (int)eITEMTYPE.eITEMTYPE_ARMOR: // 방어구
                {
                    m_Armor.Add(newItemData);
                    break;
                }
            case (int)eITEMTYPE.eITEMTYPE_WEAPON:    // 무기
                {
                    m_Weapon.Add(newItemData);
                    break;
                }
            case (int)eITEMTYPE.eITEMTYPE_ACCESSORIES:  // 악세사리
                {
                    m_Accessories.Add(newItemData);
                    break;
                }
            case (int)eITEMTYPE.eITEMTYPE_RUNE: // 룬
                {
                    m_Rune.Add(newItemData);
                    break;
                }
            case (int)eITEMTYPE.eITEMTYPE_POTION:   // 포션
                {
                    newItemData = new Potion    // 아이템 데이터 프리펩
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
            case (int)eITEMTYPE.eITEMTYPE_BUF:  // 버프
                {
                    m_Buf.Add(newItemData);
                    break;
                }
        }
    }

    public void ItemChoose(int _Index) // 아이템 선택
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

    public void ItemSort()  // 아이템을 정리하는 함수(타입별로정리)
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
        Potion newpotion = (Potion)_potion; // 받은 포션을 넣어줌
        for(int i = 0; i < Potion_List.Count; i++)
        {
            if (newpotion.PotionType == Potion_List[i].PotionType)  // 같은 포션이 있으면 넣어줌
            {
                Potion_List[i].Count++;
                b_checkpotion = true;  
            }
        }
        if (!b_checkpotion)   // 같은 포션이 없으면 추가
        {
            Potion_List.Add(newpotion);
        }
        Potion_List.Sort(new SortPotion()); // 타입별로 정렬
        m_PotionItem = new List<Item_Data>();
        for(int u = 0; u < Potion_List.Count; u++)  // 다시 넣어줌
        {
            m_PotionItem.Add((Item_Data)Potion_List[u]);
        }
    }
    
}
