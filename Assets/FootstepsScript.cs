using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FootstepsScript : MonoBehaviour
{
    [SerializeField]
    private AudioClip[] mudClips;
    private float distToGround;

    private AudioSource audioSource;

    private void Start()
    {
        distToGround = GetComponent<Collider>().bounds.extents.y;
        audioSource = GetComponent<AudioSource>();
    }

    private void Step()
    {
        if(Physics.Raycast(transform.position, -Vector3.up, distToGround + 0.1f))
        {
            AudioClip clip = GetRandomClip();
            audioSource.PlayOneShot(clip);
        }
    }

    private AudioClip GetRandomClip()
    {
        return mudClips[UnityEngine.Random.Range(0, mudClips.Length)];     
    }
}
