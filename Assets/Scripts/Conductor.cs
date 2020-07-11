using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Conductor : MonoBehaviour
{
    // Start is called before the first frame update
    /**
     * Should handle: Points scored by the player
     * Whether or not the player correctly made a hit
     * Controls the animation the dance preforms
     * The following code comes from: https://gamasutra.com/blogs/GrahamTattersall/20190515/342454/Coding_to_the_Beat__Under_the_Hood_of_a_Rhythm_Game_in_Unity.php
    **/
    //Song beats per minute
    //This is determined by the song you're trying to sync up to
    public float songBpm;

    //The number of seconds for each song beat
    public float secPerBeat;

    //Current song position, in seconds
    public float songPosition;

    //Current song position, in beats
    public float songPositionInBeats;

    //How many seconds have passed since the song started
    public float dspSongTime;

    //an AudioSource attached to this GameObject that will play the music.
    public AudioSource musicSource;

    int rand;
    float timer = 0;
    void Start()
    {
       
        //Load the AudioSource attached to the Conductor GameObject
        musicSource = GetComponent<AudioSource>();

        //Calculate the number of seconds in each beat
        secPerBeat = 60f / songBpm;

        //Record the time when the music starts
        dspSongTime = (float)AudioSettings.dspTime;

        //Start the music
        musicSource.Play();

        //Original Code below
        transform.GetChild(0).gameObject.SetActive(false);
        transform.GetChild(1).gameObject.SetActive(false);
        transform.GetChild(2).gameObject.SetActive(false);
    }
    GameObject telegraphFoot(string type,float delay)
    {
        GameObject foot;
        if (type.Equals("left"))
        {
            foot = transform.GetChild(0).gameObject;
            foot.SetActive(true);
            foot.GetComponent<FootBehavior>().delay = delay;
            //Delay == scale add later
        }
        else if (type.Equals("up"))
        {
            foot = transform.GetChild(1).gameObject;
            foot.SetActive(true);
            foot.GetComponent<FootBehavior>().delay = delay;
            //Delay == scale add later
        }

        else if (type.Equals("right"))
        {
            foot = transform.GetChild(2).gameObject;
            foot.SetActive(true);
            foot.GetComponent<FootBehavior>().delay = delay;
            //Delay == scale add later
        }
        else
        {
            return null;
        }
        return foot;
    }
    // Update is called once per frame
    void Update()
    {
        //Here are more bits of unoringal code used to add metrics for the music
        //determine how many seconds since the song started
        songPosition = (float)(AudioSettings.dspTime - dspSongTime);

        //determine how many beats since the song started
        songPositionInBeats = songPosition / secPerBeat;

        //Original Code here
        timer += Time.deltaTime;
        if(timer > 3f)
        {
            timer = 0;
            rand = Random.Range(0, 3);
            while (transform.GetChild(rand).gameObject.activeSelf)
            {
                rand = Random.Range(0, 3);
            }
            string t = "";
            switch (rand)
            {
                case 0:
                    t = "left";
                    break;
                case 1:
                    t = "up";
                    break;
                case 2:
                    t = "right";
                    break;
            }
            telegraphFoot(t, 3);
        }
    }
}
