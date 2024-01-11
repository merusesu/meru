using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class TableMgr
{
    public Table_Stage m_Stage = new Table_Stage();
    public Table_CharacterStat m_CharacterStat = new Table_CharacterStat();
    public Table_PlayerBouns m_PlayerBouns = new Table_PlayerBouns();
    public Table_Monster m_Monster = new Table_Monster();
    public Table_Item m_Item = new Table_Item();
    public Table_SkillText m_SkillText = new Table_SkillText();

    public void Init_CSV()
    {
        bool bTableLoad = true;     // 임시
        if (bTableLoad)
        {
            m_Stage.Init_CSV("Stage", 2, 0);    // csv파일의 2행부터 시작
            m_CharacterStat.Init_CSV("CharacterStat", 2, 0);
            m_PlayerBouns.Init_CSV("PlayerBonus", 2, 0);
            m_Monster.Init_CSV("Monster", 2, 0);
            m_Item.Init_CSV("Item", 2, 0);
            m_SkillText.Init_CSV("SkillText", 2, 0);
        }
    }

    public void Save()
    {
        m_Stage.Save_Binary("Stage");
        m_CharacterStat.Save_Binary("CharacterStat");
        m_PlayerBouns.Save_Binary("PlayerBonus");
        m_Monster.Save_Binary("Monster");
        m_Item.Save_Binary("Item");
        m_SkillText.Save_Binary("SkillText");
        //AssetDatabase.Refresh();    // 데이터가 있는지 확인
    }
}
