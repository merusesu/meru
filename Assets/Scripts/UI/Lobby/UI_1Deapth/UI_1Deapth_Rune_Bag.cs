using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_1Deapth_Rune_Bag : MonoBehaviour
{
    public ScrollRect SCRT;
    public Transform TRGRID;    // 부모 그리드

    public UI_RuneBag_Item RUNEBAG_ITEM_PREFAB;


    List<UI_RuneBag_Item> mRuneBag_Item_List = new List<UI_RuneBag_Item>();

    Queue<int> m_Que = new Queue<int>();    // 지워진 객체의 번호를 저장하는 큐
    Stack<int> m_Stack = new Stack<int>();
    // Start is called before the first frame update
    void Start()
    {

        

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F1))
        {
            UI_RuneBag_Item newRuneBagItem = Instantiate(RUNEBAG_ITEM_PREFAB, TRGRID); // 객체추가
            if (m_Que.Count != 0)
            {
                int _nIndex = m_Que.Dequeue();
                newRuneBagItem.SetItem(_nIndex, _nIndex);
                mRuneBag_Item_List.Add(newRuneBagItem);
                // 전체와 현재를 하나하나 비교하는 정렬 만들기
                mRuneBag_Item_List.Sort((x, y) => { return x.m_nIndex.CompareTo(y.m_nIndex); });
            }
            else
            {
                int rand = Random.Range(0, 10);
                newRuneBagItem.SetItem(mRuneBag_Item_List.Count + rand, mRuneBag_Item_List.Count + rand);

                mRuneBag_Item_List.Add(newRuneBagItem); // 리스트에 추가
                                                // mRuneBag_Item_List.Sort();   
                                                // 전체를 정렬하는 것
                mRuneBag_Item_List.Sort((x1, y1) => x1.m_nIndex.CompareTo(y1.m_nIndex));
                // x1과 y1을 비교하는 정렬 (x1은 이미 들어가 있는 것, y1은 새로 추가 한 것)
            }
        }
        if (Input.GetKeyDown(KeyCode.F2))
        {
            if (0 == mRuneBag_Item_List.Count)  // 리스트의 개수가 0개면 되돌아감
                return;
            Destroy(mRuneBag_Item_List[mRuneBag_Item_List.Count - 1].gameObject); // 리스트의 마지막에서 오브젝트를 삭제
            mRuneBag_Item_List.Remove(mRuneBag_Item_List[mRuneBag_Item_List.Count - 1]);  // 리스트에서 삭제
        }
        if (Input.GetKeyDown(KeyCode.F3))
        {
            m_Que.Enqueue(mRuneBag_Item_List[2].m_nIndex);  // 제거될 리스트를 추가
            Destroy(mRuneBag_Item_List[2].gameObject); // 리스트의 마지막에서 오브젝트를 삭제
            mRuneBag_Item_List.Remove(mRuneBag_Item_List[2]);
            mRuneBag_Item_List.Sort((x1, y1) => x1.m_nIndex.CompareTo(y1.m_nIndex));


        }
    }
    public void OnBtnBack()
    {
        transform.gameObject.SetActive(false);
    }
}
