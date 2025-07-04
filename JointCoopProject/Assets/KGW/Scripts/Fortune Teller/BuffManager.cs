using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuffManager : MonoBehaviour
{
    static BuffManager instance;

    public static BuffManager Instance  // ������Ƽ�� ����
    {
        get
        {
            if (instance == null)   // �ʱ⿡ BuffManager�� ������ ����
            {
                GameObject gameObject = new GameObject("BuffManager");
                instance = gameObject.AddComponent<BuffManager>();
            }
            return instance;
        }
    }

    private void Awake()
    {
        CreateBuffManager();
    }

    private void CreateBuffManager()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);  // ���� ������� ������ ����
        }
        else
        {
            Destroy(gameObject);    // �ߺ����� ������ �ȵǵ��� ����
        }
    }

    List<IBuff> _applyBuffList = new List<IBuff>();
    public string _FortuneExplanation;

    public void ApplyBuff(IBuff applyBuff, PlayerStatManager playerStatus)
    {
        // ���̸� ����
        if (applyBuff._buffCategory == BuffCategory.Nothing)
        {
            Debug.Log($"���~~~?? ���̳׿� >3<");
            return;
        }

        _applyBuffList.Add(applyBuff);  // ����� ���� ����Ʈ�� ���� ���� �߰�
        applyBuff.BuffReceive(playerStatus);    // ������ �÷��̾ ����
    }

    public void FortuneConfirm(string explanation)
    {
        _FortuneExplanation = explanation;
    }

    public void ClearBuff()
    {
        _applyBuffList.Clear();
        Debug.Log("��� ���� �ʱ�ȭ �Ϸ�!!");

        
    }
}
