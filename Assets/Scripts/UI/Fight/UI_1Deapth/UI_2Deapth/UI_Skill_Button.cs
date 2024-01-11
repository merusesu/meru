using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Skill_Button : MonoBehaviour
{
    public Image Skill_Icon;
    public Text Skill_Name;
    public Text Skill_Explanation;
    public Table_SkillText m_SkillText = SharedObject.g_TableMgr.m_SkillText;

    public void Skill(int _eplayer,int _eskill)  // ��ų����
    {
        if (_eskill == (int)eSKILL.eSKILL_NOMAL) // �⺻����
        {
            Skill_Name.text = m_SkillText.m_Dictionary[_eplayer].m_strNonName;
            Skill_Explanation.text = m_SkillText.m_Dictionary[_eplayer].m_strNonExp;
        }
        else if (_eskill == (int)eSKILL.eSKILL_SPECIAL)    // Ư�� ����
        {
            Skill_Name.text = m_SkillText.m_Dictionary[_eplayer].m_strSpcName;
            Skill_Explanation.text = m_SkillText.m_Dictionary[_eplayer].m_strSpcExp;
        }
        else if(_eskill == (int)eSKILL.eSKILL_HIGHLIGHT)   // �ñر�
        {
            Skill_Name.text = m_SkillText.m_Dictionary[_eplayer].m_strHilName;
            Skill_Explanation.text = m_SkillText.m_Dictionary[_eplayer].m_strHilExp;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
