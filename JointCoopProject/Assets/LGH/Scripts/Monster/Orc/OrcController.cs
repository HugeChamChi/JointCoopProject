using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrcController : MonsterBase
{
    private Coroutine _coAttack1;

    public readonly int ATTACK1_HASH = Animator.StringToHash("OrcAttack1");

    protected override void Init()
    {
        base.Init();
        _model._maxHP = 30;
        _model._curHP.Value = _model._maxHP;
        _model._attackRange = 2f;
    }

    protected override void StateMachineInit()
    {
        base.StateMachineInit();
        _stateMachine._stateDic.Add(EState.Attack1, new Orc_Attack1(this));
    }

    protected override void Update()
    {
        base.Update();
    }

    public void Attack1()
    {
        // �������� ������ �ֵθ� �� 1�� ����
        // 1�� ����� �ϹǷ� Coroutine ��� �ʿ�
        _coAttack1 = StartCoroutine(CoAttack1());
    }

    private IEnumerator CoAttack1()
    {
        _movement._isTrace = false;
        _isAttack1 = true;
        yield return new WaitForSeconds(1f);
        _movement._isTrace = true;
        _isAttack1 = false;
    }
}
