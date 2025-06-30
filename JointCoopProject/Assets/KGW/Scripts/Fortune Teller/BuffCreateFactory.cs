using Unity.VisualScripting;
using UnityEngine;

public static class BuffCreateFactory
{
    static System.Random _randomChoice = new System.Random();

    // ���۷귿 (30% : �ູ, 20% : ����, 50% : ��)
    public static IBuff BuffRoulette()
    {
        int playerLuckSetting = PlayerStatManager.Instance._playerLuck * 5; // ĳ���� ��1 -> Ȯ�� 5% 
        
        // 0 ~ 99 Choice
        int randomRoll = _randomChoice.Next(0, 100);

        if (randomRoll < 50 - playerLuckSetting)    // ��!! (50%) , ĳ���� ��1 -> �� Ȯ�� 5%����
        {
            return new Nothing_Buff();
        }
        else if (randomRoll < 80)  // �ູ!! (30%) ĳ���� ��1 -> �ູ Ȯ�� 5%����
        {
            return GenerateBlessBuff();
        }
        else    // ����!! (20%)
        {
            return GenerateCusDeBuff();
        }
    }

    // �ູ ���� ���� ����
    public static IBuff GenerateBlessBuff()
    {
        int playerLuckSetting = PlayerStatManager.Instance._playerLuck;
        int baseRollRange = 3000;   // �ູ ���� �ʱ� 30%
        int currentRollRange = baseRollRange + (playerLuckSetting * 500);   // ĳ���� �� 1���� -> ��ü Ȯ�� 5%����

        int level1_Range = 2000 + (playerLuckSetting * 200);    // Level 1 Buff ���� ����
        int level2_Range = level1_Range + 700 + (playerLuckSetting * 100);  // Level 2 Buff ���� ����
        int level3_Range = level2_Range + 200 + (playerLuckSetting * 100);  // Level 3 Buff ���� ����
        int level4_Range = level3_Range + 65 + (playerLuckSetting * 70);    // Level 4 Buff ���� ����, Level 5 ������ ������ 

        // �Ҽ��� �� ���ڸ�, �Ʒ� ���ڸ��� Ȯ���� ���Ͽ� õ������ ����
        int BlessLevelRoll = _randomChoice.Next(0, currentRollRange);

        if (BlessLevelRoll < level1_Range)   // Level 1 Bless (20%) ��1 -> Level1 Ȯ�� 2%����
        {
            return GenerateBuffType(BuffCategory.Blessing, 1);
        }
        else if (BlessLevelRoll < level2_Range)  // Level 2 Bless (7%) ��1 -> Level1 Ȯ�� 1%����
        {
            return GenerateBuffType(BuffCategory.Blessing, 2);
        }
        else if (BlessLevelRoll < level3_Range)  // Level 3 Bless (2%) ��1 -> Level1 Ȯ�� 1%����
        {
            return GenerateBuffType(BuffCategory.Blessing, 3);
        }
        else if (BlessLevelRoll < level4_Range)  // Level 4 Bless (0.65%) ��1 -> Level1 Ȯ�� 0.7%����
        {
            return GenerateBuffType(BuffCategory.Blessing, 4);
        }
        else  // Level 5 Bless (0.35%) ��1 -> Level1 Ȯ�� 0.3%����
        {
            return GenerateBuffType(BuffCategory.Blessing, 5);
        }
    }

    // ���� ����� ���� ����
    public static IBuff GenerateCusDeBuff()
    {
        int baseRollRange = 2000;   // ���� ����� �ʱ� 20%

        // �Ҽ��� �� ���ڸ�, �Ʒ� ���ڸ��� Ȯ���� ���Ͽ� õ������ ����
        int CusLevelRoll = _randomChoice.Next(0, baseRollRange);

        if (CusLevelRoll < 1000)   // Level 1 Cus (10%)
        {
            return GenerateBuffType(BuffCategory.Curs, 1);
        }
        else if (CusLevelRoll < 1400)  // Level 2 Cus (4%)
        {
            return GenerateBuffType(BuffCategory.Curs, 2);
        }
        else if (CusLevelRoll < 1700)  // Level 3 Cus (3%)
        {
            return GenerateBuffType(BuffCategory.Curs, 3);
        }
        else if (CusLevelRoll < 1900)  // Level 4 Cus (2%)
        {
            return GenerateBuffType(BuffCategory.Curs, 4);
        }
        else    // Level 5 Cus (1%)
        {
            return GenerateBuffType(BuffCategory.Curs, 5);
        }
    }

    // ���� Ÿ�� ����
    public static IBuff GenerateBuffType(BuffCategory category, int level)
    {
        int bufferTypeRoll = _randomChoice.Next(0, 20);

        if (bufferTypeRoll < 5) // Attack Power Buff (5%)
        {
            return new AttackPower_Buff(category, level);
        }
        else if (bufferTypeRoll < 10)   // Attack Speed Buff (5%)
        {
            return new AttackSpeed_Buff(category, level);
        }
        else if (bufferTypeRoll < 15)   // Move Speed Buff (5%)
        {
            return new MoveSpeed_Buff(category, level);
        }
        else    // Today Fortune Buff (5%)
        {
            return new TodayFortune_Buff(category, level);
        }

    }
  
}
