using Lean.Gui;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DollController : MonoBehaviour
{
    // Start is called before the first frame update3
    public float minTime;
    public float maxTime;
    public LeanToggle LeanRotateDollHead;
    public void ToggelDollHeadRotation()
    {
        LeanRotateDollHead.Toggle();
    }

}
