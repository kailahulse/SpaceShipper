using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFootsteps : MonoBehaviour
{
    [SerializeField]
    private AudioClip[] mudClips;
    public AudioClip attack;
    public AudioClip hurt;

    private AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void Step()
    {
        AudioClip clip = GetRandomClip();
        audioSource.PlayOneShot(clip);
    }

    private void AttackSound()
    {
        audioSource.PlayOneShot(attack);
    }

    private void HurtSound()
    {
        audioSource.PlayOneShot(hurt);
    }

    private AudioClip GetRandomClip()
    {
        return mudClips[UnityEngine.Random.Range(0, mudClips.Length)];     
    }
}
