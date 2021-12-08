using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MakeTextLookAtAvailableCamera : MonoBehaviour
{

    public List<Camera> cameras;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < cameras.Count; i++)
        {
            if (cameras[i].gameObject.activeInHierarchy)
            {
                this.gameObject.transform.LookAt(cameras[i].transform);
                this.gameObject.transform.localEulerAngles = new Vector3(0, this.gameObject.transform.localEulerAngles.y - 180, 0);
                //   this.gameObject.transform.eulerAngles = new Vector3(this.gameObject.transform.eulerAngles.x, this.gameObject.transform.eulerAngles.y-180, this.gameObject.transform.eulerAngles.z);
                break;
            }
        }

    }
}
