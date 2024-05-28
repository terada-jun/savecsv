
using UnityEngine;
//このスクリプトは取りたい変数があるオブジェクトに貼るとよい
//①このスクリプトでは、記録したい変数を指定できる
//②また記録の間隔（フレーム）も指定できる
//Unity側のInspectorで計測開始と終了を行える。

[ExecuteInEditMode]
public class info : MonoBehaviour
{
    
    private float time;

    public GameObject SaveCsv; //UnityのInspectorで SampleSaveCsvScriptを貼り付けたオブジェクトを指定すること
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
        
        if (cou == 3&&num>-1)//②couは記録する感覚を表す、cou＝＝３であれば３フレームに１回記録
        {
            if (!calledone)
            {
                SampleSaveCsvScript.Swriter(num);
                calledone = true;
            }
            SampleSaveCsvScript.SaveDat(num,num,num,num,num,num,num);　//①出力したい変数を入れる、変数の型は SampleSaveCsvScriptでも変更しておくこと
            cou = 0;
        }
    }
}
