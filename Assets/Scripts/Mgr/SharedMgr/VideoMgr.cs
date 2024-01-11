using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class VideoMgr : MonoBehaviour
{
    public VideoPlayer VIDEOPLAYER; // 비디오 플레이어
    public RawImage RAWIMG; // 레이어이미지
    SoundMgr SOUNDMGR;

    void Awake()
    {
        if (SharedObject.g_VidioMgr == null)    // 이 씬으로 다시돌아올 경우 사용
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
        VIDEOPLAYER.Prepare();  // 비디오 로딩
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void VIDEOPlay()
    {
        StartCoroutine(VideoPlay());
    }

    IEnumerator VideoPlay() // 별개로 호출
    {
        VIDEOPLAYER.Play();
        SOUNDMGR.SoundPause();

        while (true)
        {
            RAWIMG.texture = VIDEOPLAYER.texture;
            yield return new WaitForSecondsRealtime(3f);    // 3초후에 정지
            SOUNDMGR.SoundPlay();
            SharedObject.g_ScenechangeMgr.SceneChange(eSCENE.eSCENE_LOBBY);
            break;
        }

        yield break;    // 여기서 중지
    }
}
