using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class Camera : CameraBase
{
    public Transform PTRGRID = null;    // �÷��̾� �׸���
    public float m_fMoveSpeed;
    private Vector3 PlayerPosition;

    private void CameraMove()
    {
        // this�� ī�޶� �ǹ� (z���� ī�޶��� �״�� ����)
        PlayerPosition.Set(PTRGRID.transform.position.x, PTRGRID.transform.position.y, this.transform.position.z);

        // vectorA -> B���� T�� �ӵ��� �̵�
        this.transform.position = Vector3.Lerp(this.transform.position, PlayerPosition, m_fMoveSpeed * Time.deltaTime);
    }

}
