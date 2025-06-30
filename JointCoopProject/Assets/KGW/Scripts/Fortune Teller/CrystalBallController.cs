using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrystalBallController : MonoBehaviour
{
    [SerializeField] Animator _effectAni;
    bool _isContact = false;

    readonly int Bless_Common_Effect = Animator.StringToHash("BlessCommonEffect");
    readonly int Bless_Rare_Effect = Animator.StringToHash("BlessRareEffect");
    readonly int Bless_Legend_Effect = Animator.StringToHash("BlessLegendEffect");
    readonly int Curs_Common_Effect = Animator.StringToHash("CursCommonEffect");
    readonly int Curs_Rare_Effect = Animator.StringToHash("CursRareEffect");
    readonly int Curs_Legend_Effect = Animator.StringToHash("CursLegendEffect");
    readonly int Nothing_Effect = Animator.StringToHash("NothingEffect");

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
            // �ູ ����Ʈ
            if (randomBuff._buffCategory == BuffCategory.Blessing)
            {
                if (randomBuff._buffLevel == 1 ||  randomBuff._buffLevel == 2)
                {
                    _effectAni.Play(Bless_Common_Effect);   // �ູ Level1,2 ����Ʈ
                }
                else if (randomBuff._buffLevel == 3 || randomBuff._buffLevel == 4)
                {
                    _effectAni.Play(Bless_Rare_Effect);     // �ູ Level3,4 ����Ʈ
                }
                else
                {
                    _effectAni.Play(Bless_Legend_Effect);   // �ູ Level5 ����Ʈ
                }
            }
            // ���� ����Ʈ
            if (randomBuff._buffCategory == BuffCategory.Curs)
            {
                if (randomBuff._buffLevel == 1 || randomBuff._buffLevel == 2)
                {
                    _effectAni.Play(Curs_Common_Effect);    // ���� Level1,2 ����Ʈ
                }
                else if (randomBuff._buffLevel == 3 || randomBuff._buffLevel == 4)
                {
                    _effectAni.Play(Curs_Rare_Effect);      // ���� Level3,4 ����Ʈ
                }
                else
                {
                    _effectAni.Play(Curs_Legend_Effect);    // ���� Level5 ����Ʈ
                }
            }
            // �� ����Ʈ
            if(randomBuff._buffCategory == BuffCategory.Nothing)
            {
                _effectAni.Play(Nothing_Effect);            // �� ����Ʈ
            }
        }
    }
}
