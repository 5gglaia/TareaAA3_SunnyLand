using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioControler : MonoBehaviour
{
    bool isPlaying = false;
    Rigidbody2D rb;
    AudioSource[] allSources; 

    AudioSource Wood_impact;
    AudioSource Wood_rumble;

    // Start is called before the first frame update
    void Start()
    {
        allSources = GetComponents<AudioSource>();

        rb = GetComponent<Rigidbody2D>();

        Wood_impact = allSources[0];
        Wood_rumble = allSources[1];
    }
   
    void FixedUpdate()
    {
    
    float v = rb.velocity.magnitude;
    if (v > 1 && !isPlaying) {
        Wood_rumble.Play(); 
        isPlaying = true;
    } else if (v < 1 && isPlaying) {
        Wood_rumble.Stop(); 
        isPlaying = false;
    }

    }
    

    void OnCollisionEnter2D(Collision2D collision) {
        Debug.Log("a collision has been detected");
        Wood_impact.Play();
    }
}
