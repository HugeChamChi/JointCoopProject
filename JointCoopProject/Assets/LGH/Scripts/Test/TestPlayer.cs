using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestPlayer : MonoBehaviour, IDamagable
{
    private int _curHP = 30;

    public void TakeDamage(int damage, Vector2 targetPos)
    {
        _curHP -= damage;
        Debug.Log($"{gameObject.name}�� ������ �޾� HP�� �پ��");
        Debug.Log($"���� HP : {_curHP}");
    }
}
