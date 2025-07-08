using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoisonAttackMultiDamage : MonoBehaviour
{
    IDamagable _target; // ���� ���� Ÿ��
    int _poisonDamage;  // �� �����
    float _poisonTime = 1.5f;   // �ٴ� ��Ʈ �ð�
    int _poisonAttackCount = 3; // �ٴ� ��Ʈ Ƚ��
    Coroutine _poisonRoutine;
    
    public void Apply(IDamagable target, int damage)
    {
        _target = target;
        _poisonDamage = damage;
        // �ڷ�ƾ�� Null�� �ƴϸ� Null�� ����
        if (_poisonRoutine != null )
        {
            StopCoroutine(_poisonRoutine);
            _poisonRoutine = null;
        }
        _poisonRoutine = StartCoroutine(ApplyPoison());
    }

    // �� ���� �ٴ� ��Ʈ ����
    private IEnumerator ApplyPoison()
    {
        int count = 0;
        while (count < _poisonAttackCount)
        {
            _target.TakeDamage(_poisonDamage, transform.position);
            Debug.Log($"[�� �����] {_poisonDamage} ���� �����.");

            count++;
            yield return new WaitForSeconds(_poisonTime);
        }
        _poisonRoutine = null;

        // �ٽ� �����ϱ� ���ؼ� Component ����
        Destroy(gameObject.GetComponent<PoisonAttackMultiDamage>());
    }
}
