using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class VideoMgr : MonoBehaviour
{
    public VideoPlayer VIDEOPLAYER; // ���� �÷��̾�
    public RawImage RAWIMG; // ���̾��̹���
    SoundMgr SOUNDMGR;

    void Awake()
    {
        if (SharedObject.g_VidioMgr == null)    // �� ������ �ٽõ��ƿ� ��� ���
        {
            SharedObject.g_VidioMgr = this;

            DontDestroyOnLoad(gameObject);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        SOUNDMGR = SharedObject.g_SoundMgr;
        RAWIMG.texture = VIDEOPLAYER.texture;
        VIDEOPLAYER.Prepare();  // ���� �ε�
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void VIDEOPlay()
    {
        StartCoroutine(VideoPlay());
    }

    IEnumerator VideoPlay() // ������ ȣ��
    {
        VIDEOPLAYER.Play();
        SOUNDMGR.SoundPause();

        while (true)
        {
            RAWIMG.texture = VIDEOPLAYER.texture;
            yield return new WaitForSecondsRealtime(3f);    // 3���Ŀ� ����
            SOUNDMGR.SoundPlay();
            SharedObject.g_ScenechangeMgr.SceneChange(eSCENE.eSCENE_LOBBY);
            break;
        }

        yield break;    // ���⼭ ����
    }
}
