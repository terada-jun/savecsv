using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;
public class angle : MonoBehaviour
{

    public SteamVR_Action_Vector2 angl;
    public GameObject CAM;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        var _center = CAM.transform.position;
        var Y_axis = CAM.transform.right;
        var X_axis = CAM.transform.up;
        Y_axis.y = 0;
        X_axis.x = 0;
        X_axis.z = 0;

        Vector3 ang = transform.eulerAngles;
        if (angl.axis.x > 0.7 || angl.axis.x < -0.7)
        {
            // ang.y += (float)0.3 * (angl.axis.x / Mathf.Abs(angl.axis.x));
            transform.RotateAround(_center, X_axis, (float)0.2 * angl.axis.x / Mathf.Abs(angl.axis.x));
        }
        if (angl.axis.y > 0.7 || angl.axis.y < -0.7)
        {
            transform.RotateAround(_center, Y_axis, (float)-0.2 * angl.axis.y / Mathf.Abs(angl.axis.y));
            //ang.x += (float)0.3 * (angl.axis.y / Mathf.Abs(angl.axis.y));
        }


        //transform.eulerAngles = ang;
    }
}
