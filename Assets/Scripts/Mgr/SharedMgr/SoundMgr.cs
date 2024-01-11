using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundMgr : MonoBehaviour
{
    public AudioSource AUDIOSOURCE;

    void Awake()
    {
        if (SharedObject.g_SoundMgr == null)    // �� ������ �ٽõ��ƿ� ��� ���
        {
            SharedObject.g_SoundMgr = this;

            DontDestroyOnLoad(gameObject);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SoundPause()
    {
        AUDIOSOURCE.Pause();
    }

    public void SoundPlay()
    {
        AUDIOSOURCE.Play();
    }

    //public void Sound()
    //{
    //    StartCoroutine(SoundPause());
    //}

    //IEnumerator SoundPause() // ������ ȣ��
    //{
    //    AUDIOSOURCE.Pause();
    //    yield return new WaitForSeconds(3f);    // 3���Ŀ� ����
    //    AUDIOSOURCE.Play();
    //    yield break;
    //}
}
