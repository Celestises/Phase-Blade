using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteManager : MonoBehaviour
{
[SerializeField] public float bpm;
// Time is in terms of beats.
[SerializeField] public float[] measure;
[SerializeField] public float[] time;
[SerializeField] public float[] length;
[SerializeField] public float elapsedTime;
[SerializeField] private AudioSource click;
[SerializeField] private AudioSource song;
[SerializeField] public float beatLength;
[SerializeField] private float sinceLast;
[SerializeField] public float pauseTime;
[SerializeField] public bool initiated;
[SerializeField] public float runSpeed;
[SerializeField] private GameObject note;
[SerializeField] private GameObject player;
[SerializeField] private float od;
    // Start is called before the first frame update
private IEnumerator color()
{
    player.GetComponent<SpriteRenderer>().color = Color.blue;
    yield return new WaitForSecondsRealtime(0.1f);
    player.GetComponent<SpriteRenderer>().color = Color.white;
}
    private void noteSpawn()
    {
        int i = 0;
        foreach (float t in time)
        {
            GameObject n = Instantiate(note);
            n.transform.position = new Vector3(((((measure[i] == 0 ? measure[i]: measure[i]-1) *4) + (t-1)) * beatLength * runSpeed),0,0);
            n.transform.localScale = new Vector3(1/od,2,1);
            i += 1;

        }
    }
    void Start()
    {

        beatLength = 60/bpm;
        //noteSpawn();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (!initiated)
        {
            elapsedTime += Time.fixedDeltaTime;
            if (elapsedTime >=pauseTime)
            {
                initiated = true;
                elapsedTime = 0;
                sinceLast = beatLength;
                song.Play();

            }

            
        }
        if (initiated){
        player.transform.position += new Vector3(runSpeed*Time.fixedDeltaTime,0,0);
        elapsedTime += Time.fixedDeltaTime;
        sinceLast += Time.fixedDeltaTime;
        

        if (beatLength <= sinceLast)
        {
            click.Play();
            sinceLast = 0f;
            StartCoroutine(color());
            
        }
        }
    }
}
