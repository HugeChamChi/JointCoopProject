using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrystalBallController : MonoBehaviour
{
    bool _isContact = false;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // �浹ü�� �÷��̾����� Ȯ��
        if (collision.gameObject.CompareTag("Player"))
        {
            // �ѹ� ���������� ������ �Ұ�
            if (_isContact)
            {
                // TODO : ����ߴٴ� ���� ���?
                Debug.Log("�̹� ������ �޾ҽ��ϴ�.");
                return;
            }

            // ���� ���� �귿 ����
            IBuff randomBuff = BuffCreateFactory.BuffRoulette();
            // ���� ����
            BuffManager.Instance.ApplyBuff(randomBuff, PlayerStatManager.Instance);
            // ������ �ް� ���������� ������� �ʰ� ���������� �ٽ� �������ص� ��ȣ�ۿ� ����
            //_isContact = true;

            // ���˽� ����� ����Ʈ
        }
    }
}
