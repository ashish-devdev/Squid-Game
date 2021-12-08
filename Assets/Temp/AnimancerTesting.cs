using Animancer;
using Animancer.Examples.Locomotion;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AnimancerTesting : MonoBehaviour
{
    public LinearMixerLocomotion linearMixerLocomotion;
    public MotionManager motionManager;

    public GameObject prisioner;
    public Button walkButton;
    public Button runButton;
    public Button idleButton;

    float p;
    public float speed;
    public float prisionerSpeed;

    float trinary;
    public float fadeSpeed;

    private void Start()
    {
        walkButton.onClick.AddListener(() =>
        {
            p = 0.5f;
        });

        runButton.onClick.AddListener(() =>
        {
            p = 1;

        });

        idleButton.onClick.AddListener(() =>
        {
            p = 0;

        });
    }

    private void Update()
    {
        for (int i = 0; i < motionManager.human.Count; i++)
        {

            if (motionManager.human[0].rateOfMovement > 500)
            {
                p = 1;
                print(111111);
            }

            else if (motionManager.human[0].rateOfMovement > 50)
            {
                p = 0.5f;
                // linearMixerLocomotion.MixerStateParameter = 0.5f;
            }
            else
            {
                p = 0f;
                //  linearMixerLocomotion.MixerStateParameter = 0;
                print(00000);
            }
        }

        trinary = Mathf.MoveTowards(trinary, p, fadeSpeed * Time.deltaTime);
        prisioner.transform.Translate(new Vector3(0, 0, trinary * prisionerSpeed));
        linearMixerLocomotion.MixerStateParameter = Mathf.MoveTowards(linearMixerLocomotion.MixerStateParameter, p, speed * Time.deltaTime);

        if (linearMixerLocomotion.MixerStateParameter < 0.5f && p==0)
        {
            trinary = Mathf.MoveTowards(trinary, p, 5 * fadeSpeed * Time.deltaTime);
            prisioner.transform.Translate(new Vector3(0, 0, trinary * prisionerSpeed));
        }
    }

}
