using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProtoInventory : MonoBehaviour
{
    // ��Ʈ ������ ����

    /* �κ��丮 �䱸����
     * 
     * active item slot
     *  -> Ȱ���� ������(active item) slot nĭ
     *  -> item ����� ���� ������(6)->������
     *  -> ������ �ű� ȹ��� ������ �ʱ�ȭ(�ִ��)->������
     *  -> �÷��̾������� ������ ��� �Է��� ������ �����(��ų ���)
     *  -> �ʿ� ���: ������ ȹ��(��ü)/������ ���/������ ����(������)/������ �ʱ�ȭ(������)
     * 
     * passive item(AT/AU) slot
     *  -> �� Ÿ��(AT(2-3)/AU(1))�� Ȱ�� ������ slot 1ĭ ��
     *  -> ���� cooldown ��� �ʿ�
     *  -> �ʿ� ���: Ȱ�� ������ ��ü(��� �� ����)/Ȱ�� item cooldown ���/������ ���
     * 
     * passive item list
     *  -> passive item list(List<ProtoItemPassive>)
     *  -> Ȱ�� �� ��Ȱ��ȭ �� passive item ���
     *  -> �ʿ� ���: ��� ���(��� �Ǵ� ������)
     *  
     * UI�� ���� ���� -> ������ Ű �Ҵ��� ���� ������ â�� �����Ұ��ΰ�, Ȥ�� ������ UI�� ���� ǥ���Ұ�����
     */
}
