using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ItemSlotUI : MonoBehaviour
{
    [SerializeField] Image _itemIconImage;

    public void SetItemSlot(ItemSlot itemSlot)
    {
        if(itemSlot.itemDataSO != null)
        {
            // ������ �̹��� ���� �� Ȱ��ȭ
            _itemIconImage.sprite = itemSlot.itemDataSO._itemIcon;
            _itemIconImage.enabled = true;
        }
        else
        {
            _itemIconImage.sprite = null;
            _itemIconImage.enabled = false;
        }
    }
}
