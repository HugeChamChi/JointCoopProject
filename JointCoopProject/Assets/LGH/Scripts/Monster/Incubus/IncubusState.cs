using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IncubusState : BaseState
{
    protected IncubusController _controller;

    public IncubusState(IncubusController controller)
    {
        _controller = controller;
    }

    public override void Enter()
    {
        
    }

    public override void Update()
    {

    }

    public override void Exit()
    {
        
    }
}

public class Incubus_Attack1 : IncubusState
{
    public Incubus_Attack1(IncubusController controller) : base(controller)
    {
        _hasPhysics = false;
    }

    public override void Enter()
    {
        // Attack1 �ִϸ��̼� ���
        _controller._view.PlayAnimation(_controller.ATTACK1_HASH);
        // Attack1 ��� ����, Attack1Collider�� �ִϸ��̼ǿ� ���缭 Ȱ��ȭ, ��Ȱ��ȭ ����
        _controller.Attack1();
    }

    public override void Update()
    {
        base.Update();
        if (_controller._movement._isTrace && !_controller._isAttack1)
        {
            _controller._stateMachine.ChangeState(_controller._stateMachine._stateDic[EState.Trace]);
        }
        else if (!_controller._isAttack1 && _controller._isDamaged)
        {
            _controller._stateMachine.ChangeState(_controller._stateMachine._stateDic[EState.Damaged]);
        }
    }
}

public class Incubus_Attack2 : IncubusState
{
    public Incubus_Attack2(IncubusController controller) : base(controller)
    {
        _hasPhysics = true;
    }

    public override void Enter()
    {
        // Attack2 �ִϸ��̼� ���
        _controller._view.PlayAnimation(_controller.ATTACK2_HASH);
        // Attack2 ��� ����
        _controller.Attack2();
    }
}
