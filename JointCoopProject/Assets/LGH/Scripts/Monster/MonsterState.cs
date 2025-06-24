using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MonsterState : BaseState
{
    protected MonsterBase _controller;

    public MonsterState(MonsterBase controller)
    {
        _controller = controller;
    }

    public override void Enter()
    {
        
    }

    public override void Update()
    {
        if (!_controller._movement._isPatrol && _controller._isAttack1)
        {
            _controller._stateMachine.ChangeState(_controller._stateMachine._stateDic[EState.Attack1]);
        }
    }

    public override void Exit()
    {

    }
}

public class Monster_Idle : MonsterState
{
    public Monster_Idle(MonsterBase controller) : base(controller)
    {
        _hasPhysics = false;
    }

    public override void Enter()
    {
        // TODO: view���� Idle �ִϸ��̼� ���
        _controller._view.PlayAnimation(_controller.IDLE_HASH);
    }

    public override void Update()
    {
        base.Update();
        if (_controller._movement._isPatrol)
        {
            _controller._stateMachine.ChangeState(_controller._stateMachine._stateDic[EState.Patrol]);
        }

        if (_controller._movement._isTrace)
        {
            _controller._stateMachine.ChangeState(_controller._stateMachine._stateDic[EState.Trace]);
        }
    }
}

public class Monster_Patrol : MonsterState
{
    public Monster_Patrol(MonsterBase controller) : base(controller)
    {
        _hasPhysics = true;
    }

    public override void Enter()
    {
        // TODO: view���� Walk �ִϸ��̼� ���
        _controller._view.PlayAnimation(_controller.MOVE_HASH);
    }

    public override void Update()
    {
        base.Update();
        if (!_controller._movement._isTrace && !_controller._movement._isPatrol)
        {
            _controller._stateMachine.ChangeState(_controller._stateMachine._stateDic[EState.Idle]);
        }
    }

    public override void FixedUpdate()
    {
        _controller._movement.Patrol();
    }
}

public class Monster_Trace : MonsterState
{
    public Monster_Trace(MonsterBase controller) : base(controller)
    {
        _hasPhysics = true;
    }

    public override void Enter()
    {
        // TODO : view���� Move �ִϸ��̼� ���
        _controller._view.PlayAnimation(_controller.MOVE_HASH);
    }

    public override void Update()
    {
        base.Update();
    }

    public override void FixedUpdate()
    {
        _controller._movement.Trace();
    }
}