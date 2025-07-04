using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TodayFortune_Buff : IBuff
{
    public string _buffName => $"������ ����";
    public string _buffDescription => "�÷��̾����� ���� ��⸦ ������ �ݴϴ�.";
    public BuffCategory _buffCategory { get; private set; }
    public BuffType _buffType => BuffType.Fortune;
    public int _buffLevel {  get; private set; }

    public TodayFortune_Buff(BuffCategory category, int level)
    {
        _buffCategory = category;
        _buffLevel = level;
    }

    public void BuffReceive(PlayerStatManager playerStatus)
    {
        if (_buffCategory == BuffCategory.Blessing)
        {
            // �÷��̾�� ���� {_buffLevel}�� �ູ ��� �����ݴϴ�.
            switch (_buffLevel)
            {
                case 1:
                    BuffManager.Instance.FortuneConfirm("���� �������� �ڱ׸��� �ູ�Դϴ�.");
                    break;
                case 2:
                    BuffManager.Instance.FortuneConfirm("���� ����� �γ��� �÷��� �̱�� ���谡 �˴ϴ�.");
                    break;
                case 3:
                    BuffManager.Instance.FortuneConfirm("������ ������� ������ �׷��ٰ� ä������ �ʽ��ϴ�.");
                    break;
                case 4:
                    BuffManager.Instance.FortuneConfirm("����� �ӿ��� ���� ū ��ð� �鸱 ���Դϴ�.");
                    break;
                case 5:
                    BuffManager.Instance.FortuneConfirm("���ο� ���� �ϴ°� ������ Ů�ϴ�. ���ð��� ���̸� �õ��غ��� �ϱ���.");
                    break;
                default:
                    break;
            }
        }
        if (_buffCategory == BuffCategory.Curs)
        {
            // �÷��̾�� ���� {_buffLevel}�� ���� ��� �����ݴϴ�.
            switch (_buffLevel)
            {
                case 1:
                    BuffManager.Instance.FortuneConfirm("�̵��̶� ������ �ϵ��� ����� �����̴� �����ϼ���.");
                    break;
                case 2:
                    BuffManager.Instance.FortuneConfirm("������ �ƴ����� ���ݸ� ��ٸ�����.");
                    break;
                case 3:
                    BuffManager.Instance.FortuneConfirm("���� ����� �� ��� �������� �׳��� �־��� �ƴմϴ�.");
                    break;
                case 4:
                    BuffManager.Instance.FortuneConfirm("����� �������� ���� �� �� �ֽ��ϴ�. �����ϼ���.");
                    break;
                case 5:
                    BuffManager.Instance.FortuneConfirm("������ ���ٴ� �ູ�� ã�°� �����ϴ�.");
                    break;
                default:
                    break;
            }
        }
    }
}
