using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterTest : MonoBehaviour, IDamagable
{
    public void TakeDamage(int damage)
    {
        Debug.Log($"���Ͱ� {damage}�� �޾ҽ��ϴ�.");
    }
}
