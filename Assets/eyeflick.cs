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
                /*���C���ǂ��ɏœ_�����킹�����̏��DVector3 point : �����x�N�g���ƕ��̂̏Փˈʒu�Cfloat distance : ���Ă��镨�̂܂ł̋����C
                   Vector3 normal:���Ă��镨�̖̂ʂ̖@���x�N�g���CCollider collider : �Փ˂����I�u�W�F�N�g��Collider�CRigidbody rigidbody�F�Փ˂����I�u�W�F�N�g��Rigidbody�CTransform transform�F�Փ˂����I�u�W�F�N�g��Transform*/
                //�œ_�ʒu�ɃI�u�W�F�N�g���o�����߂�public�ɂ��Ă��܂��D
                public static FocusInfo CombineFocus;
                //���C�̔��a
                float CombineFocusradius;
                //���C�̍ő�̒���
                float CombineFocusmaxDistance;
                //�I�u�W�F�N�g��I��I�ɖ������邽�߂Ɏg�p����郌�C���[ ID
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
