using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;

public class PlayerSwordController : MonoBehaviour
{
    Transform _playerPos;   // �÷��̾� ��ġ
    Vector2 _attackDirection;   // ���� ����
    float _attackSpeed; // ���� �ӵ�
    float _attackRange; // ���� ��Ÿ�
    int _attackDamage;  // ���� �����
    PlayerSkillManager _skillManager;

    // ������ �ʱ�ȭ
    public void Init(Transform player, Vector2 direction, float attackSpeed, int attackDamage, PlayerSkillManager skillManager, float attackRange)
    {
        _playerPos = player;
        _attackDirection = direction.normalized;
        _attackSpeed = attackSpeed;
        _attackDamage = attackDamage;
        _skillManager = skillManager;
        _attackRange = attackRange;

        float SwordTimer = 0.3f / Mathf.Clamp(_attackSpeed, 0.01f, 10f); // ���ݼӵ��� �ݺ���Ͽ� �����ð� ����(���� 2 �� 0.5�� ����)
        Destroy(gameObject, SwordTimer);
    }

    private void Update()
    {
        // �÷��̾��� ��ġ�� ���󰡵���
        transform.position = _playerPos.position + (Vector3)(_attackDirection * _attackRange);

        float angle = Mathf.Atan2(_attackDirection.y, _attackDirection.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, angle);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Enemy"))
        {
            Debug.Log($"���� {_attackDamage}�� �����߽��ϴ�.");
            IDamagable damagable = collision.GetComponent<IDamagable>();
            if (damagable != null)
            {
                damagable.TakeDamage(_attackDamage, transform.position);
                _skillManager.SwordUpgradeAttack();
            }
        }
    }    
}
