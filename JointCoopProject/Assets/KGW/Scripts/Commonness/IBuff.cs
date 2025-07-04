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
    // ������ ���� (���ݷ�, ���ǵ�, ���ݼӵ�, ������ �)
    BuffType _buffType { get; }
    // ������ ����
    int _buffLevel { get; }

    // �÷��̾��� ���۸� �޴� �޼���
    public void BuffReceive(PlayerStatManager playerStatus);
}

// ������ ����
public enum BuffCategory
{ 
  //  �ູ  , ����,   �� 
    Blessing, Curs, Nothing
}

// ������ Ÿ��
public enum BuffType
{ 
  //   ���ݷ�  , �̵��ӵ� ,  ���ݼӵ�  , ������ �, ��
    AttackPower, MoveSpeed, AttackSpeed, Fortune, Nothing

}
