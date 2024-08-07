using System.Collections.Generic;
using UnityEngine;

public class PianoManager : MonoBehaviour
{
    public List<KeyManager> keys = new();
    public bool allocated = false;

    // Set from the editor
    public List<AudioClip> BaseNores;
    private AudioSource audioSource;

    public float upOffset = 0.1f;
    public float downOffset = 0.1f;
    public float midOffset = 0.05946f;

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

        audioSource.clip = BaseNores[n % BaseNores.Count];
        mid.pitch = 1;

        for (int i = 0; i < n; i++)
        {
            // Going down in the piano
            if (keys[n - i].left.Equals("White"))
                keys[n - i - 1].pitch = keys[n - i].pitch / midOffset;
            else
                keys[n - i - 1].pitch = keys[n - i].pitch / downOffset;
        }

        for (int i = n + 1, j = 1; i < keys.Count; i++, j++)
        {
            // Going up in the piano
            if (keys[i - 1].right.Equals("White"))
                keys[i].pitch = keys[i - 1].pitch * midOffset;
            else
                keys[i].pitch = keys[i - 1].pitch * upOffset;
        }

        allocated = true;
    }

}
