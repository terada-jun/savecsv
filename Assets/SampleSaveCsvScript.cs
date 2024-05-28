using UnityEngine;
using System.IO;
using System.Text;
//このスクリプトはどこかのオブジェクトに貼り付けてください（空オブジェクトで可能）
//UnityのinfoスクリプトのInspectorでこのスクリプトを貼り付けたオブジェクトをSavecsvとして指定すること
//①このスクリプトではcsvファイルに書き込む際の列数を指定できる
//②１行目（要素名）も記述できる
//③unity側のInspectorでファイル名を変更できる
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
        string[] ss = { "要素１", "要素２", "要素３", "要素４", "要素５", "要素６" }; //②1行目の要素名を指定
        string st = string.Join(",", ss);
        Debug.Log(st);
        swr[i1].WriteLine(st);
    }

    public void SaveDat(int i1, int txt1, int txt2, int txt3, int txt4,int txt5, int txt6)　//①要素数（列数）・変数型を指定（infoスクリプトでも変更すること）
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

