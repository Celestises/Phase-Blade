using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteManager : MonoBehaviour
{
[SerializeField] public float bpm;
// Time is in terms of beats.
[SerializeField] public float[] time;
[SerializeField] public float[] length;
[SerializeField] public float elapsedTime;
[SerializeField] private AudioSource click;
[SerializeField] public float beatLength;
[SerializeField] private float sinceLast;
[SerializeField] public float pauseTime;
[SerializeField] public bool initiated;
[SerializeField] public float runSpeed;
[SerializeField] private GameObject note;
[SerializeField] private GameObject player;

    // Start is called before the first frame update
    private void noteSpawn()
    {
        foreach (float t in time)
        {
            GameObject n = Instantiate(note, new Vector2(t * beatLength * runSpeed,0), Quaternion.identity);
        }
    }
    void Start()
    {

        beatLength = 60/bpm;
    }

    // Update is called once per frame
    void Update()
    {
        if (!initiated)
        {
            elapsedTime += Time.deltaTime;
            if (elapsedTime >=pauseTime)
            {
                initiated = true;
                elapsedTime = 0;
            }

            
        }
        if (initiated){
        elapsedTime += Time.deltaTime;
        sinceLast += Time.deltaTime;
        Debug.Log(elapsedTime);
        player.transform.position += new Vector2(0,runSpeed*Time.deltaTime);

        if (beatLength <= sinceLast)
        {
            click.Play();
            sinceLast = 0f;
        }
        }
    }
}
