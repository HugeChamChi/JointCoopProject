using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[CreateAssetMenu(menuName = "Skills/Passive/Dagger")]
public class Dagger : SkillDataSO
{
    // ��ų �̸� : �ܰ� ��ô
    // ���� Ÿ��
    // ĳ������ ���� �������� �ܰ� ��ô
    // 15�� ���� 2���� �ܰ� ��ô
    // 25�� ������
    // 4m�� ��ô�Ÿ�
    // ���� ���� (���� �� ��� �ı�)
    public int _skillLevel = 1;
    public int _skillDamage = 20;
    public float _projectileSpeed = 5f; // ����ü �ӵ�
    
    public override void UseSkill(Transform caster, Vector3 dir)
    {
        int _totalDamage;
        // Level +1 == Ȯ�� +5%
        skillPossibility += (_skillLevel * 5f);

        int _randomValue = Random.Range(0, 100);
        if (_randomValue > skillPossibility)
        {
            return;
        }
        // �ܰ� ������ (��ų���� +1 == ������ +5)
        _totalDamage = _skillDamage + (_skillLevel * 5);

        // �ܰ� ����
        GameObject dagger = Instantiate(skillPrefab, caster.position, caster.rotation);
        DaggerController daggerController = dagger.GetComponent<DaggerController>();
        daggerController.Init(dir, _projectileSpeed, _totalDamage);

        // ĳ������ �̵����⿡ �°� �ܰ� ȸ��
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        dagger.transform.rotation = Quaternion.Euler(0f, 0f, angle);
    }
}
