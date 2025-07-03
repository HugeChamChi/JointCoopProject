using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Skills/Player Passive/Long Distance Sword")]
public class LongDistanceSword : SkillDataSO
{
    // ��ų �̸� : �˱� 
    // ���� Ÿ��
    // �⺻ ���� �� Ȯ���� �ߵ�
    // 10% Ȯ���� �ߵ� (Level +1 == +10%)
    // 20�� ����� (4Level +10, 5Level + 20)
    public int _skillLevel = 1;
    public int _skillDamage = 20;
    public float _projectileSpeed = 5f; // ����ü �ӵ�

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
        // �˱� ����� (1~3Level ���� �����, 4Level +10, 5Level + 20)
        _totalDamage = _skillLevel == 4 ? 30 : _skillLevel == 5 ? 50 : _skillDamage;

        // �˱� ���� ��ġ�� ���� ����Ʈ���� ����
        Vector3 swordEnergyPos = caster.transform.position;
        swordEnergyPos += dir;

        GameObject swordEnergyThrow = Instantiate(skillPrefab, swordEnergyPos, caster.rotation);
        LongDistanceSwordController poisonAttackController = swordEnergyThrow.GetComponent<LongDistanceSwordController>();
        poisonAttackController.Init(dir, _projectileSpeed, _totalDamage);

        // ĳ������ �̵����⿡ �°� �ܰ� ȸ��
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        poisonAttackController.transform.rotation = Quaternion.Euler(0f, 0f, angle);

    }
}
