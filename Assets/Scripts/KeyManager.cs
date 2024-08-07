using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyManager : MonoBehaviour
{
    Animation anim;
    PianoManager pianoManager;

    AudioSource audioSource;
    public float pitch;

    public string left;
    public string right;

    private void Start()
    {
        gameObject.tag = "White";

        anim = transform.parent.GetComponent<Animation>();
        pianoManager = GameObject.FindObjectOfType<PianoManager>();

        audioSource = pianoManager.gameObject.GetComponent<AudioSource>();

        RaycastHit2D rhit = Physics2D.Raycast(transform.parent.position, Vector2.right, 1);
        
        if (rhit)
           right = rhit.collider.tag;

        RaycastHit2D lhit = Physics2D.Raycast(transform.parent.position, Vector2.left, 1f);

        if (lhit)
            left = lhit.collider.tag;
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
