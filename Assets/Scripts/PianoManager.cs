using System.Collections.Generic;
using UnityEngine;

public class PianoManager : MonoBehaviour
{
    public List<KeyManager> keys = new();
    public bool allocated = false;

    // Set from the editor
    public List<AudioClip> BaseNores;
    private AudioSource audioSource;

    public float offset = 0.1f;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();

        int count = transform.GetChild(0).childCount;

        for (int i = 0; i < count; i++)
        {
            keys.Add(transform.GetChild(0).GetChild(i).GetComponentInChildren<KeyManager>());
        }
    }

    public void AllocateBaseNote(KeyManager mid)
    {
        int n = keys.IndexOf(mid);

        Debug.Log(n);

        audioSource.clip = BaseNores[n];
        mid.pitch = 1;
        
        for(int i = 0; i < n; i++)
        {
            keys[n - i - 1].pitch = mid.pitch - offset*(i + 1);
        }

        for(int i = n+1, j = 1; i < keys.Count; i++, j++)
        {
            keys[i].pitch = mid.pitch + offset*(j);
        }

        allocated = true;
    }

}
