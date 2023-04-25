using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[ExecuteInEditMode]
public class Note : MonoBehaviour
{
public Vector3 pos = Vector3.zero;
public float beatSnap = 0;
private NoteManager n;
public bool canHit;
public float a;

    // Start is called before the first frame update
    void Start()
    {
    
    }

    // Update is called once per frame
    void Update()
    {
        n = GameObject.Find("NoteManager").GetComponent<NoteManager>();
       transform.position = new Vector3((pos.x % beatSnap == 0 ? pos.x : Mathf.FloorToInt(pos.x/beatSnap)*beatSnap) * (60/n.bpm) * n.runSpeed ,pos.y,pos.z);

       a = (((60/n.bpm) * Mathf.FloorToInt(pos.x/beatSnap)*beatSnap));

       if (n.elapsedTime >= a - n.hitWindow && n.elapsedTime <= a + n.hitWindow)
       {
       }
       
       
       

    }
}
