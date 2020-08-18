using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dice : MonoBehaviour
{
    Rigidbody rb;

    bool hasLanded;
    bool thrown;

    Vector3 initPosition;

    public int diceValue;

    public DiceSide[] diceSides;

    Quaternion[] diceRotation =
    {
        Quaternion.Euler(new Vector3(270,0,0)), // 1
        Quaternion.Euler(new Vector3(180,0,0)), // 2
        Quaternion.Euler(new Vector3(0,0,270)), // 3
        Quaternion.Euler(new Vector3(0,0,90)),  // 4
        Quaternion.Euler(new Vector3(0,0,0)),   // 5 
        Quaternion.Euler(new Vector3(90,0,0)),  // 6
    };

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        initPosition = transform.position;
        rb.useGravity = false;

    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            RollDice();
        }

        if(rb.IsSleeping() && !hasLanded && thrown)
        {
            CancelInvoke();    // 버그가 안걸린다면 invoke 취소함
            hasLanded = true;
            rb.useGravity = false;
            rb.isKinematic = true;
            SideValueCheck();
        }
        else if(rb.IsSleeping() && hasLanded)
        {
            Reset();
        }
    }

    void RollDice()
    {
        // 버그방지 (임시로 쓰는중)
        Invoke("BugFix", 3);

        if (!thrown & !hasLanded)
        {
            thrown = true;
            rb.useGravity = true;
            rb.AddTorque(Random.Range(0, 500), Random.Range(0, 500), Random.Range(0, 500));
        }
        else if(thrown && hasLanded)
        {
            Reset();
        }

    }

    void Reset()
    {
        // transform.position = initPosition;        순간이동
        StartCoroutine(MoveTo(initPosition));       // 이동
        transform.rotation = diceRotation[diceValue - 1];
        thrown = false;
        hasLanded = false;
        rb.useGravity = false;
        rb.isKinematic = false;
    }

    void SideValueCheck()
    {
        diceValue = 0;
        foreach (DiceSide side in diceSides)
        {
            if(side.GetOnGround())
            {
                diceValue = side.sideValue;
                GameManager.CountDices(diceValue);
                GameManager.countHand += 1;
               // Debug.Log(diceValue);
            }
        }
    }

    IEnumerator MoveTo(Vector3 toPos)
    {
        float count = 0;
        Vector3 wasPos = transform.position;

        while(true)
        {
            count += Time.deltaTime;
            transform.position = Vector3.Lerp(wasPos, toPos, count * 10f);

            if(count >= 1)
            {
                transform.position = toPos;
                break;
            }

            yield return null;
        }
    }

    void BugFix()
    {
        hasLanded = true;
        rb.useGravity = false;
        rb.isKinematic = true;
        SideValueCheck();
        Reset();
    }

    private void OnEnable()
    {
        RollButton.Roll += this.RollDice;
    }
}
