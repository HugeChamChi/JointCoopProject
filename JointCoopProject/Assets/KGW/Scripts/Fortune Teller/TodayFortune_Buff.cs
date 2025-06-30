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
            Debug.Log($"�÷��̾�� ���� {_buffLevel}�� �ູ ��� �����ݴϴ�.");

            switch (_buffLevel)
            {
                case 1:
                    Debug.Log("���� �������� �ڱ׸��� �ູ�Դϴ�.");
                    break;
                case 2:
                    Debug.Log("���� ����� �γ��� �÷��� �̱�� ���谡 �˴ϴ�.");
                    break;
                case 3:
                    Debug.Log("������ ������� ������ �׷��ٰ� ä������ �ʽ��ϴ�.");
                    break;
                case 4:
                    Debug.Log("����� �ӿ��� ���� ū ��ð� �鸱 ���Դϴ�.");
                    break;
                case 5:
                    Debug.Log("���ο� ���� �ϴ°� ������ Ů�ϴ�. ���ð��� ���̸� �õ��غ��� �ϱ���");
                    break;
                default:
                    break;
            }
        }
        if (_buffCategory == BuffCategory.Curs)
        {
            Debug.Log($"�÷��̾�� ���� {_buffLevel}�� ���� ��� �����ݴϴ�.");

            switch (_buffLevel)
            {
                case 1:
                    Debug.Log("�̵��̶� ������ �ϵ��� ����� �����̴� �����ϼ���");
                    break;
                case 2:
                    Debug.Log("������ �ƴ����� ���ݸ� ��ٸ�����");
                    break;
                case 3:
                    Debug.Log("���� ����� �� ��� �������� �׳��� �־��� �ƴմϴ�");
                    break;
                case 4:
                    Debug.Log("����� �������� ���� �� �� �ֽ��ϴ�. �����ϼ���");
                    break;
                case 5:
                    Debug.Log("������ ���ٴ� �ູ�� ã�°� �����ϴ�.");
                    break;
                default:
                    break;
            }
        }
    }
}
