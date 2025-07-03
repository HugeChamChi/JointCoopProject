using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneManager : MonoBehaviour
{
    static SceneManager instance;

    // �ʱ� SceneManager ����
    public static SceneManager Instance
    {
        get
        {
            if(instance == null)
            {
                GameObject gameObject = new GameObject("SceneManager");
                instance = gameObject.AddComponent<SceneManager>();
            }
            return instance;
        }
    }

    private void Awake()
    {
        CreateSceneManager();
    }

    private void CreateSceneManager()
    {
        if(instance == null)    // ������ �Ǿ� ������ �� ������ �ʰ� ���
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else    // �ߺ� ����
        {
            Destroy(gameObject);
        }
            
    }

    public void LoadScene(string sceneName)
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(sceneName);
    }

    public void LoadCutScene()
    {
        LoadScene("Real_CutScene");
    }

    public void LoadMainScene()
    {
        LoadScene("Real_MainMenu");
    }

    public void LoadIngameScene()
    {
        LoadScene("Rear_InGame");
    }

    public void LoadClearScene()
    {
        LoadScene("Rear_Clear");
    }

    //public void LoadDeathScene()
    //{
    //    LoadScene("DeathScene");
    //}
}
