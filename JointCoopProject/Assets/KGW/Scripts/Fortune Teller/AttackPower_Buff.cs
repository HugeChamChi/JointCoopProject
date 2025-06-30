using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackPower_Buff : IBuff
{
    public string _buffName => $"���ݷ� {(_buffCategory == BuffCategory.Blessing ? "���� ����" : "���� ����")}";
    public string _buffDescription => $"���ݷ��� {(_buffCategory == BuffCategory.Blessing ? $"{_buffOffset}����" : $"{_buffOffset}����")}";
    public BuffCategory _buffCategory {  get; private set; }
    public BuffType _buffType => BuffType.AttackPower;
    public int _buffLevel {  get; private set; }

    int _buffOffset;

    public AttackPower_Buff(BuffCategory category, int level)
    {
        _buffCategory = category;
        _buffLevel = level;
    }

    public void BuffReceive(PlayerStatManager playerStatus)
    {
        _buffOffset = _buffLevel;

        if (_buffCategory == BuffCategory.Blessing)
        {
            playerStatus._attackDamage += _buffOffset;
        }
        if (_buffCategory == BuffCategory.Curs)
        {
            playerStatus._attackDamage -= _buffOffset;  // ���ֽ� ���̳ʽ� ���� ����
        }
        
        Debug.Log($"�층~~ �층~~!! �÷��̾ ���� {_buffLevel}�� {_buffName}�� �޾ҽ��ϴ�!!.");
        Debug.Log($"�÷��̾��� {_buffDescription} ��ŵ�ϴ�.");
    }

}
