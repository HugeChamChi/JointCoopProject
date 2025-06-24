using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class MonsterBase : MonoBehaviour
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
    private float _activeDelay;
    public bool _isActivated;
    public MonsterMovement _movement;
    public MonsterModel _model;
    public MonsterView _view;
    public StateMachine _stateMachine;
    public bool _isAttack1;

    public readonly int IDLE_HASH = Animator.StringToHash("Idle");
    public readonly int MOVE_HASH = Animator.StringToHash("Walk");

    private void Awake() => Init();

    protected virtual void Init()
    {
        _model = GetComponent<MonsterModel>();
        _movement = GetComponent<MonsterMovement>();
        _view = GetComponent<MonsterView>();

        StateMachineInit();
    }

    // ��� Monster���� ���������� ���� Idle, Patrol
    protected virtual void StateMachineInit()
    {
        _stateMachine = new StateMachine();
        _stateMachine._stateDic.Add(EState.Idle, new Monster_Idle(this));
        _stateMachine._stateDic.Add(EState.Patrol, new Monster_Patrol(this));
        _stateMachine._stateDic.Add(EState.Trace, new Monster_Trace(this));

        _stateMachine._curState = _stateMachine._stateDic[EState.Idle];
    }

    private void Start()
    {
        _activeDelay = 1f;
        _isActivated = false;
        _isAttack1 = false;
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
}
