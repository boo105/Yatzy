using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static int[] hand = { 0, 0, 0, 0, 0, 0 };      // 1~6 주사위 수 카운트
    public static int countHand = 0;

    public static int rollCount = 3;  // 주사위 던지는 횟수

    public static bool once;

    private void Update()
    {
        if(countHand == 5 && once)
        {
            once = false;
            for(int i=0; i<6; i++)
            {
               Debug.Log(i + 1 + " 주사위 개수 : " + hand[i]);
            }
        }
    }



    public static void CountDices(int value)
    {
        hand[value - 1] += 1;
    }
     
    void temp()
    {
        // 상단부
        int topScore = 0;
        if (hand[0] > 0)
        {
            int score = hand[0] * 1;
            topScore += score;
        }

        if(hand[1] > 0)
        {
            int score = hand[1] * 2;
            topScore += score;
        }

        if (hand[2] > 0)
        {
            int score = hand[2] * 3;
            topScore += score;
        }

        if (hand[3] > 0)
        {
            int score = hand[3] * 4;
            topScore += score;
        }

        if (hand[4] > 0)
        {
            int score = hand[4] * 5;
            topScore += score;
        }
        if (hand[5] > 0)
        {
            int score = hand[5] * 6;
            topScore += score;
        }

        if(topScore >= 63)
        {
            topScore += 35;
        }

        // 하단부
        int bottomScore = 0;
        string name = "";
        if(name == "choice 클릭 시")
        {
            bottomScore += SumAllHand();
        }

        if(name == "4 of a kind 클릭 시" && CheckFourDice())
        {
            bottomScore += SumAllHand();
        }

        if(name == "Full House 클릭 시" && CheckFullHouse())
        {
            bottomScore += SumAllHand();
        }

        if(name == "S.Straigth 클릭 시" && CheckStraight() >= 4)
        {
            bottomScore += 15;
        }

        if(name == "L.Straight 클릭 시" && CheckStraight() == 5)
        {
            bottomScore += 30;
        }

        if(name == "Yacht 클릭 시" && CheckYacht())
        {
            bottomScore += 50;
        }


    }

    int SumAllHand()
    {
        int score = 0;

        for (int i = 0; i < 6; i++)
        {
            score += hand[i] * (i + 1);  // 개수 * 주사위값
        }

        return score;
    }


    bool CheckFourDice()
    {
        foreach (int value in hand)
        {
            if (value >= 4)
            {
                return true;
            }
        }

        return false;
    }

    bool CheckFullHouse()
    {
        bool big = false , small = false;  // 3개짜리 2개짜리

        foreach (int value in hand)
        {
            if (value == 3)
            {
                big = true;
            }
            else if (value == 2)
            {
                small = true;
            }
        }

        if(big && small)
        {
            return true;
        }

        return false;
    }

    int CheckStraight()
    {
        int totalCount = 0;
        int counting = 0;

        foreach(int value in hand)
        {
            if(value > 0)  // 값이 존재한다면 
            {
                counting++;
            }
            else          // 값이 존재 안한다면
            {
                counting = 0;
            }

            if (counting >= 4) 
            {
                totalCount = counting;
            }
        }


        return totalCount;

        // S.Straight 시 4 반환 L.Straight 시 5반환  둘다 아닐 시 0 반환
    }

    bool CheckYacht()
    {
        foreach (int value in hand)
        {
            if (value == 5)
            {
                return true;
            }
        }

        return false;
    }

}
