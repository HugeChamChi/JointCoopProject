using System.Collections;
using System.Collections.Generic;
using System.Net;
using UnityEngine;

public class WarriorController : MonsterBase
{
    public float _attack1Cooldown = 15f;
    public float _attack2Cooldown = 0f;
    private int _shieldAmount = 300;
    public int _curShield = 0;
    public float _shieldDuration = 5f;
    public Vector2 _attack2Dir;
    public float _attack2Angle = 60f;
    public Coroutine _coAttack2;
    private readonly WaitForSeconds _attackDelay = new WaitForSeconds(1f);

    [SerializeField] private Attack2Mesh _attack2Mesh;

    public readonly int ATTACK1_HASH = Animator.StringToHash("Attack1");
    public readonly int ATTACK2_HASH = Animator.StringToHash("Attack2");
    public readonly int STUN_HASH = Animator.StringToHash("Stun");

    protected override void Init()
    {
        base.Init();
        _monsterID = 10252;
    }

    protected override void StateMachineInit()
    {
        base.StateMachineInit();
        _stateMachine._stateDic.Add(EState.Attack1, new Warrior_Attack1(this));
        _stateMachine._stateDic.Add(EState.Attack2, new Warrior_Attack2(this));
        _stateMachine._stateDic.Add(EState.Stun, new Warrior_Stun(this));
    }

    protected override void Update()
    {
        base.Update();
        if (_attack1Cooldown > 0f)
        {
            _attack1Cooldown -= Time.deltaTime;
        }

        if (_attack2Cooldown > 0f)
        {
            _attack2Cooldown -= Time.deltaTime;
        }

        if (!_isDamaged && _attack1Cooldown <= 0f && !_isAttack2)
        {
            _movement._isTrace = false;
            _isAttack1 = true;
        }

        if (Vector2.Distance(transform.position, _player.transform.position) <= _model._attack2Range && !_isDamaged && _attack2Cooldown <= 0f && !_isAttack1)
        {
            _movement._isTrace = false;
            _isAttack2 = true;
        }
    }

    // Attack1: �ǵ� ����, 5�ʰ� ���ӵǰ� ü�� 300��ŭ�� �ǵ带 ȹ���ϰ� ���ڸ��� ���� ����
    // ���ӽð��� �����ų� �ǵ尡 ��� �Ҹ�Ǹ� ������ ����ǰ� ����� �������� 15���� ��ٿ��� ���´�.
    public void Attack1()
    {
        SoundManager.Instance.RPlaySFX(SoundManager.ESfx.SFX_WarriorAttack1);
        _model._curHP.Value += _shieldAmount;
        _curShield = _model._curHP.Value;
    }

    public void EndAttack1()
    {
        _movement._isTrace = true;
        _isAttack1 = false;
    }

    // Attack2: ��ä�� ���� ����, ��Ÿ�� 3��
    // ���� ������ �Է¹��� �� ���ݹ��������� ���� 60���� ��ä�� ����
    public void Attack2()
    {
        SoundManager.Instance.PlaySFX(SoundManager.ESfx.SFX_WarriorAttack2);
        Vector2 toPlayer = _player.transform.position - transform.position;

        float angleToPlayer = Vector2.Angle(_attack2Dir, toPlayer.normalized);

        if (toPlayer.magnitude > _model._attack2Range) return;
        else
        {
            if (angleToPlayer <= _attack2Angle / 2f)
            {
                IDamagable player = _player.GetComponent<IDamagable>();
                if (player != null)
                {
                    player.TakeDamage(_model._attack2Damage, transform.position);
                }
            }
        }
    }
    public void GetAttack2Dir()
    {
        // �ִϸ��̼� �̺�Ʈ�� ���� ���� ��ǿ� �Ҵ�
        _attack2Dir = (_player.transform.position - transform.position).normalized;
        if (_coAttack2 != null)
        {
            StopCoroutine(_coAttack2);
            _coAttack2 = StartCoroutine(CoAttack2());
        }
        else
        {
            _coAttack2 = StartCoroutine(CoAttack2());
        }
    }

    private IEnumerator CoAttack2()
    {
        yield return _attackDelay;
        _movement._isTrace = true;
        _isAttack2 = false;
    }

    public void ShowAttack2Mesh()
    {
        _attack2Mesh.gameObject.SetActive(true);
        _attack2Mesh.CreateSector(_attack2Dir);
    }

    public void HideAttack2Filled()
    {
        _attack2Mesh.gameObject.SetActive(false);
    }


    public override void Die()
    {
        base.Die();
        SoundManager.Instance.PlaySFX(SoundManager.ESfx.SFX_WarriorDie);
    }
}
