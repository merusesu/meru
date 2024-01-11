using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class Camera : CameraBase
{
    public Transform PTRGRID = null;    // 플레이어 그리드
    public float m_fMoveSpeed;
    private Vector3 PlayerPosition;

    private void CameraMove()
    {
        // this는 카메라를 의미 (z값은 카메라값을 그대로 유지)
        PlayerPosition.Set(PTRGRID.transform.position.x, PTRGRID.transform.position.y, this.transform.position.z);

        // vectorA -> B까지 T의 속도로 이동
        this.transform.position = Vector3.Lerp(this.transform.position, PlayerPosition, m_fMoveSpeed * Time.deltaTime);
    }

}
