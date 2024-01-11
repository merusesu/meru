using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_PlayerCharacter : MonoBehaviour
{
    public Text PC_Text;
    public Image Image_Icon;

    public void SetText(string _str)    // 이름 설정
    {
        PC_Text.text = _str;
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
