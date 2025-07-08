using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ItemGuageController : MonoBehaviour
{
    float _coolTime;

    Animator _guageAnimator;
    public bool _canUseItem;

    readonly int IDLE_HASH = Animator.StringToHash("ActiveItemGuageIdle");
    readonly int COOLDOWN_HASH = Animator.StringToHash("ActiveItemCoolTime");

    private void Awake()
    {
        _guageAnimator = GetComponent<Animator>();
    }

    public void OnCoolDown()
    {
        if(!_canUseItem)
        {
            _guageAnimator.speed = 1f / _coolTime;  // ��Ÿ�ӿ� �°� �ִϸ��̼� �ӵ� ����
            _guageAnimator.Play(COOLDOWN_HASH, 0, 0f);

            CancelInvoke("OffCoolDown");    // �ߺ� ����
            Invoke("OffCoolDown", _coolTime);
        }
        
    }

    public void SetCoolTime(float coolTime)
    {
        _coolTime = coolTime;
    }

    private void OffCoolDown()
    {
        _canUseItem = true;
        _guageAnimator.speed = 1f;
    }

    public void ItemUse()
    {
        if (_canUseItem)
        {
            return;
        }

        _guageAnimator.Play(IDLE_HASH, 0, 0f);
        Debug.Log("������ ���");
        _canUseItem = false;
        OnCoolDown();
    }

    public void GetItme()
    {
        _guageAnimator.speed = 1f;
        OnCoolDown();
    }
}
