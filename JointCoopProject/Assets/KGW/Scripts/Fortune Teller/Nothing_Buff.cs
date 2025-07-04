using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nothing_Buff : IBuff
{
    public string _buffName => "��";
    public string _buffDescription => "���Դϴ�~~ ������ȸ��...";
    public BuffCategory _buffCategory => BuffCategory.Nothing;
    public BuffType _buffType => BuffType.Nothing;
    public int _buffLevel => 0;

    public void BuffReceive(PlayerStatManager playerStatus)
    {
        Debug.Log("ȿ�� ����");
    }
}

    
