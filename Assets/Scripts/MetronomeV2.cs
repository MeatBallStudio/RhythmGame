using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MetronomeV2 : MonoBehaviour
{
    public float bpm = 120f;
    float beatTempo;
    public GameObject metronome;
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
    IEnumerator waiter(int secs) {
        yield return new WaitForSecondsRealtime(secs);
        SceneManager.LoadScene("LessonsMenu", LoadSceneMode.Single);
    }
    void Update(){
        allCatchedBeats = GameObject.Find("CatchZone1").GetComponent<CatchZone>().SendNumbers() +  
                            GameObject.Find("CatchZone2").GetComponent<CatchZone>().SendNumbers()+
                            GameObject.Find("CatchZone3").GetComponent<CatchZone>().SendNumbers()+
                            GameObject.Find("CatchZone4").GetComponent<CatchZone>().SendNumbers();
        if(GameObject.Find("NoteList").transform.childCount == 0) {
           words.text = allCatchedBeats.ToString() + "/" + allBeats.ToString(); 
           StartCoroutine(waiter(5));
        //    SceneManager.LoadScene("LessonsMenu", LoadSceneMode.Single);

           }
        if(!hasStarted) {
            if(Input.anyKeyDown) {
                hasStarted = true;
                words.text = "";
                Instantiate(metronome, new Vector3(0, -6, 0), Quaternion.identity);
            }
        } else {
            transform.position -= new Vector3(0f, beatTempo * Time.deltaTime, 0f);
        }
    }
}
