using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroyer : MonoBehaviour
{
    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D other) {
        Destroy(other.gameObject);
        GameObject.Find("NoteList").GetComponent<MetronomeV2>().words.text = "Miss :(";
        // Debug.Log("Miss :(");
    }
}
