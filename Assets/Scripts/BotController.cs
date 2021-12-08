using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BotController : PlayerController
{
    // Start is called before the first frame update
    void Start()
    {
    }
    private void OnEnable()
    {
        timer = 0;
        toggle = false;
    }

    float timer=0;
    int r;
    bool toggle;
    public static bool isBotAllowedToMove;

    // Update is called once per frame
    void Update()
    {
        r = Random.Range(1, 19);

        if (!GameManager.gameStarted)
            return;


        if (isBotAllowedToMove)
        {
            timer += Time.deltaTime;

            if (toggle)
            {
                if (r % 3 == 0)
                {
                    MakeBotRun();
                }
                else
                {
                    MakeBotMove();
                }
                isBotAllowedToMove = false;
            }
        }
        if (timer > 2)
        {
            toggle = !toggle;
            timer = 0;
        }

        if (isHumanMoving && shouldCharecterRun)
        {
            p = 1;
        }
        else if (isHumanMoving && !shouldCharecterRun)
        {
            p = 0.5f;
        }
        else
        {
            p = 0f;
        }

        AnimateCharcter();


        if (isHumanMoving)
        {
            MoveCharecter(charecter, shouldCharecterRun);
            RotateCharecter();
        }
        else
            StopCharecter();


    }

    public void MakeBotMove()
    {
        isHumanMoving = true;
        shouldCharecterRun = false;
    }

    public void MakeBotRun()
    {
        MakeBotMove();
        shouldCharecterRun = true;
    }

    public void MakeBotStop()
    {
        isBotAllowedToMove = false;
        isHumanMoving = false;
        shouldCharecterRun = false;

    }

    public void InvokeAllowBotMovementWithDelay()
    {
        Invoke(nameof(AllowBotMovement), Random.Range(0.01f, 0.5f));
    }

    public void AllowBotMovement()
    {
        isBotAllowedToMove = true;
    }

    public void InvokeStopBotMovementWithDelay()
    {
        Invoke(nameof(MakeBotStop), Random.Range(0.01f, 1f));
    }


}
