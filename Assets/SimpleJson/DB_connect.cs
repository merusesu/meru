using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using SimpleJSON;
using UnityEngine.UI;

public class DB_connect : MonoBehaviour
{
    public Text TEXTINPUT;

    string m_strUrl = "process/dbconnect";
    string m_strDisUrl = "process/dbdisconnect";

    IEnumerator RequestPost(string _url, string _strNum = "dev")    //_strNum은 서버명
    {
        WWWForm form = new WWWForm();
        form.AddField("num", _strNum);

        UnityWebRequest www = UnityWebRequest.Post(_url, form);

        yield return www.SendWebRequest();

        Debug.Log(www.downloadHandler.text);

        bool err = false;

        JSONNode jsonnode = JSON.Parse(www.downloadHandler.text);

        string str = jsonnode["err"];

        if (str == null)
        {
            str = jsonnode["db"];

            if ("connect" == str)
                Debug.Log(str);
            else if ("disconnect" == str)
            {
                Debug.Log(str);
                err = true;
            }
            else
            {
                Debug.Log(str);
                err = true;
            }
        }
        else
        {
            Debug.Log(str);
            err = true;
        }

        //Debug.Log(str);
    }

    public void OnBtnConnect()
    {
        StartCoroutine(RequestPost(SharedObject.m_strHttp + m_strUrl)); // 주소+명령어
        
    }

    public void OnBtnDisconnect()
    {
        StartCoroutine(RequestPost(SharedObject.m_strHttp + m_strDisUrl));
    }
}
