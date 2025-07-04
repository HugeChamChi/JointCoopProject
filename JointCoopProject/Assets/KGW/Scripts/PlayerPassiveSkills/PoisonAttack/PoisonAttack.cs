using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Skills/Player Passive/Poison Attack")]
public class PoisonAttack : SkillDataSO
{
    // ��ų �̸� : �� ����
    // ���� Ÿ��
    // �⺻ ���� �� �� ����� �ο�
    // 20% Ȯ���� �ο� (Level +1 == +20%)
    // 1.5�� ���� 5�� ����� 3ȸ (Level +1 == +2%)
    public int _skillLevel = 1;
    public int _skillDamage = 3;

    public override void UseSkill(Transform caster, Vector3 dir)
    {
        int _totalDamage;
        // Level +1 == Ȯ�� +20%
        skillPossibility *= _skillLevel;

        int _randomValue = Random.Range(0, 100);
        if (_randomValue > skillPossibility)
        {
            return;
        }
        // �� ����� (��ų���� +1 == ����� +2)
        _totalDamage = _skillDamage + (_skillLevel * 2);
        Vector3 poisonSpawnPos = caster.position + dir;
        GameObject poison = Instantiate(skillPrefab, poisonSpawnPos, Quaternion.identity);
        PoisonAttackController poisonAttackController = poison.GetComponent<PoisonAttackController>();
        poisonAttackController.Init(_totalDamage);
    }
}
