using Lean.Gui;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishLine : MonoBehaviour
{
    public RotateAround rotateAround;
    public TranslateGameObject translateGameObject;
    public GameManager gameManager;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private void OnTriggerEnter(Collider collision)
    {


        if (collision.transform.tag == "Charecter")
        {
            collision.transform.GetComponent<PlayerController>().crossesFinishLine = true;
            rotateAround.pivotObject = collision.transform.gameObject;
            translateGameObject.target = collision.transform;

            GameManager.gameEnded = true;
            gameManager.onGameEnds.Invoke();
        }



    }
}
