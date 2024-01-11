using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_Store : MonoBehaviour
{
    public UI_ItemBuy UIITEMBUY;
    public UI_StatBuy UISTATBUY;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ItemBuy_Btn()   // 아이템 구매
    {
        UIITEMBUY.gameObject.SetActive(true);
    }

    public void StatBuy_Btn() // 스텟구매
    {
        UISTATBUY.gameObject.SetActive(true);
    }

    public void Exit_Btn()  // 나가기
    {
        this.gameObject.SetActive(false);
        
    }
}
