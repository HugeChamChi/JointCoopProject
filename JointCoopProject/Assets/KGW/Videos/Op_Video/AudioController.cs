using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.Video;

[RequireComponent(typeof(VideoPlayer), typeof(AudioSource))]
public class AudioController : MonoBehaviour
{
    VideoPlayer _videoPlayer;
    AudioSource _audioSource;
    public AudioMixer _audioMixer;
    public AudioMixerGroup _videoGroup;

    private void Start()
    {
        Init();
        VideoSetting();
    }

    private void Update()
    {
        // ��ŵ Ű
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.Instance.LoadMainScene();    
        }
    }

    private void Init()
    {
        _videoPlayer = GetComponent<VideoPlayer>();
        _audioSource = GetComponent<AudioSource>();
        _audioSource.outputAudioMixerGroup = _videoGroup;
    }

    private void VideoSetting()
    {
        // ���� ����
        _videoPlayer.audioOutputMode = VideoAudioOutputMode.AudioSource;    // ���� ����� ����� ���

        // Ʈ�� Ȯ��
        if (_videoPlayer.audioTrackCount > 0 )
        {
            Debug.Log("Ʈ�� ���");
            _videoPlayer.EnableAudioTrack(0, true); // 0�� Track ��� (True)
            _videoPlayer.SetTargetAudioSource(0, _audioSource);
        }
        else
        {
            Debug.Log("Ʈ�� ����");
        }

        // ���� ���� �� Main Scene��ȯ �̺�Ʈ ���
        _videoPlayer.loopPointReached -= SceneChange;   // �ߺ� ��� ������ ���Ͽ� �ϴ� ���� �� �߰�
        _videoPlayer.loopPointReached += SceneChange;

        _videoPlayer.Play();
    }

    // Scene ��ȯ
    private void SceneChange(VideoPlayer videoPlayer)
    {
        SceneManager.Instance.LoadMainScene();
    }

}
