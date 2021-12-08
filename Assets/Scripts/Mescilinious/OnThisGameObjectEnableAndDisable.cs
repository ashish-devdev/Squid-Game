using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class OnThisGameObjectEnableAndDisable : MonoBehaviour
{

    public UnityEvent OnThisGameObjectEnable;
    public UnityEvent OnThisGameObjectEnableWithDelay;
    public UnityEvent OnThisGameObjectDisable;

    private void OnEnable()
    {
        OnThisGameObjectEnable.Invoke();
        Invoke(nameof(OnEnableWithDelay), 0.01f);
    }

    public void OnEnableWithDelay()
    {
        OnThisGameObjectEnableWithDelay.Invoke();
    }

    private void OnDisable()
    {
        OnThisGameObjectDisable.Invoke();
    }
}
