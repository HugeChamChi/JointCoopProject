using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveSpeed_Buff : IBuff
{
    public string _buffName => $"�̵��ӵ� {(_buffCategory == BuffCategory.Blessing ? "���� ����" : "���� ����")}";
    public string _buffDescription => $"�̵��ӵ��� {(_buffCategory == BuffCategory.Blessing ? $"{_buffOffset}����" : $"{_buffOffset}����")}";
    public BuffCategory _buffCategory { get; private set; }
    public BuffType _buffType => BuffType.MoveSpeed;
    public int _buffLevel {  get; private set; }

    float _buffOffset;

    public MoveSpeed_Buff(BuffCategory category, int level)
    {
        _buffCategory = category;
        _buffLevel = level;
    }

    public void BuffReceive(PlayerStatManager playerStatus)
    {
        _buffOffset = _buffLevel * 0.1f;

        if (_buffCategory == BuffCategory.Blessing)
        {
            playerStatus._moveSpeed += _buffOffset;
        }
        if (_buffCategory == BuffCategory.Curs)
        {
            playerStatus._moveSpeed -= _buffOffset; // ���ֽ� ���̳ʽ� ���� ����
        }
        
        Debug.Log($"�층~~ �층~~!! �÷��̾ ���� {_buffLevel}�� {_buffName}�� �޾ҽ��ϴ�!!.");
        Debug.Log($"�÷��̾��� {_buffDescription} ��ŵ�ϴ�.");
    }
}
