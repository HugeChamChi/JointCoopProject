using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrystalBallController : MonoBehaviour
{
    [SerializeField] PlayerStatus _playerStatus;
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
                Debug.Log("�̹� �÷��̾ ���������� �����߽��ϴ�.");
                return;
            }

            Debug.Log("�÷��̾ ���������� �����߽��ϴ�.");

            // ���� ���� ����
            // ������ ���۸� �÷��̾ ����
            // ������ �ް� ���������� ������� �ʰ� ���������� �ٽ� �������ص� ��ȣ�ۿ� ����
            _isContact = true;

            // ���˽� ����� ����Ʈ
        }
    }
}
