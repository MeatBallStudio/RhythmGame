using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CatchZone : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip clip;
    public bool btnClick;
    
    public float SendNumbers() {
        return beatCount;
    }

    public void click() {
        btnClick = !btnClick;
        Debug.Log("fdsfsd");
    }

    void BeatMaker(Collider2D other) {
        if(btnClick) {
            audioSource.PlayOneShot(clip, 0.5f);
            if(other.gameObject.tag == "BeatMark") {
                beatCount++;
                Destroy(other.gameObject);
                GameObject.Find("NoteList").GetComponent<MetronomeV2>().words.text = "Well Done!";
                // Debug.Log("Well Done!!!" + SendNumbers() + "/" + GameObject.Find("NoteList").GetComponent<MetronomeV2>().allBeats);
            }
        }
    }
    float beatCount = 0f;
    public KeyCode keyToPress;
    void OnTriggerStay2D(Collider2D other) {
        BeatMaker(other);
    }
}
