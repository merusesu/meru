using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBase : MonoBehaviour
{

}

public partial class Camera : CameraBase
{

    void Awake()
    {
        
    }
    // Start is called before the first frame update
    void Start()
    {
        m_fMoveSpeed = 3f;
    }

    // Update is called once per frame
    void Update()
    {
        CameraMove();
    }
}
