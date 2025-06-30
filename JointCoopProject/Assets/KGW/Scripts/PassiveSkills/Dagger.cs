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
    public int _skillDamage = 25;
    public float _projectileSpeed = 5f;
    public float _skillTimer = 3f;
    public Transform _PlayerThrowPoint;

    public override void UseSkill(Transform caster)
    {
        int _randomValue = Random.Range(0, 100);
        if (_randomValue > skillPossibility)
        {
            return;
        }

        GameObject Dagger = Instantiate(skillPrefab, _PlayerThrowPoint.forward, Quaternion.identity);
        _skillTimer -= Time.deltaTime;

        if(_skillTimer <= 0)
        {
            Destroy(Dagger);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        
    }

}
