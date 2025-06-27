using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackPower_Buff : IBuff
{
    public string _buffName => $"���ݷ� {(_buffCategory == BuffCategory.Blessing ? "���� ����" : "���� ����")}";
    public string _buffDescription => $"�÷��̾��� ���ݷ��� {_buffStatus} {(_buffCategory == BuffCategory.Blessing ? "���� ��ŵ�ϴ�." : "���� ��ŵ�ϴ�.")}";
    public BuffCategory _buffCategory {  get; private set; }
    public BuffType _buffType => BuffType.AttackPower;
    public int _buffLevel {  get; private set; }

    int _buffStatus;

    public AttackPower_Buff(BuffCategory category, int level)
    {
        _buffCategory = category;
        _buffLevel = level;
    }

    public void BuffReceive(PlayerStatus playerStatus)
    {
        if(_buffCategory == BuffCategory.Blessing)
        {
            _buffStatus = _buffLevel;
        }
        if (_buffCategory == BuffCategory.Curs)
        {
            _buffStatus *= -1;   // ���ֽ� ���̳ʽ� ���� ����
        }
        playerStatus._attackDamage += _buffStatus;
    }

}
