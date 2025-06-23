using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public abstract class ProtoItem : MonoBehaviour
{
    /* ������ �䱸����
     * ����: active/passive/one time/weapon(deprecated)
     * 
     * Item - weapon(deprecated)
     * ȹ�� �� player�� ���� ��� ����
     *  -> ������ ���� ���
     * 
     * Item - active (�߰� ��ų ����)
     * ȹ�� �� Ư�� Ű�Է�(space)�� ���� ���
     *  -> �����ۺ��� ���� �߻��ϴ� ȿ�� ����
     *  -> ����� ���� ������(���� ���ɼ� ����)�� ��� inventory���� ����
     *  -> ȹ���Ҷ� �������� ��ü���� �����ϴ� ��� �ʿ�
     *  e.g. ĳ���� ȸ�� ���, �ݻ� ��
     * 
     * Item - passive(3 types)
     *  type AT - attack passive(���� ���� ����/��ü�� ���� ������ ������)
     *  �⺻ ���� ��ȭ(���� ��� �߰�)
     *  type AU - auto passive
     *   -> player attack�� �ߵ�/���� cooldown ����(Ȱ��ȭ�� ������ 1���� ���Ͽ�)
     *   -> ���� cooldown���� �ߵ�(Ȱ��ȭ�� ������ n���� ���Ͽ�)
     *   
     * Item - one time
     * coin �� �Ҹ� ��ȭ�� ���� ��ġ ���� //player�� hp�� max hp,
     *  -> ȹ��� �Ҹ�(�κ��丮�� ���� ����)
     * 
     * npc(����)�� �÷��̾� stats�� �⼧�� ��ȹ/������
     * type ST - stats change
     *   -> �ΰ��� ������� ����(��ȸ��: ȹ�� ����� stats�� ������� ���� ��ȭ �� ����/������: ȹ�� �� player�� stats�� ���������� ������ ��ħ(player�� �ൿ�� ���� ��ġ�� �����Ͽ� �������� ��/�̰�� �������� ȿ�� �ݿ��� ���� �켱������ �ʿ���))
     *   -> �κ��丮 ������ player�� ����(attack point, range, speed ��)�� ������ ��
     */

    #region // Item Status
    [SerializeField] private string _itemName; // ������ �̸�
    [SerializeField] private string _itemDescription; // ������ ����
    private Sprite _itemSprite; // ������ ���    
    #endregion

    #region // Events
    [HideInInspector] public UnityEvent OnUsed; // �ƾ��� ���� �߻�
    [HideInInspector] public UnityEvent OnAcquired; // ������ ȹ��� �߻�
    #endregion

    #region // Properties
    protected Sprite ItemSprite { get { return _itemSprite; } private set { _itemSprite = value; } }
    #endregion

    protected void InitItemBase() {
        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
        ItemSprite = spriteRenderer.sprite;
    }


    protected abstract void Use();
    protected abstract void Acquire();

}
