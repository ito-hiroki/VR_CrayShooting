using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class printLine : MonoBehaviour {

    public GameObject lineObj;
    LineRenderer line;
    int lineLength = 5;

    // Use this for initialization
    void Start()
    {
        line = lineObj.GetComponent<LineRenderer>();
    }

    void Update()
    {
        // Debug.Log(this.transform.position.ToString());

        Vector3 pos0 = this.transform.position;
        Vector3 pos1 = this.transform.position;
        Vector3 dir = new Vector3Int(0, 0, 1);
        pos1 += this.transform.rotation * dir * lineLength;
        line.SetPosition(0, pos0);
        line.SetPosition(1, pos1);
    }
}
