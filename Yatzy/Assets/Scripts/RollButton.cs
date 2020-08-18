using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RollButton : MonoBehaviour
{
    public delegate void RollHandler();     // 이벤트를 위한 delegate
    public static event RollHandler Roll;     // event 변수

    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void RollClick()
    {
        if (GameManager.rollCount > 0)             
        {
            // 굴리면 모든 정보가 초기화 및 설정
            Roll();
            GameManager.hand = new int[] { 0, 0, 0, 0, 0, 0 };
            GameManager.rollCount -= 1;
            GameManager.countHand = 0;
            GameManager.once = true;
        }
        else
        {
           Debug.Log("주사위를 더 이상 못굴립니다.");
        }

    }
}
