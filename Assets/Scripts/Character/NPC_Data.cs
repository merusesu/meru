using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

enum eNPC { Warrior = 1, Wizard, Knight, Pladin }    // NPC 생성 함수

public class NPC_Data
{
    // 이름과 직업
    private string m_nName; // 이름

    public int[] NPCStat = new int[(int)eNPCSTAT.eNPCSTAT_END];  // NPC의 스텟

    // 이름과 직업
    public string Name { get { return m_nName; } set { m_nName = value; } }    // 이름
}

