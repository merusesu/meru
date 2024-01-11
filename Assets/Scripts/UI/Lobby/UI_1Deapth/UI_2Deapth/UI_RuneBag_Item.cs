using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_RuneBag_Item : MonoBehaviour
{
    public Text RuneBag_Text;
    public Image Image_Icon;

    public int m_nIndex;    // ������ ���� ��
    public int m_nCount;    // ������ ����

    public void SetItem(int _nIndex, int _nCount)
    {
        m_nIndex = _nIndex;
        m_nCount = _nCount;

        RuneBag_Text.text = m_nCount.ToString();
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
