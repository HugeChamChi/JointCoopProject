using System.Collections;
using System.Collections.Generic;
using System.Data;
using TreeEditor;
using UnityEngine;

public class PlayerSwordController : MonoBehaviour
{
    Transform _playerPos;

    Vector2 _wieldDirection;        // �ֵθ��� ���� ����
    float _wieldAngle = 90f;       // ������ �ֵθ� �ݰ�
    float _rotationSpeed = 420f;    // ȸ�� �ӵ� (���� ���� ���� ���� ȸ���Ѵ�)
    float _wieldRadius = 0.3f;      // ���� ȸ�� �ݰ�
    float _currentAngle = 0;       // ���� ����
    float _startAngle = 0;         // ���� ����
    float _wieldSpeed;              // �÷��̾��� ���� �ӵ�
    int _attackDamage;

    
    private void Update()
    {
        AttackAngle();
    }

    // ������ �ʱ�ȭ
    public void Init(Transform player, Vector2 direction, float attackSpeed, int attackDamage)
    {
        _playerPos = player;
        _wieldDirection = direction.normalized;
        _wieldSpeed = attackSpeed;
        _currentAngle = 0f;
        _attackDamage = attackDamage;

        _startAngle = Mathf.Atan2(_wieldDirection.y, _wieldDirection.x) * Mathf.Rad2Deg;

        float radian = _startAngle * Mathf.Deg2Rad;
        Vector3 firstOffset = new Vector3(Mathf.Cos(radian), Mathf.Sin(radian), 0f) * _wieldRadius;
        transform.position = _playerPos.position + firstOffset;

        transform.rotation = Quaternion.Euler(0, 0, _currentAngle + _startAngle + 90f);
    }

    // ���� �ֵθ� ���� ����
    private void AttackAngle()
    {
        float angle = _rotationSpeed * _wieldSpeed * Time.deltaTime;    // ȸ�����ǵ尡 �÷��̾��� ���ݽ��ǵ忡 ������ �޾� ���� �ֵθ�
        _currentAngle -= angle;

        // ���� ������ ��ġ�� �÷��̾��� �߽��� �������� ����
        float radian = (_currentAngle + _startAngle) * Mathf.Deg2Rad;
        Vector3 posOffset = new Vector3(Mathf.Cos(radian), Mathf.Sin(radian), 0f) * _wieldRadius;   // ������ ������ ���۰����� ���� ���� ȸ�� �ݰ��� ���ؼ� ��ġ �ɼ� ����
        transform.position = _playerPos.position + posOffset;

        transform.rotation = Quaternion.Euler(0, 0, _currentAngle + _startAngle + 90f);

        if (_currentAngle <= -_wieldAngle)
        {
            Destroy(gameObject);
        }
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
            }
        }
    }

    
}
