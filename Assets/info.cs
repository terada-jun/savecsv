
using UnityEngine;
//���̃X�N���v�g�͎�肽���ϐ�������I�u�W�F�N�g�ɓ\��Ƃ悢
//�@���̃X�N���v�g�ł́A�L�^�������ϐ����w��ł���
//�A�܂��L�^�̊Ԋu�i�t���[���j���w��ł���
//Unity����Inspector�Ōv���J�n�ƏI�����s����B

[ExecuteInEditMode]
public class info : MonoBehaviour
{
    
    private float time;

    public GameObject SaveCsv; //Unity��Inspector�� SampleSaveCsvScript��\��t�����I�u�W�F�N�g���w�肷�邱��
    SampleSaveCsvScript SampleSaveCsvScript;

    [System.NonSerialized]
    public int cou = 0;
    [System.NonSerialized]
    public int num = -1;
    [System.NonSerialized]
    public bool calledone = false;


    void Start()
    {
        
        SampleSaveCsvScript = SaveCsv.GetComponent<SampleSaveCsvScript>();

    }


    public void starter()
    {
        num++;
        Debug.Log(num);
        cou = 0;
        calledone = false;

    }


    public void stopper()
    {
        SampleSaveCsvScript.stopper();
        Debug.Log("success");
    }
    private void OnApplicationQuit()
    {
        stopper();
    }

    void Update()
    {
        
        
        cou++;
        
        if (cou == 3&&num>-1)//�Acou�͋L�^���銴�o��\���Acou�����R�ł���΂R�t���[���ɂP��L�^
        {
            if (!calledone)
            {
                SampleSaveCsvScript.Swriter(num);
                calledone = true;
            }
            SampleSaveCsvScript.SaveDat(num,num,num,num,num,num,num);�@//�@�o�͂������ϐ�������A�ϐ��̌^�� SampleSaveCsvScript�ł��ύX���Ă�������
            cou = 0;
        }
    }
}
