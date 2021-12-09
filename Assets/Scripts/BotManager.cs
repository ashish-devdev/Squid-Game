using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BotManager : MonoBehaviour
{
    [Range(0, 8)]
    public int numberOfBot;
    public GameObject botsParent;
    public List<BotController> botControllers;
    void Start()
    {
        SpawnBot();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void SpawnBot()
    {
        botControllers = new List<BotController>(new BotController[numberOfBot]);
        for (int i = 0; i < numberOfBot; i++)
        {
            botControllers[i] = new BotController();
        }
        for (int i = 0; i < numberOfBot; i++)
        {
            int r = Random.Range(0, botsParent.transform.childCount);
            if (botsParent.transform.GetChild(r).gameObject.activeInHierarchy)
            {
                i--;
                continue;
            }
            else
            {
                botsParent.transform.GetChild(r).gameObject.SetActive(true);
                botControllers[i] = botsParent.transform.GetChild(r).GetChild(1).GetComponent<BotController>();
                botsParent.transform.GetChild(r).GetChild(1).GetChild(0).GetComponent<TextMeshPro>().text = "Bot " + i;
            }
        }

    }

    public void MakeAllBotsStop()
    { 
        for (int i = 0; i < numberOfBot; i++)
        {
            botControllers[i].InvokeStopBotMovementWithDelay();
        }
        
    }

    public void AllowAllBotsToMove()
    {
        for (int i = 0; i < numberOfBot; i++)
        {
            botControllers[i].InvokeAllowBotMovementWithDelay();
        }
    }




}
