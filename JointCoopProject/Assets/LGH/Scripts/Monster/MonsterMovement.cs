using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public abstract class MonsterMovement : MonoBehaviour
{
    // �����¿�� �ڵ����� �����̴� ������ AI ���� �ʿ�
    // �������� �ʴ� ���͵� ���� �� �����Ƿ� canMove bool������ �¿��� ����
    public bool _isPatrol;
    public bool _isTrace;
    private SpriteRenderer _sprRend;
    private Rigidbody2D _rb;
    private Vector2 _patrolDir;
    private float _moveTimer;
    private float _changeInterval = 1.5f;

    private void Awake() => Init();

    private void Init()
    {
        _sprRend = GetComponent<SpriteRenderer>();
        _rb = GetComponent<Rigidbody2D>();
        _isPatrol = false;
        _moveTimer = 0f;
    }

    public void Trace(float moveSpd)
    {
        GameObject player = GameObject.Find("Player");
        if (player == null) return;

        Vector2 currentPos = _rb.position;
        Vector2 targetPos = player.transform.position;
        _patrolDir = targetPos - currentPos;
        Vector2 newPos = Vector2.MoveTowards(currentPos, targetPos, moveSpd * Time.fixedDeltaTime);

        UpdateSpriteDir();

        _rb.MovePosition(newPos);
    }

    public void Patrol(float moveSpd)
    {
        // timer �ð� ���� �̵�
        _rb.MovePosition(_rb.position + _patrolDir * moveSpd * Time.fixedDeltaTime);
        UpdateSpriteDir();
        _moveTimer += Time.fixedDeltaTime;
        if (_moveTimer >= _changeInterval)
        {
            ChangeDir();
            _moveTimer = 0f;
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

    protected void UpdateSpriteDir()
    {
        if (_patrolDir.x < 0)
            _sprRend.flipX = true;
        else if( _patrolDir.x > 0)
            _sprRend.flipX = false;
    }
}
