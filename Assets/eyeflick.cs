using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ViveSR
{
    namespace anipal
    {
        namespace Eye
        {
            public class eyeflick : MonoBehaviour
            {

                EyeData eye;
                Ray CombineRay;
                /*レイがどこに焦点を合わせたかの情報．Vector3 point : 視線ベクトルと物体の衝突位置，float distance : 見ている物体までの距離，
                   Vector3 normal:見ている物体の面の法線ベクトル，Collider collider : 衝突したオブジェクトのCollider，Rigidbody rigidbody：衝突したオブジェクトのRigidbody，Transform transform：衝突したオブジェクトのTransform*/
                //焦点位置にオブジェクトを出すためにpublicにしています．
                public static FocusInfo CombineFocus;
                //レイの半径
                float CombineFocusradius;
                //レイの最大の長さ
                float CombineFocusmaxDistance;
                //オブジェクトを選択的に無視するために使用されるレイヤー ID
                int CombinefocusableLayer = 0;
                private int count=0;
                private Vector3 preangle = new Vector3();
                bool moving = false;
                
                
                void Start()
                {
                    Transform mytransform = this.transform;
                    Vector3 pos = mytransform.position;
                    preangle = Camera.main.transform.forward;


                }

                // Update is called once per frame
                void Update()
                {
                    Transform mytransform = this.transform;
                    Vector3 pos = mytransform.position;
                    SRanipal_Eye_API.GetEyeData(ref eye);
                    float ang = Vector3.Angle(preangle, Camera.main.transform.forward);
                    //Debug.Log(ang);
                    ;
                    if (SRanipal_Eye.Focus(GazeIndex.COMBINE, out CombineRay, out CombineFocus/*, CombineFocusradius, CombineFocusmaxDistance, CombinefocusableLayer*/ ))
                    {
                       // Debug.Log("Combine Focus Point" + CombineFocus.point.x + ", " + CombineFocus.point.y + ", " + CombineFocus.point.z);
                        Vector3 obj = CombineFocus.transform.position;

                        if (mytransform.position == obj)
                        {
                            count++;
                            
                            if (count >= 50)
                            {
                                mytransform.Rotate(0, 1, 0);
                                
                                
                                if (ang > 1 || moving) {
                                    moving = true;

                                    Vector3 mov = Vector3.Normalize(obj - Camera.main.transform.position);
                                    Vector3 Cro = Vector3.Cross(mov, Camera.main.transform.forward);
                                    //Debug.Log(mov+","+Cro);


                                     mytransform.RotateAround(Camera.main.transform.position, Cro, (float)0.2);
                                    if (Vector3.Angle(mov, Camera.main.transform.forward) < 0.01) { moving = false; }
                                }
                            }
                            
                        }
                        else
                        {
                            count = 0;
                            moving = false;
                        }
                    }
                    preangle = Camera.main.transform.forward;

                        
                }
            }
        }
    }
}
