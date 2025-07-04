using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Skills/Player Passive/Low Speed")]
public class LowSpeed : SkillDataSO
{
    // ��ų �̸� : �̵��ӵ� ����
    // ���� Ÿ��
    // �⺻ ���� �� ���� �̵��ӵ� ���� �ο�
    // 20% Ȯ���� �ο� (Level +1 == +10%)
    // 10% �̵��ӵ� ���� (Level +1 == +10%)
    public int _skillLevel = 1;

    public override void UseSkill(Transform caster, Vector3 dir)
    {
        // Level +1 == Ȯ�� +20%
        skillPossibility *= _skillLevel;

        int _randomValue = Random.Range(0, 100);
        if (_randomValue > skillPossibility)
        {
            return;
        }
        Vector3 lowSpeedSpawnPos = caster.position + dir;
        GameObject lowSpeed = Instantiate(skillPrefab, lowSpeedSpawnPos, Quaternion.identity);
    }
}
