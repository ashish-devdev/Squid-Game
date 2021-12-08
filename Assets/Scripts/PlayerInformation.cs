using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerInformation : MonoBehaviour
{
    public int numberOfPlayer;
    public GameManager gameManager;
    public List<Player> players;
    public List<TextMeshPro> playerNameTMP;


    void Start()
    {
        numberOfPlayer = gameManager.numberOfPlayer;
        players = new List<Player>(new Player[numberOfPlayer]);
        for (int i = 0; i < numberOfPlayer; i++)
        {
            players[i] = new Player(i);
            playerNameTMP[i].text = players[i].name;
        }
    }

    void Update()
    {

    }

    [System.Serializable]
    public class Player
    {
        public string name;



        public Player(int i)
        {
            name = "Player "+i;
        }
    }

    public void AssignPlayerInfo(List<string> name)
    {
        for (int i = 0; i < players.Count; i++)
        {
            players[i].name = name[i];
            playerNameTMP[i].text = players[i].name;
        }

    }

}
