using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using SimpleJSON;
using UnityEngine.UI;

public class User_Connect : MonoBehaviour
{
    public Text TEXTINPUT;

    string m_strUserUrl = "process/userselect";

    IEnumerator RequestPost(string _url, string _strUsername)    //_strNum은 서버명
    {
        WWWForm form = new WWWForm();
        form.AddField("username", _strUsername);

        UnityWebRequest www = UnityWebRequest.Post(_url, form);

        yield return www.SendWebRequest();

        Debug.Log(www.downloadHandler.text);

        bool err = false;

        JSONNode jsonnode = JSON.Parse(www.downloadHandler.text);

        string str = jsonnode["err"];

        if (str == null)
        {
            str = jsonnode["recordsets"];

            string m_strUSN = jsonnode[0][0]["USN"];
            Debug.Log(m_strUSN);
            string m_strUsertype = jsonnode[0][0]["UserType"];
            Debug.Log(m_strUsertype);
            string m_strName = jsonnode[0][0]["Name"];
            Debug.Log(m_strName);
            string m_strDevicekey = jsonnode[0][0]["DeviceKey"];
            Debug.Log(m_strDevicekey);

        }
        else
        {
            Debug.Log(str);
            err = true;
        }

        //Debug.Log(str);
    }

    public void OnBtnUser()
    {
        StartCoroutine(RequestPost(SharedObject.m_strHttp + m_strUserUrl,TEXTINPUT.text)); // 주소+명령어

    }
}
