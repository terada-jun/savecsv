using UnityEngine;
using System.IO;
using System.Text;
//���̃X�N���v�g�͂ǂ����̃I�u�W�F�N�g�ɓ\��t���Ă��������i��I�u�W�F�N�g�ŉ\�j
//Unity��info�X�N���v�g��Inspector�ł��̃X�N���v�g��\��t�����I�u�W�F�N�g��Savecsv�Ƃ��Ďw�肷�邱��
//�@���̃X�N���v�g�ł�csv�t�@�C���ɏ������ލۂ̗񐔂��w��ł���
//�A�P�s�ځi�v�f���j���L�q�ł���
//�Bunity����Inspector�Ńt�@�C������ύX�ł���
public class SampleSaveCsvScript : MonoBehaviour
{
    // Start is called before the first frame update
    private StreamWriter sw;
  

    public StreamWriter[] swr = new StreamWriter[100];
    
    int num = 0;
    string[] ss;
    public string named;
 
    public void Swriter(int i1)
    {
        swr[i1] = new StreamWriter(named+(string.Format(@"Data{0}.csv", i1)), true, Encoding.GetEncoding("Shift_JIS"));
        string[] ss = { "�v�f�P", "�v�f�Q", "�v�f�R", "�v�f�S", "�v�f�T", "�v�f�U" }; //�A1�s�ڂ̗v�f�����w��
        string st = string.Join(",", ss);
        Debug.Log(st);
        swr[i1].WriteLine(st);
    }

    public void SaveDat(int i1, int txt1, int txt2, int txt3, int txt4,int txt5, int txt6)�@//�@�v�f���i�񐔁j�E�ϐ��^���w��iinfo�X�N���v�g�ł��ύX���邱�Ɓj
    {
        float[] ss1 = { txt1, txt2, txt3, txt4, txt5, txt6 };
        string st1 = string.Join(",", ss1);
        swr[i1].WriteLine(st1);

    }
    public void stopper()
    {
       
        {
            swr[num].Close();
            num++;

        }
    }

    // Update is called once per frame
    void Update()
    {
       
      

    }
}

