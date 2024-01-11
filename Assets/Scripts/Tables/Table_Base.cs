using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class Table_Base 
{
    public static string GetRelativeAssetPath() // 공통된 기능을 불러오는 함수, 경로가 맞는지 확인
    {
        if (Application.isEditor)
            return System.Environment.CurrentDirectory.Replace("\\", "/") + "/Assets";
        else if (Application.isMobilePlatform || Application.isConsolePlatform)
            return Application.persistentDataPath + "/Assets";
        else    // For Standalone Player.
            return Application.streamingAssetsPath;
    }

    protected void Load_Binary<T>(string _strName,ref T _obj)   // 저장된 파일을 가져오는 함수
    {
        var b = new BinaryFormatter();
        TextAsset asset = Resources.Load("Table_" + _strName) as TextAsset;

        Stream stream = new MemoryStream(asset.bytes);
        _obj = (T)b.Deserialize(stream);
        stream.Close();
    }

    protected void Save_Binary(string _strName,object _obj) // 파일을 저장하는 함수
    {
        var b = new BinaryFormatter();
        Stream stream = File.Open(GetRelativeAssetPath() +
            "/Table/Resources" + "/Table_" + _strName + ".txt",
            FileMode.OpenOrCreate, FileAccess.Write);
        b.Serialize(stream, _obj);
        stream.Close();
    }

    protected CSVReader GetCSVReader(string _strName,eENCODING _eEncoding = eENCODING.eUTF8)    // CSV를 파싱하는 코드
    {
        string strExt = ".csv";
        if (eENCODING.eUNICODE == _eEncoding)
            strExt = ".txt";
        FileStream file = new FileStream("./Document/" + _strName + strExt, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);

        StreamReader stream;

        switch (_eEncoding)// [kks][Language] : 파싱타입
        {
            case eENCODING.eUTF8:
                stream = new StreamReader(file, System.Text.Encoding.UTF8);
                break;
            case eENCODING.eUNICODE:
                stream = new StreamReader(file, System.Text.Encoding.Unicode);
                break;
            default:
                stream = new StreamReader(file, System.Text.Encoding.Default);
                break;
        }

        CSVReader reader = new CSVReader();
        reader.parse(stream.ReadToEnd(), false, (int)_eEncoding);
        stream.Close();
        return reader;
    }
}
