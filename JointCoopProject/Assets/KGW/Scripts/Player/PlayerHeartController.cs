using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHeartController : MonoBehaviour
{
    [Header("Player Heart UI")]
    [SerializeField] Sprite _fullHeart;  // ������ ��Ʈ (Ǯ��Ʈ)
    [SerializeField] Sprite _halfHeart;  // �� ��Ʈ (���� ��Ʈ)    
    [SerializeField] Sprite _emptyHeart;  // �� ��Ʈ

    [Header("Heart Object Reference")]
    [SerializeField] List<Image> _heartList = new List<Image>();    // Heart Object ���� ����Ʈ

    public void HeartsUpdate(float playerCurrentHp, float playerMaxHp)
    {
        for(int i = 0; i < _heartList.Count; i++)
        {
            float heartstate = Mathf.Clamp(playerCurrentHp - i, 0f, 1f);

            if (i < Mathf.CeilToInt(playerMaxHp))
            {
                _heartList[i].gameObject.SetActive(true);

                if (heartstate >= 1f)   // ��Ʈ�� ���°� Ǯ��Ʈ
                {
                    _heartList[i].sprite = _fullHeart;
                }
                else if (heartstate == 0.5f)    // ��Ʈ�� ���°� ���� ��Ʈ
                {
                    _heartList[i].sprite = _halfHeart;
                }
                else   // ��Ʈ�� ���°� �� ��Ʈ
                {
                    _heartList[i].sprite = _emptyHeart;
                    _heartList[i].gameObject.SetActive(false);
                }
            }
            else
            {
                _heartList[i].gameObject.SetActive(false);
            }      
        }      
    }
}
