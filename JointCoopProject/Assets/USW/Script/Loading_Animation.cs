using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; // TextMeshPro�� ����Ϸ��� �� ���ӽ����̽��� �ʿ��մϴ�.

public class LoadingTextAnimatorInfinite : MonoBehaviour
{
    public TextMeshProUGUI loadingText; // �ν����Ϳ��� TMP Text ������Ʈ�� ������ ����
    public float delayBetweenDots = 0.2f; // ���� ��Ÿ���� ���� (��)

    private string[] loadingMessages = { "Now Loading", "Now Loading.", "Now Loading..", "Now Loading..." };
    private int currentMessageIndex = 0;

    void Start()
    {
        // �ε� �ؽ�Ʈ ������Ʈ�� ����Ǿ����� Ȯ��
        if (loadingText == null)
        {
            Debug.LogError("Loading Text (TextMeshProUGUI)�� ������� �ʾҽ��ϴ�! �ν����Ϳ��� �������ּ���.");
            enabled = false; // ��ũ��Ʈ ��Ȱ��ȭ
            return;
        }

        // �ε� �ִϸ��̼� ���� �ݺ� ����
        StartCoroutine(AnimateLoadingText());
    }

    // �ε� �ؽ�Ʈ �ִϸ��̼� �ڷ�ƾ (���� �ݺ�)
    IEnumerator AnimateLoadingText()
    {
        while (true) // �� ������ ��ũ��Ʈ�� ��Ȱ��ȭ�ǰų� ���� ������Ʈ�� �ı��� ������ ��ӵ˴ϴ�.
        {
            // ���� �޽��� �ε����� �ؽ�Ʈ�� ǥ��
            loadingText.text = loadingMessages[currentMessageIndex];

            // ���� �޽����� �ε��� ������Ʈ (0 -> 1 -> 2 -> 0 -> ...)
            currentMessageIndex = (currentMessageIndex + 1) % loadingMessages.Length;

            // ������ �����̸�ŭ ��ٸ��ϴ�.
            yield return new WaitForSeconds(delayBetweenDots);
        }
    }
}