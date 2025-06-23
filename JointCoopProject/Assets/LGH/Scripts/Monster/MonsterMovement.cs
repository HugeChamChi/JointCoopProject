using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class MonsterMovement : MonoBehaviour
{
    // �����¿�� �ڵ����� �����̴� ������ AI ���� �ʿ�
    // �������� �ʴ� ���͵� ���� �� �����Ƿ� canMove bool������ �¿��� ����
    public bool _canMove;
    private Rigidbody2D _rb;
    private Vector2 _patrolDir;
    private float _moveTimer;
    protected float _moveSpd = 2f;
    private float _changeInterval = 1.5f;
    private Coroutine _coPatrolDelay;
    private WaitForSeconds _patrolDelay;
    private float _delaySec = 1.5f;

    private void Awake() => Init();

    private void Init()
    {
        _rb = GetComponent<Rigidbody2D>();
        _canMove = false;
        _moveTimer = 0f;
        _patrolDelay = new WaitForSeconds(_delaySec);
    }

    public void Patrol()
    {
        // timer �ð� ���� �̵�
        _rb.MovePosition(_rb.position + _patrolDir * _moveSpd * Time.fixedDeltaTime);
        _moveTimer += Time.fixedDeltaTime;
        if (_moveTimer >= _changeInterval)
        {
            ChangeDir();
            _moveTimer = 0f;
            _coPatrolDelay = StartCoroutine(CoPatrolDelay());
        }
    }

    // �� �Ǵ� ��ֹ��� �ε����� ChangeDir�� �ϵ��� ��(�±״� ���� �� ����)
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            ChangeDir();
        }
    }

    private IEnumerator CoPatrolDelay()
    {
        yield return _patrolDelay;
    }

    protected void ChangeDir()
    {
        int dir = Random.Range(0, 5);

        switch (dir)
        {
            case 0: _patrolDir = Vector2.up; break;
            case 1: _patrolDir = Vector2.down; break;
            case 2: _patrolDir = Vector2.left; break;
            case 3: _patrolDir = Vector2.right; break;
            case 4: _patrolDir = Vector2.zero; break;
        }
    }
}
