using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

enum ePet { Dog = 1, Cat, Rabbit, Turtle, Penguin, bird }    // 펫 생성 함수


public class PET_Data
{
    private string m_nName;   // 스킬이름
    public int[] PetStat = new int[(int)ePETSTAT.ePETSTAT_END]; // 펫 버프 스텟

    public string Name { get { return m_nName; } set { m_nName = value; } }    // 이름
}
