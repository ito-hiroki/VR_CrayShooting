using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class target : MonoBehaviour {

    public GameObject controller;
    public int targetSpeed;

    // Use this for initialization
    void Start () {
        this.GetComponent<Rigidbody>().useGravity = false;
    }
	
	// Update is called once per frame
	void Update ()
    {
        var trackedObject = controller.GetComponent<SteamVR_TrackedObject>();
        var device = SteamVR_Controller.Input((int)trackedObject.index);

        if (device.GetPressDown(SteamVR_Controller.ButtonMask.Grip))
        {
            Debug.Log("グリップボタンをクリックした");
            this.GetComponent<Rigidbody>().useGravity = true;

            Vector3 force;
            force = this.gameObject.transform.forward * targetSpeed;
            this.GetComponent<Rigidbody>().AddForce(force);
        }

        // テスト用
        if (device.GetPressDown(SteamVR_Controller.ButtonMask.ApplicationMenu))
        {
            SceneManager.LoadScene(0);
        }
    }

    private void OnTriggerEnter(Collider coll)
    {
        var trackedObject = controller.GetComponent<SteamVR_TrackedObject>();
        var device = SteamVR_Controller.Input((int)trackedObject.index);

        if (coll.gameObject.tag == "Bullet")
        {
            Debug.Log("Hit");
            device.TriggerHapticPulse(1000);
            Destroy(coll.gameObject);
            // Destroy(this.gameObject);
        }
    }
}
