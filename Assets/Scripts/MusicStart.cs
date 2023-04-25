using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicStart : MonoBehaviour
{
    private NoteManager n;
    private Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        n = GameObject.Find("NoteManager").GetComponent<NoteManager>();
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.tag == "Start")
        {
            n.musicSection  = true;
            Destroy(other);
            rb.velocity = Vector2.zero;
        }
    }
}
