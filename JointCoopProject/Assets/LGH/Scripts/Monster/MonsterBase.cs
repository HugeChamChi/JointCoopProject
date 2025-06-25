using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class MonsterBase : MonoBehaviour, IDamagable
{
    // FSM�� ���� �����̴� Monster���� �⺻
    // StateMachine�� �޾ƿ���
    // ���� ������ StateMachine�� �������ִ� ����
    // model, view, movement ������Ʈ ����
    // movement�� MonsterMovement�� ��� ���͵��� �⺻���� �����¿� ������ AI�� ������ ��
    // model�� ������ ����(ü��, ���ݷ�, �̵��ӵ�, �����Ÿ� ��)
    // view�� ���� �ִϸ��̼�, ü�� UI �� ����ڰ� ���� ������ �� �� �ִ� ��ҵ�
    // ��� ���ʹ� �÷��̾ �濡 ó�� �������� �� 1���� �����̸� ���� Ȱ��ȭ�ȴ�.
    // �濡 ���� �� SetActive(true) �ǰ� Start���� 1�� ��⸦ �ɾ��ָ� �ȴ�.
    // �������� ���� �� �ְ� �� �� ����
    // curHP�� 0�� �Ǹ� ��� ó��
    // TODO: ����� ���� Ȯ���� ��ȭ �Ǵ� ������ ���
    private float _activeDelay;
    public bool _isActivated;
    public MonsterMovement _movement;
    public MonsterModel _model;
    public MonsterView _view;
    public StateMachine _stateMachine;
    public GameObject _player;
    public bool _isAttack1;
    public bool _isAttack2;
    public bool _isDamaged;
    public bool _isDead;
    private Coroutine _coOffDamage;
    private WaitForSeconds _damageDelay = new WaitForSeconds(1f);

    public readonly int IDLE_HASH = Animator.StringToHash("Idle");
    public readonly int MOVE_HASH = Animator.StringToHash("Walk");
    public readonly int DAMAGED_HASH = Animator.StringToHash("Damaged");
    public readonly int DEAD_HASH = Animator.StringToHash("Dead");


    private void Awake() => Init();

    protected virtual void Init()
    {
        _model = GetComponent<MonsterModel>();
        _movement = GetComponent<MonsterMovement>();
        _view = GetComponent<MonsterView>();
        _player = GameObject.Find("Player");

        StateMachineInit();
    }

    // ��� Monster���� ���������� ���� Idle, Patrol
    protected virtual void StateMachineInit()
    {
        _stateMachine = new StateMachine();
        _stateMachine._stateDic.Add(EState.Idle, new Monster_Idle(this));
        _stateMachine._stateDic.Add(EState.Patrol, new Monster_Patrol(this));
        _stateMachine._stateDic.Add(EState.Trace, new Monster_Trace(this));
        _stateMachine._stateDic.Add(EState.Damaged, new Monster_Damaged(this));
        _stateMachine._stateDic.Add(EState.Dead, new Monster_Dead(this));

        _stateMachine._curState = _stateMachine._stateDic[EState.Idle];
    }

    private void Start()
    {
        _activeDelay = 1f;
        _isActivated = false;
        _isAttack1 = false;
        _isAttack2 = false;
        _isDamaged = false;
        _isDead = false;
    }

    protected virtual void Update()
    {
        _activeDelay -= Time.deltaTime;
        if (_activeDelay < 0f)
        {
            _isActivated = true;
            _movement._isTrace = true;
        }
        _stateMachine.Update();
    }

    private void FixedUpdate()
    {
        _stateMachine.FixedUpdate();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            IDamagable damagable = collision.gameObject.GetComponent<IDamagable>();
            if (damagable != null)
            {
                damagable.TakeDamage(1, transform.position);
            }
        }
    }

    public void TakeDamage(int damage, Vector2 targetPos)
    {
        if (_isDamaged) return;

        _movement._isTrace = false;
        _isAttack1 = false;
        _isDamaged = true;
        _model._curHP.Value -= damage;

        if (_model._curHP.Value <= 0)
        {
            Die();
        }

        _coOffDamage = StartCoroutine(CoOffDamage());
    }

    private IEnumerator CoOffDamage()
    {
        yield return _damageDelay;
        _movement._isTrace = true;
        _isDamaged = false;
    }

    public void Die()
    {
        _isDead = true;
    }

    public void UnactivateSelf()
    {
        gameObject.SetActive(false);
    }
}
