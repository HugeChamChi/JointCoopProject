using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrcController : MonsterBase
{
    public readonly int ATTACK1_HASH = Animator.StringToHash("OrcAttack1");


    protected override void StateMachineInit()
    {
        base.StateMachineInit();
        _stateMachine._stateDic.Add(EState.Attack1, new Orc_Attack1(this));
    }

    protected override void Update()
    {
        base.Update();
    }

    protected override void Attack1()
    {
        // �������� ������ �ֵθ� �� 1�� ����
        // 1�� ����� �ϹǷ� Coroutine ��� �ʿ�
    }
}
