using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ViveSR
{
    namespace anipal
    {
        namespace Eye
        {
            public class eyegaze : MonoBehaviour
            {

                EyeData eye;
                Ray CombineRay;
                public static FocusInfo CombineFocus;
                
                //ÉåÉCÇÃîºåa
                float CombineFocusradius;
                //ÉåÉCÇÃç≈ëÂÇÃí∑Ç≥
                float CombineFocusmaxDistance;
                
                int CombinefocusableLayer = 0;
                private int count = 0;
                private Vector3 preangle = new Vector3();
                bool moving = false;
              
                int layerMask6 = 1 << 6;
                int layerMask7 = 1 << 7;
                private Vector3 eyec;
                
                Number Number;

                int Bnumber = 0;
                int Anumber = 10;
                GameObject NOB;
                GameObject BOB;
                Number number;
                int CirCount=0;
                void Start()
                {
                    Transform mytransform = this.transform;
                    Vector3 pos = mytransform.position;
                    preangle = Camera.main.transform.forward;
                    NOB = GameObject.Find("Quad0");
                    BOB = NOB;
                }

                // Update is called once per frame
                void Update()
                {

                    LayerMask layerMask = 1 << LayerMask.NameToLayer("target");
                    Transform mytransform = this.transform;
                    Vector3 pos = mytransform.position;
                    SRanipal_Eye_API.GetEyeData(ref eye);


                    if (SRanipal_Eye.Focus(GazeIndex.COMBINE, out CombineRay, out CombineFocus, 0, Mathf.Infinity, layerMask/*, CombineFocusradius, CombineFocusmaxDistance, CombinefocusableLayer*/ ))
                    {
                        
                        if (transform.position == CombineFocus.transform.position)
                        {

                            Ray ray2 = new Ray(Camera.main.transform.position, Camera.main.transform.forward);
                            RaycastHit CombineFocus2;
                            Physics.Raycast(ray2, out CombineFocus2, Mathf.Infinity);
                            // Debug.Log("Combine Focus Point" + CombineFocus.point.x + ", " + CombineFocus.point.y + ", " + CombineFocus.point.z);
                            Vector3 obj = CombineFocus2.transform.position;
                            GameObject OB = CombineFocus2.collider.gameObject;
                            Debug.Log(OB);
                            if (BOB != OB)
                            {
                                number = OB.GetComponent<Number>();
                                Anumber = number.step;
                                Debug.Log(Anumber);
                                BOB = OB;

                                if (Bnumber + 1 == Anumber)
                                {
                                    CirCount++;
                                }
                                else if (Bnumber == 4 && Anumber == 1)
                                {
                                    CirCount++;
                                }
                                else
                                {
                                    CirCount = 0;
                                }
                            }
                            if (CirCount == 5)
                            {

                                Random.InitState(System.DateTime.Now.Millisecond);
                                    byte R = (byte)Random.Range(1.0f,255.0f);
                                Random.InitState(System.DateTime.Now.Millisecond*10);
                                byte G = (byte)Random.Range(1.0f, 255.0f);
                                Random.InitState(System.DateTime.Now.Millisecond * 10);
                                byte B = (byte)Random.Range(1.0f, 255.0f);


                                GetComponent<Renderer>().material.color = new Color32(R,G,B, 1);
                                Debug.Log("success");
                                CirCount = 0;
                            }
                            Bnumber = Anumber;
                           
                        }

                    }    



                    /* Vector3 minu = pos - eyec;
                    //Debug.Log(minu.magnitude);
                    if (minu.magnitude < 1)
                    {
                        Debug.Log("No");
                    } */
                    


                }
            }
        }
    }
}
