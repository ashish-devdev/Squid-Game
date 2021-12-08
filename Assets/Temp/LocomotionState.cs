using Animancer;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LocomotionState : MonoBehaviour
{
    public LinearMixerTransition linearMixerTransition;
    public float fadeSpeed;

    public Button walkButton;
    public Button runButton;

    public float target;
    void Start()
    {
        walkButton.onClick.AddListener(() => { target = 0; });
        runButton.onClick.AddListener(() => { target = 1; });
    }

    void Update()
    {
        linearMixerTransition.State.Parameter = Mathf.MoveTowards(linearMixerTransition.State.Parameter, target, fadeSpeed * Time.deltaTime);
    }
}
