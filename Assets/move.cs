using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using Valve.VR;
using ViveSR.anipal.Eye;

public class move : MonoBehaviour
{
    EyeData eye;


    public SteamVR_Action_Vector2 roll;

    // Start is called before the first frame update
    void Start()
    {

        ;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        Vector3 pos = transform.position;

        Vector3 Direction = Camera.main.transform.forward;


        if (roll.axis.y > 0.7)
        {
            pos.x += (float)0.05 * Direction.x;
            pos.z += (float)0.05 * Direction.z;
            pos.y += (float)0.05 * Direction.y;
        }



        transform.position = pos;

    }
}

