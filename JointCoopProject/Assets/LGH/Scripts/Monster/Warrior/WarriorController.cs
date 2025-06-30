using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WarriorController : MonsterBase
{
    public readonly int ATTACK1_HASH = Animator.StringToHash("Attack1");
    public readonly int ATTACK2_HASH = Animator.StringToHash("Attack2");

    protected override void Init()
    {
        base.Init();
        _monsterID = 10252;
    }

    protected override void StateMachineInit()
    {
        base.StateMachineInit();
        _stateMachine._stateDic.Add(EState.Attack1, new Warrior_Attack1(this));
        _stateMachine._stateDic.Add(EState.Attack1, new Warrior_Attack2(this));
    }

    // Attack1: �ǵ� ����, 5�ʰ� ���ӵǰ� ü�� 300��ŭ�� �ǵ带 ȹ���ϰ� ���ڸ��� ���� ����
    // ���ӽð��� �����ų� �ǵ尡 ��� �Ҹ�Ǹ� ������ ����ǰ� ����� �������� 15���� ��ٿ��� ���´�.

    // Attack2: ��ä�� ���� ����, ���ݹ��� Player�� �����ؼ� ��� ��������

    
}
