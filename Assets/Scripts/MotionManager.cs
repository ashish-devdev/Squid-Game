using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MotionManager : MonoBehaviour
{
    public SimpleSkeletonAvatar simpleSkeletonAvatar;
    public SkeletonController skeletonController;
    public GameObject skeletonsParent;
    public List<PlayerController> playerControllers;
    public List<Human> human;
    public List<float> frameCount;
    public SkeletonPositionDetectorAndMapper skeletonPositionDetectorAndMapper;
    public List<bool> humanConnected;


    public float minRateOfMovemetForWalking = 50f;

    public float minRateOfMovemetForRunning;

    int j;

    [System.Serializable]
    public class Human
    {
        public bool detected;
        public bool isInProperPos;
        public Vector3 currentPosition;
        public Vector3 previousPosition;
        public float distance;
        public float rateOfMovement;
        public float tiltAngle;
        public float timer = 0;
    }

    void Start()
    {
        human = new List<Human>(new Human[playerControllers.Count]);
        for (int i = 0; i < human.Count; i++)
        {
            human[i] = new Human();
        }
        frameCount = new List<float>(new float[human.Count]);
        humanConnected = new List<bool>(new bool[human.Count]);

    }



    void Update()
    {

        for (int i = 0; i < humanConnected.Count; i++)
        {
            humanConnected[i] = false;
        }

        for (int i = 0; i < playerControllers.Count; i++)
        {
            SimpleSkeletonAvatar a = skeletonController.avatars[i];

            // basically checks if the motion of the body part is enough to moving the charecter(walking or running) or not.
            //{=============================================================================================================
            if (skeletonsParent.transform.GetChild(i).gameObject.activeInHierarchy)
            {
                j = skeletonPositionDetectorAndMapper.GetCharecterBasedOnSkeletonsPosition(skeletonController.avatars[i].joints[skeletonController.avatars[i].jointsInformation[4]].transform.position.x);
                humanConnected[j] = true;

                frameCount[j]++;

                human[j].timer = human[j].timer + Time.deltaTime;

                if (human[j].detected == false)
                {
                    human[j].detected = true;
                    human[j].currentPosition = skeletonController.avatars[i].joints[skeletonController.avatars[i].jointsInformation[0]].transform.position;
                    human[j].previousPosition = human[j].currentPosition;
                    human[j].tiltAngle = GetTiltedAngel(skeletonController.avatars[i].joints[skeletonController.avatars[i].jointsInformation[2]].transform.position, skeletonController.avatars[i].joints[skeletonController.avatars[i].jointsInformation[3]].transform.position);

                }
                else
                {
                    human[j].currentPosition = skeletonController.avatars[i].joints[skeletonController.avatars[i].jointsInformation[0]].transform.position;
                    human[j].tiltAngle = GetTiltedAngel(skeletonController.avatars[i].joints[skeletonController.avatars[i].jointsInformation[2]].transform.position, skeletonController.avatars[i].joints[skeletonController.avatars[i].jointsInformation[3]].transform.position);
                }

                human[j].distance = (human[j].currentPosition - human[j].previousPosition).magnitude;
                human[j].rateOfMovement += (human[j].distance / Time.deltaTime);

                human[j].previousPosition = human[j].currentPosition;
                if (human[j].timer > 0.25f)
                {
                    human[j].rateOfMovement = human[j].rateOfMovement / frameCount[j];

                    if (human[j].rateOfMovement > minRateOfMovemetForWalking)
                    { 
                        playerControllers[j].isHumanMoving = true;
                        playerControllers[j].tiltAngle = human[j].tiltAngle;
                    }
                    else
                        playerControllers[j].isHumanMoving = false;

                    if (human[j].rateOfMovement > minRateOfMovemetForRunning)
                        playerControllers[j].shouldCharecterRun = true;
                    else
                        playerControllers[j].shouldCharecterRun = false;


                    human[j].timer = 0;
                    human[j].rateOfMovement = 0;
                    frameCount[j] = 0;



                }

            }
            //===============================================================================================================}

        }


        for (int i = 0; i < playerControllers.Count; i++)
        {
            if (!humanConnected[i])
            {

                frameCount[i] = 0;
                human[i].timer = 0;
                human[i].rateOfMovement = 0;
                playerControllers[i].isHumanMoving = false;
                human[i].detected = false;

            }
        }

    }

    public float GetTiltedAngel(Vector3 collarPosition, Vector3 torsoPosition)
    {
        float rad = 0,angle=0;
        rad = Mathf.Atan2((torsoPosition.y - collarPosition.y) , (torsoPosition.x - collarPosition.x));
        angle=rad*(180/Mathf.PI);

        return angle;
    }



}
