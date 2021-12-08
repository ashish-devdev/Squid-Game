using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FiringManger : MonoBehaviour
{
    GameObject bulletParent;

    public List<GameObject> guns;
    public GameObject gameObjectToHit;
    [SerializeField]
    public static float bulletSpeed = 50f;



    private void OnEnable()
    {


    }

    public void FireBullet()
    {
        bulletParent = GetNearestGun().transform.GetChild(0).GetChild(0).gameObject;
        for (int i = 0; i < bulletParent.transform.childCount; i++)
        {
            if (!bulletParent.transform.GetChild(i).gameObject.activeInHierarchy)
            {
                bulletParent.transform.GetChild(i).GetComponent<Bullet>().target = gameObjectToHit;
                bulletParent.transform.GetChild(i).gameObject.SetActive(true);
                break;
            }
        }



    }

    public GameObject GetNearestGun()
    {
        float minDis = 99999999;
        float dis;
        GameObject minDisGun = new GameObject();
        for (int i = 0; i < guns.Count; i++)
        {
            dis = Vector3.Distance(guns[i].transform.position, gameObjectToHit.transform.position);
            if (minDis > dis)
            {
                minDis = dis;
                minDisGun = guns[i];
            }

        }
        return minDisGun;
    }

}
