using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sort : IComparer<Item_Data>
{
    public int Compare(Item_Data x,Item_Data y)
    {
        // x�� y���� ���̸� 1
        if (x.ItemType > y.ItemType)
            return 1;

        // x,y�� ������ 0
        if (x.ItemType == y.ItemType)
            return 0;

        // x�� y���� ���̸� -1
        if (x.ItemType < y.ItemType)
            return -1;
        return 0;
    }
}

public class SortPotion : IComparer<Potion>
{
    public int Compare(Potion x,Potion y)
    {
        // x�� y���� ���̸� 1
        if (x.PotionType > y.PotionType)
            return 1;

        // x,y�� ������ 0
        if (x.PotionType == y.PotionType)
        {
            return 0;
        }    

        // x�� y���� ���̸� -1
        if (x.PotionType < y.PotionType)
            return -1;
        return 0;
    }
}
   
