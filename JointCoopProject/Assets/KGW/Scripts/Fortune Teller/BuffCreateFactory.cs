using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;

public static class BuffCreateFactory
{
    private static System.Random _randomChoice = new System.Random();

    //// ���۷귿 (30% : �ູ, 20% : ����, 50% : ��)
    //public static IBuff BuffRoulette()
    //{
    //    // 1 ~ 100 Choice
    //    int randomRoll = _randomChoice.Next(1, 101);

    //    if (randomRoll < 51)    // ��!! (50%)
    //    {
    //        return new Nothing_Buff();
    //    }
    //    else if ( randomRoll < 81)  // �ູ!! (30%)
    //    {
    //        // 1 ~ 20 Choice
    //        int blessRoll = _randomChoice.Next(1, 21);

    //        if (blessRoll < 16) // �ູ�� 15%�� ����, 5%�� ������ �
    //        {
                
    //        }
    //        else
    //        {
    //            return new TodayFortune_Buff();
    //        }
    //    }
    //}

    //// �ູ ���� ����
    //public static IBuff GenerateBlessBuff(BuffCategory category, int level)
    //{
    //    int bufferTypeRoll = _randomChoice.Next(1, 21);

    //    if (bufferTypeRoll < 6)
    //    {
    //        return new AttackPower_Buff(category, level);
    //    }

    //}

    //// ���� ���� ����
    //public static IBuff GenerateCursBuff(BuffCategory category, int level)
    //{

    //}


}
