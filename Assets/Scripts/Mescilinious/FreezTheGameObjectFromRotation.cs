using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FreezTheGameObjectFromRotation : MonoBehaviour
{
    public GameObject player;
    Vector3 orignalRotation;
    public float xOffset;
    public float yOffset;

    private Vector3 offset;
    void Start()
    {
        orignalRotation = transform.eulerAngles;
        offset = transform.position - player.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
       // transform.eulerAngles = orignalRotation;
    }

    void LateUpdate()
    {

        transform.localPosition = new Vector3(player.transform.localPosition.x, player.transform.localPosition.y + xOffset, player.transform.localPosition.z + yOffset);
     //   transform.LookAt(player.transform);
    }

}
