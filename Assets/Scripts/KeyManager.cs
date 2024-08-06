using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyManager : MonoBehaviour
{
    Animation anim;
    PianoManager pianoManager;

    AudioSource audioSource;
    public float pitch;

    private void Start()
    {
        anim = transform.parent.GetComponent<Animation>();
        pianoManager = GameObject.FindObjectOfType<PianoManager>();

        audioSource = pianoManager.gameObject.GetComponent<AudioSource>();
    }

    private void OnMouseDown()
    {
        anim.Play();

        if (!pianoManager.allocated)
        {
            pianoManager.AllocateBaseNote(this);
        }

        audioSource.pitch = pitch;
        audioSource.Play();
    }



}
