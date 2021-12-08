using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkeletonPositionDetectorAndMapper : MonoBehaviour
{
    public List<Image> skltnDetectotImg;
    public MotionManager motionManager;
    public GameObject skeletonParent;
    public List<PositionBoundary> positionBoundary;
    public SkeletonController skeletonController;

    [System.Serializable]
    public class PositionBoundary
    {
        public float minX;
        public float maxX;

    }


    void Start()
    {
        positionBoundary = new List<PositionBoundary>(new PositionBoundary[skeletonParent.transform.childCount]);
        for (int i = 0; i < skeletonParent.transform.childCount; i++)
        {
            positionBoundary[i] = new PositionBoundary();
            positionBoundary[i].minX = i * Screen.width / skeletonParent.transform.childCount;
            positionBoundary[i].maxX = (i + 1) * Screen.width / skeletonParent.transform.childCount;
        }
    }



    void Update()
    {
        if (motionManager.human != null)
        {
            for (int i = 0; i < motionManager.human.Count; i++)
            {
                if (motionManager.human[i].detected)
                {
                    skltnDetectotImg[i].color = new Color(0, 1, 0);
                }
                else
                {
                    skltnDetectotImg[i].color = new Color(1, 0, 0);
                }
            }
        }


        //if(skeletonParent.gameObject.)


    }


    public int GetCharecterBasedOnSkeletonsPosition(float posX)
    {
        int i;
        for (i = 0; i < skeletonParent.transform.childCount; i++)
        {
            if (posX > positionBoundary[i].minX && posX < positionBoundary[i].maxX)
            {
                break;
            }
        }
        return i;
    }



}
