using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    public GameObject target;
    public GameObject ball;
    public ParticleSystem particleSystem;


    private void OnEnable()
    {
    }


    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject==target)
        {
            ball.gameObject.SetActive(false);
            particleSystem.Play();

            Invoke(nameof(ResetPosition), 0.5f);

        }
    }

    public void ResetPosition()
    {
        this.gameObject.SetActive(false);
        this.gameObject.transform.localPosition = new Vector3(0, 0, 0);
        ball.SetActive(true);
    }


    private void FixedUpdate()
    {
        transform.position = Vector3.MoveTowards(transform.position,new Vector3(target.transform.position.x, target.transform.position.y+1f, target.transform.position.z), FiringManger.bulletSpeed * Time.deltaTime);
    }

 

}
