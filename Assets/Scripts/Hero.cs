using System.Collections;
using System.Collections.Generic;
using UnityEngine;

enum eCLASS // 병과
{
    eCLASS_SHILDER, // 방패병(탱커)
    eCLASS_SOLIDER, // 전투병(딜러)
    eCLASS_TRICK,   // 책략병(서포터)
    eCLASS_END
}

enum eGRADE  // 등급
{
    eGRADE_NOMER,        // 노멀
    eGRADE_RARE,         // 레어
    eGRADE_SUPER,        // 슈퍼
    eGRADE_SUPERPLUS,    // 슈퍼+
    eGRADE_SUPERRARE,    // 슈퍼레어
    eGRADE_SUPERRAREPLUS,// 슈퍼레어+
    eGRADE_END
}

enum eSTAT // 스텟 
{
    eSTAT_FORCE,          // 무력(공격력/회복력)
    eSTAT_LEADERSHIP,     // 통솔력(공격속도)
    eSTAT_INT,            // 지력(스킬추가피해/회복)
    eSTAT_DEF,            // 방어력(방어도)
    eSTAT_HP,             // 체력(HP)
    eSTAT_CRICHANCE,      // 치명타(2배공격확률)
    eSTAT_DEFPEN,         // 관통력(방어구무시)
    eSTAT_DODGE,          // 회피력(공격을 피할확룰)
    eSTAT_END
}

public class Hero_Data // 영웅의 데이터 정보
{
    private byte m_nGrade;    // 등급
    private byte m_nClass;   // 병과
    private short m_nLevel;   // 레벨
    public float[] m_nStat =new float[(int)eSTAT.eSTAT_END];   // 스텟

    public byte Grade { get { return m_nGrade; } set { m_nGrade = value; } }
    public byte Class { get { return m_nClass; } set { m_nClass = value; } }
    public short Level { get { return m_nLevel; } set { m_nLevel = value; } }
}

public class Hero : MonoBehaviour   // 영웅의 인게임 정보(변화함,스킬구현(기본,패시브,패시브,궁극기)등)
{
    private byte m_nHeroGrade;  // 


    private void Start()
    {
        
    }

    private void Update()
    {
        
    }
}
