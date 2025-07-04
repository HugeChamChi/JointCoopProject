using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSceneManager : MonoBehaviour
{
    static GameSceneManager instance;

    // �ʱ� SceneManager ����
    public static GameSceneManager Instance
    {
        get
        {
            if(instance == null)
            {
                GameObject gameObject = new GameObject("GameSceneManager");
                instance = gameObject.AddComponent<GameSceneManager>();
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
    // UI�� Stack���� ����
    Stack<GameObject> _UiStack = new Stack<GameObject>();

    // UI ����
    public void OpenUi(GameObject ui)
    {
        if (_UiStack.Count > 0)
        {
            // �����ִ� UI�� ������ ����
            _UiStack.Peek().SetActive(false);
        }
        ui.SetActive(true);
        _UiStack.Push(ui);
    }

    // UI �ݱ�
    public void CloseUi()
    {
        if (_UiStack.Count == 0)
        {
            return;
        }
        GameObject ui = _UiStack.Pop();
        ui.SetActive(false);

        if (_UiStack.Count > 0)
        {
            _UiStack.Peek().SetActive(true);
        }
    }

    // �Է��� �� ��ȯ (�̸�)
    public void LoadScene(string sceneName)
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(sceneName);
    }

    // �Է��� �� ��ȯ (����)
    public void LoadScene(int sceneNumber)
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(sceneNumber);
    }

    // �� �� ��ȯ
    public void LoadCutScene()
    {
        LoadScene("Real_CutScene");
    }

    // ���� �� ��ȯ
    public void LoadMainScene()
    {
        LoadScene("Real_MainMenu");
    }

    // �� ���� �� ��ȯ
    public void LoadIngameScene()
    {
        LoadScene("Rear_InGame");
    }

    // Ŭ���� �� ��ȯ
    public void LoadClearScene()
    {
        LoadScene("Rear_Clear");
    }

    // �������� 1 ��ȯ
    public void LoadStage1Scene()
    {
        LoadScene("Rear_Stage1");
    }

    // �������� 2 ��ȯ
    public void LoadStage2Scene()
    {
        LoadScene("Rear_Stage2");
    }

    // �������� 3 ��ȯ
    public void LoadStage3Scene()
    {
        LoadScene("Rear_Stage3");
    }

    // �������� 4 ��ȯ
    public void LoadStage4Scene()
    {
        LoadScene("Rear_Stage4");
    }

    // �������� 5 ��ȯ
    public void LoadStage5Scene()
    {
        LoadScene("Rear_Stage5");
    }

    // �������� 6 ��ȯ
    public void LoadStage6Scene()
    {
        LoadScene("Rear_Stage6");
    }

    // �������� 7 ��ȯ
    public void LoadStage7Scene()
    {
        LoadScene("Rear_Stage7");
    }

}
