using System.Collections;
using System.Collections.Generic;
using UnityEngine;

enum eCLASS // ����
{
    eCLASS_SHILDER, // ���к�(��Ŀ)
    eCLASS_SOLIDER, // ������(����)
    eCLASS_TRICK,   // å����(������)
    eCLASS_END
}

enum eGRADE  // ���
{
    eGRADE_NOMER,        // ���
    eGRADE_RARE,         // ����
    eGRADE_SUPER,        // ����
    eGRADE_SUPERPLUS,    // ����+
    eGRADE_SUPERRARE,    // ���۷���
    eGRADE_SUPERRAREPLUS,// ���۷���+
    eGRADE_END
}

enum eSTAT // ���� 
{
    eSTAT_FORCE,          // ����(���ݷ�/ȸ����)
    eSTAT_LEADERSHIP,     // ��ַ�(���ݼӵ�)
    eSTAT_INT,            // ����(��ų�߰�����/ȸ��)
    eSTAT_DEF,            // ����(��)
    eSTAT_HP,             // ü��(HP)
    eSTAT_CRICHANCE,      // ġ��Ÿ(2�����Ȯ��)
    eSTAT_DEFPEN,         // �����(������)
    eSTAT_DODGE,          // ȸ�Ƿ�(������ ����Ȯ��)
    eSTAT_END
}

public class Hero_Data // ������ ������ ����
{
    private byte m_nGrade;    // ���
    private byte m_nClass;   // ����
    private short m_nLevel;   // ����
    public float[] m_nStat =new float[(int)eSTAT.eSTAT_END];   // ����

    public byte Grade { get { return m_nGrade; } set { m_nGrade = value; } }
    public byte Class { get { return m_nClass; } set { m_nClass = value; } }
    public short Level { get { return m_nLevel; } set { m_nLevel = value; } }
}

public class Hero : MonoBehaviour   // ������ �ΰ��� ����(��ȭ��,��ų����(�⺻,�нú�,�нú�,�ñر�)��)
{
    private byte m_nHeroGrade;  // 


    private void Start()
    {
        
    }

    private void Update()
    {
        
    }
}
