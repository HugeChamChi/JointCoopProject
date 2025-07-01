using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Skills/Passive/Flame")]
public class Flame : SkillDataSO
{
    // ��ų �̸� : ��ȭ
    // ���� Ÿ��
    // ĳ������ ���� �������� �ҵ��� �߻�
    // 35�ʸ��� 40%Ȯ���� �߻�
    // 1.5�� ���� 10�� ����� 3ȸ
    // 4m�� ��Ÿ�
    // ���� ���� (���� �� ��� �ı�)
    public int _skillLevel = 1;
    public int _skillDamage = 0;
    public float _projectileSpeed = 5f;

    public override void UseSkill(Transform caster, Vector3 dir)
    {
        int _totalDamage;

        int _randomValue = Random.Range(0, 100);
        if (_randomValue > skillPossibility)
        {
            return;
        }
        // ��ȭ ������ (��ų���� +1 == ������ +10)
        _totalDamage = _skillDamage + (_skillLevel * 10);

        // ��ȭ ����
        GameObject Flame = Instantiate(skillPrefab, caster.position, caster.rotation);
        FlameController FlameController = Flame.GetComponent<FlameController>();
        FlameController.Init(dir, _projectileSpeed, _totalDamage);

        // ĳ������ �̵����⿡ �°� �ҵ��� ȸ��
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        Flame.transform.rotation = Quaternion.Euler(0f, 0f, angle);
    }
}
