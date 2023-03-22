using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public AudioSource[] audioSources;
    int timer;
    // Start is called before the first frame update
    void Start()
    {
        timer = 2000;
    }

    // Update is called once per frame
    void Update()
    {

        if((timer >= 1)&&(timer<=2000)){timer--;}
        else if(timer < 1){
            print("go");
            audioSources[1].Play();
            timer = 3000;
        }
    }
}
