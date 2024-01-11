using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_1Deapth_Rune_Bag : MonoBehaviour
{
    public ScrollRect SCRT;
    public Transform TRGRID;    // �θ� �׸���

    public UI_RuneBag_Item RUNEBAG_ITEM_PREFAB;


    List<UI_RuneBag_Item> mRuneBag_Item_List = new List<UI_RuneBag_Item>();

    Queue<int> m_Que = new Queue<int>();    // ������ ��ü�� ��ȣ�� �����ϴ� ť
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
            UI_RuneBag_Item newRuneBagItem = Instantiate(RUNEBAG_ITEM_PREFAB, TRGRID); // ��ü�߰�
            if (m_Que.Count != 0)
            {
                int _nIndex = m_Que.Dequeue();
                newRuneBagItem.SetItem(_nIndex, _nIndex);
                mRuneBag_Item_List.Add(newRuneBagItem);
                // ��ü�� ���縦 �ϳ��ϳ� ���ϴ� ���� �����
                mRuneBag_Item_List.Sort((x, y) => { return x.m_nIndex.CompareTo(y.m_nIndex); });
            }
            else
            {
                int rand = Random.Range(0, 10);
                newRuneBagItem.SetItem(mRuneBag_Item_List.Count + rand, mRuneBag_Item_List.Count + rand);

                mRuneBag_Item_List.Add(newRuneBagItem); // ����Ʈ�� �߰�
                                                // mRuneBag_Item_List.Sort();   
                                                // ��ü�� �����ϴ� ��
                mRuneBag_Item_List.Sort((x1, y1) => x1.m_nIndex.CompareTo(y1.m_nIndex));
                // x1�� y1�� ���ϴ� ���� (x1�� �̹� �� �ִ� ��, y1�� ���� �߰� �� ��)
            }
        }
        if (Input.GetKeyDown(KeyCode.F2))
        {
            if (0 == mRuneBag_Item_List.Count)  // ����Ʈ�� ������ 0���� �ǵ��ư�
                return;
            Destroy(mRuneBag_Item_List[mRuneBag_Item_List.Count - 1].gameObject); // ����Ʈ�� ���������� ������Ʈ�� ����
            mRuneBag_Item_List.Remove(mRuneBag_Item_List[mRuneBag_Item_List.Count - 1]);  // ����Ʈ���� ����
        }
        if (Input.GetKeyDown(KeyCode.F3))
        {
            m_Que.Enqueue(mRuneBag_Item_List[2].m_nIndex);  // ���ŵ� ����Ʈ�� �߰�
            Destroy(mRuneBag_Item_List[2].gameObject); // ����Ʈ�� ���������� ������Ʈ�� ����
            mRuneBag_Item_List.Remove(mRuneBag_Item_List[2]);
            mRuneBag_Item_List.Sort((x1, y1) => x1.m_nIndex.CompareTo(y1.m_nIndex));


        }
    }
    public void OnBtnBack()
    {
        transform.gameObject.SetActive(false);
    }
}
