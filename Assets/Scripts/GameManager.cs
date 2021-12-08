using Lean.Gui;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameManager : MonoBehaviour
{
    public DollController dollController;
    public LeanToggle toggleSkeletonAlpha;
    public List<PlayerController> playerControllers;
    public MotionManager motionManager;
    public int numberOfPlayer;
    public SkeletonController skeletonController;
    public List<GameObject> charecters;
    public List<Position> charecterDefaultPosBasedOnNumberOfPlayers;
    public static bool gameStarted;
    public static bool gameEnded;
    public GameObject singlePlayerCamera;
    public GameObject multiplayerCamera; 

    public UnityEvent onGameStart;
    public UnityEvent onGameEnds;

    [System.Serializable]
    public class Position
    {
        public string numberOfPlayers;//for inspector only
        public List<Vector3> pos;
    }

    private void OnEnable()
    {
        if (numberOfPlayer == 1)
        {
            singlePlayerCamera.SetActive(true);
            multiplayerCamera.SetActive(false);
        }
        else
        {
            singlePlayerCamera.SetActive(false);
            multiplayerCamera.SetActive(true);
        }

        skeletonController.skeletonCount = numberOfPlayer;
        motionManager.playerControllers = new List<PlayerController>(new PlayerController[numberOfPlayer]);
        for (int i = 0; i < numberOfPlayer; i++)
        {
            motionManager.playerControllers[i] = new PlayerController();
            motionManager.playerControllers[i] = playerControllers[i];
        }

        PositionCharecterBasedOnNumberOfPlayers();

        gameStarted = false;
        gameEnded = false;

    }






    private void Start()
    {
        var sensor = nuitrack.DepthSensor.Create();
        sensor.SetMirror(true);

    }


    private void Update()
    {

        if (Input.GetKeyDown(KeyCode.Space))
        {
            onGameStart.Invoke();
        }

        if (Input.GetKeyDown(KeyCode.C))
        {
            
        }

        

    }



    public void StartGame()
    {
        gameStarted = true;
        MakeHeadRotateAfterIntervals();
    }

    public void MakeHeadRotateAfterIntervals()
    {
        if (gameEnded)
            return;

        try
        {
            CancelInvoke(nameof(MakeHeadRotateAfterIntervals));
        }
        catch
        {
            ;
        }
        dollController.ToggelDollHeadRotation();

        float randomTime = Random.Range(dollController.minTime, dollController.maxTime);
        print(randomTime);
        Invoke(nameof(MakeHeadRotateAfterIntervals), randomTime);
    }

    private void OnGUI()
    {
        Event e = Event.current;

        if (e.keyCode == KeyCode.E)
        {
            toggleSkeletonAlpha.TurnOn();
        }

        if (e.keyCode == KeyCode.Q)
        {
            toggleSkeletonAlpha.TurnOff();
        }
    }

    public void PositionCharecterBasedOnNumberOfPlayers()
    {

        for (int i = 0; i < numberOfPlayer; i++)
        {
            charecters[i].SetActive(true);
            charecters[i].transform.localPosition = charecterDefaultPosBasedOnNumberOfPlayers[numberOfPlayer-1].pos[i];
        }
    }







}
