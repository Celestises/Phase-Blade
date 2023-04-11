using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private GameObject a;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
                if (Input.GetKeyDown(KeyCode.S))
        {
            Destroy(a);
            Debug.Log("hi");

        }
    }
    void OnTriggerStay2D(Collider2D c)
    {
        a = c.gameObject;
    }
    private void OnTriggerExit2D(Collider2D other) {
        a = null;
    }

}
