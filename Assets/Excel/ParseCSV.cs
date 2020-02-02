using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParseCSV : MonoBehaviour
{
    List<ExcelReader> allData = new List<ExcelReader>();
    // Start is called before the first frame update
    void Start()
    {
        TextAsset csvData = Resources.Load<TextAsset>("Dialogue");

        string[] data = csvData.text.Split(new char[] { '\n' });
        for( int i = 1; i < data.Length - 1; i++)
        {
            /*
             * 
             * public int id;
               public string speaker;
               public string text;
               public string empty;
               public string notes;
    */   
            string[] row = data[i].Split(new char[] { ',' });
            ExcelReader er = new ExcelReader();
            int.TryParse(row[0], out er.id);
            er.speaker = row[1];
            er.text = row[2];
            er.notes = row[4];

            allData.Add(er);
        }

        foreach ( ExcelReader er in allData)
        {
            Debug.Log(er.speaker);
        }
    }

    

    void Update()
    {
        
    }
}
