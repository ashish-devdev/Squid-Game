using Animancer.Examples.Locomotion;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [HideInInspector]
    public float rotaionAngle;
    public GameObject charecter;
    public bool isHumanMoving;
    public bool shouldCharecterRun;
    public float walkingSpeed;
    public float runningSpeed;
    [Range(-45f, -135f)]
    public float tiltAngle;

    public bool crossesFinishLine;


    public LinearMixerLocomotion linearMixerLocomotion;
    [HideInInspector]
    public float p;
    [HideInInspector]
    private float trinary = 0;
    public float fadeSpeed;

    void Start()
    {

    }
    private void OnEnable()
    {
        trinary = 0;
        crossesFinishLine = false;
    }

    void Update()
    {
        if (GameManager.gameEnded && !crossesFinishLine)
        {
            p = 0;
            AnimateCharcter();
            return;
        }

        if (!GameManager.gameStarted)
            return;

        if (crossesFinishLine)
        {
            p = -0.5f;
            AnimateCharcter();
            return;
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



    public void AnimateCharcter()
    {
     /*   if (p == -0.5f)
        {
            trinary = Mathf.MoveTowards(trinary, p, fadeSpeed * Time.deltaTime);
            linearMixerLocomotion.MixerStateParameter = Mathf.MoveTowards(linearMixerLocomotion.MixerStateParameter, p, 0.7f * Time.deltaTime);
            return;
        }*/

        
        linearMixerLocomotion.MixerStateParameter = Mathf.MoveTowards(linearMixerLocomotion.MixerStateParameter, p, 0.7f * Time.deltaTime);
        if (linearMixerLocomotion.MixerStateParameter < 0.5f && p == 0)
        {
            trinary = Mathf.MoveTowards(trinary, p, 5 * fadeSpeed * Time.deltaTime);
        }

    }

    public void MoveCharecter(GameObject charecter, bool running)
    {
        if (running)
            charecter.transform.Translate(charecter.transform.forward * runningSpeed * Time.deltaTime);
        else
            charecter.transform.Translate(charecter.transform.forward * walkingSpeed * Time.deltaTime);


    }
    public void StopCharecter()
    {
        charecter.transform.Translate(new Vector3(0, 0, 0.01f * trinary * walkingSpeed));
    }

    public void RotateCharecter()
    {
        float temp;

        if (tiltAngle > -45)
        {
            tiltAngle = -45;
        }
        if (tiltAngle < -135)
        {
            tiltAngle = -135;
        }

        if (tiltAngle >= -90)
        {
            temp = Mathf.InverseLerp(-45, -90, tiltAngle);
            rotaionAngle = Mathf.Lerp(-40, 0, temp);
        }
        else
        {
            temp = Mathf.InverseLerp(-90, -135, tiltAngle);
            rotaionAngle = Mathf.Lerp(0, 40, temp);
        }

        charecter.transform.localEulerAngles=new Vector3(0,rotaionAngle,0);


    }


}
