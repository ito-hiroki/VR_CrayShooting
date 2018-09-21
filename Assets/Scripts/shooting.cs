using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shooting : MonoBehaviour {

    public GameObject bulletPrefab;

    public float speed = 1000;

    void Update()
    {
        var trackedObject = GetComponent<SteamVR_TrackedObject>();
        var device = SteamVR_Controller.Input((int)trackedObject.index);

        if (device.GetPressDown(SteamVR_Controller.ButtonMask.Trigger))
        {
            Debug.Log("トリガーを深く引いた");

            GameObject bullet = Instantiate(bulletPrefab) as GameObject;

            bullet.transform.position = this.transform.position;
            bullet.transform.rotation = this.transform.rotation;
            bullet.transform.Rotate(new Vector3(90, 0, 0) , Space.Self);

            Vector3 force;
            force = this.gameObject.transform.forward * speed;
            bullet.GetComponent<Rigidbody>().AddForce(force);
            
        }
    }
}
