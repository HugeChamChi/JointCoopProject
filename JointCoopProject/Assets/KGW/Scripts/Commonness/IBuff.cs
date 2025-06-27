using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IBuff
{
    // ������ �̸�
    string _buffName {  get; }
    // ������ ȿ�� ����
    string _buffDescription { get; }
    // ������ ī�װ� (�ູ, ����, ��)
    BuffCategory _buffCategory { get; }
    // ������ ���� (���ݷ¾�, ���ǵ��, ���ݼӵ���, ��(�)
    BuffType _buffType { get; }
    // ������ ����
    int _buffLevel { get; }

    // �÷��̾��� ���۸� �޴� �޼���
    public void BuffReceive(PlayerStatus playerStatus);
}

public enum BuffCategory
{ //  �ູ  , ����, �� 
    Blessing, Curs, Nothing
}

public enum BuffType
{ // ���ݷ� ��� ,�̵��ӵ� ���, ������ ������ ����, ��
    AttackPowerUp, MoveSpeedUp, AttackSpeedUp, Nothing
}
