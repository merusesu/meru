using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PVPCamera : MonoBehaviour
{
    public Camera PV_Camera;
    public GameObject MasterGO;
    public GameObject SlaveGO;
    private void Awake()
    {
        CameraPosition(SharedObject.g_SceneMgr.m_nTeam);
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void CameraPosition(int _nIndex)
    {
        if (_nIndex == (int)eTEAM.MASTER)
        {
            PV_Camera.transform.position = MasterGO.transform.position;
            PV_Camera.transform.rotation = MasterGO.transform.rotation;
        }else if (_nIndex == (int)eTEAM.SLAVE)
        {
            PV_Camera.transform.position = SlaveGO.transform.position;
            PV_Camera.transform.rotation = SlaveGO.transform.rotation;
        }
    }
}
