using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// �������� ������ ����
public class Stage : MonoBehaviour
{
    // ����  (1~6����)
    public List<Transform> MTRGRID; // ���� ������ġ
    public List<MonsterPos> m_listPos;    // ���� �̵����

    // �߰����� (1~2����)
    public List<Transform> SBTRGRID; // �߰����� ������ġ
    public List<MonsterPos> m_SlistPos;    // �߰����� �̵����

    // �������� (1����)
    public Transform BTRGRID; // �������� ������ġ
    public MonsterPos m_BlistPos;    // �������� �̵����

    public SafeZone SAFEZONE;   // ȸ����
}
