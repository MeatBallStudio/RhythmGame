using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class MetronomeV2 : MonoBehaviour
{
    public float bpm = 120f;
    float beatTempo;
    public float allCatchedBeats = 0f;
    public bool hasStarted = false;
    public Text words;
    // public BeatCatcher bc;
    public int allBeats;
    // Start is called before the first frame update
    void Start()
    {
        allBeats = GameObject.Find("NoteList").transform.childCount;
        // bc = GameObject.Find("CatchZone").GetComponent<BeatCatcher>();
        beatTempo = bpm / 60f;
    }

    // Update is called once per frame
    void Update()
    {
        allCatchedBeats = GameObject.Find("CatchZone1").GetComponent<CatchZone1>().SendNumbers() +  
                            GameObject.Find("CatchZone2").GetComponent<CatchZone2>().SendNumbers()+
                            GameObject.Find("CatchZone3").GetComponent<CatchZone3>().SendNumbers()+
                            GameObject.Find("CatchZone4").GetComponent<CatchZone4>().SendNumbers();
        if(GameObject.Find("NoteList").transform.childCount == 0) {
           words.text = allCatchedBeats.ToString() + "/" + allBeats.ToString(); 
           Destroy(GameObject.Find("NoteList"));
        //    bc.SendNumbers()  + "/" +
        }
       if(!hasStarted) {
        if(Input.anyKeyDown) {
            hasStarted = true;
            words.text = "";
        }
       } else {
            transform.position -= new Vector3(0f, beatTempo * Time.deltaTime, 0f);
       }
    }
}
