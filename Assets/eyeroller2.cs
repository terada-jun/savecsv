
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

namespace ViveSR
{
    namespace anipal
    {
        namespace Eye
        {
            public class eyeroller2 : MonoBehaviour
            {

                static EyeData_v2 eye;
                private bool eye_callback_registered = false;
                Ray CombineRay;

                public static FocusInfo CombineFocus;



                //¶‚Ì‚Ü‚Ô‚½‚ÌŠJ‚«‹ï‡Ši”[—pŠÖ”
                float LeftBlink;
                //‰E‚Ì‚Ü‚Ô‚½‚ÌŠJ‚«‹ï‡Ši”[—pŠÖ”
                float RightBlink;
                private int count = 0;
                private Vector3 preangle = new Vector3();
                bool moving = false;
                public GameObject eyetarget;
                public Camera MAIN;


                void Start()
                {


                    Vector3 pos = transform.position;
                    Vector3 player_ang = transform.eulerAngles;

                    pos.x -= Camera.main.transform.localPosition.x;
                    pos.z -= Camera.main.transform.localPosition.z;
                    pos.y = transform.position.y;


                    transform.position = pos; ;


                }

                // Update is called once per frame
                void Update()
                {

                    if (SRanipal_Eye_Framework.Status != SRanipal_Eye_Framework.FrameworkStatus.WORKING &&
                         SRanipal_Eye_Framework.Status != SRanipal_Eye_Framework.FrameworkStatus.NOT_SUPPORT) return;

                    if (SRanipal_Eye_Framework.Instance.EnableEyeDataCallback && !eye_callback_registered)
                    {
                        SRanipal_Eye_v2.WrapperRegisterEyeDataCallback(
                            Marshal.GetFunctionPointerForDelegate((SRanipal_Eye_v2.CallbackBasic)EyeCallback));

                        eye_callback_registered = true;
                    }
                    else if (!SRanipal_Eye_Framework.Instance.EnableEyeDataCallback && eye_callback_registered)
                    {
                        SRanipal_Eye_v2.WrapperUnRegisterEyeDataCallback(
                            Marshal.GetFunctionPointerForDelegate((SRanipal_Eye_v2.CallbackBasic)EyeCallback));

                        eye_callback_registered = false;
                    }

                    Transform mytransform = eyetarget.transform;
                    Vector3 pos = mytransform.position;
                    Vector3 ang_cam = MAIN.transform.localEulerAngles;
                    Vector3 ang_pla = transform.eulerAngles;

                    //SRanipal_Eye_API.GetEyeData_v2(ref eye);
                    GetEyeFocus(GazeIndex.COMBINE);
                    if (CombineFocus.collider.gameObject!= null)
                    {
                        
                    
                        if (CombineFocus.collider.gameObject.name == eyetarget.name)
                        {

                            Debug.Log(CombineFocus.collider.gameObject.name);
                            count++;
                            if (count >= 20)
                            {



                                if (ang_cam.y > 10 && ang_cam.y < 90)
                                {

                                    ang_pla.y = ang_pla.y + (float)0.6;



                                }
                                else if (ang_cam.y > 270 && ang_cam.y < 350)
                                {
                                    ang_pla.y = ang_pla.y - (float)0.6;
                                }
                                transform.eulerAngles = ang_pla;


                            }





                        }
                        else { count = 0; }


                    }
                    /*  if (SRanipal_Eye_v2.Focus(GazeIndex.COMBINE, out CombineRay, out CombineFocus ))
                      {

                          Vector3 obj = CombineFocus.transform.position;

                          if (CombineFocus.collider.gameObject.name == eyetarget.name)
                          {

                              count++;
                              if (count >= 20)
                              {



                                  if (ang_cam.y > 10 && ang_cam.y < 90)
                                  {

                                      ang_pla.y = ang_pla.y + (float)0.6;



                                  }
                                  else if (ang_cam.y > 270 && ang_cam.y < 350)
                                  {
                                      ang_pla.y = ang_pla.y - (float)0.6;
                                  }
                                  transform.eulerAngles = ang_pla;


                              }





                          }
                          else { count = 0; }



                      }
                      else if (count > 60) 
                    {
                            if (SRanipal_Eye_v2.GetEyeOpenness(EyeIndex.LEFT, out LeftBlink, eye) && SRanipal_Eye_v2.GetEyeOpenness(EyeIndex.RIGHT, out RightBlink, eye))
                            {
                                if (LeftBlink == 0 && RightBlink == 0)
                                {

                                    count++;
                                }
                            }
                        }
                        else { count = 0; }
                    */

                }
                private float GetEyeOpenness(EyeIndex eyeIndex)
                {
                    SRanipal_Eye_v2.GetEyeOpenness(eyeIndex, out var openness, eye);
                    return openness;
                }
                private void GetEyeFocus(GazeIndex eyeIndex)
                {
                    SRanipal_Eye_v2.Focus(GazeIndex.COMBINE, out CombineRay, out CombineFocus);
                    
                }
                private static void EyeCallback(ref EyeData_v2 eye_data)
                {
                    eye = eye_data;
                }

            }
        }
        
    }
}