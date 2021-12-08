using Lean.Transition;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TranslateGameObject : MonoBehaviour
{

    public Transform target;

    void Start()
    {

    }

    void Update()
    {

    }

    public void MakeGameObjectMoveTowardotherObject()
    {
        if (target != null)
            transform.positionTransition(new Vector3(target.position.x, target.position.y+3, target.position.z-3), 5f);
        //    transform.RotateTransition(new Vector3(0,0,0), 0.1f);
    }

}
