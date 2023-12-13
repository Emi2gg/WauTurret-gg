using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerChange : MonoBehaviour
{
    public GameObject Tower;
    public GameObject Tower2;
    public GameObject Tower3;
    public ParticleSystem TowerParticle;
    public AudioClip TowerSound;
    public void HpChange(float hp)
    {
        if(TowerSound == null)
        {
            Debug.LogWarning("TowerSound is null");
        }
        else
        {
            if(GetComponent<AudioSource>() == null)
            {
                Debug.LogWarning("AudioSource is null");
            }
            else
            {
                GetComponent<AudioSource>().PlayOneShot(TowerSound);
            } 
        }
        
        if(TowerParticle == null)
        {
            Debug.LogWarning("TowerParticle is null");
        }
        else
        {
            TowerParticle.Play();
        }
        if(hp >.8)
        {
            Tower.SetActive(true);
            Tower2.SetActive(false);
            Tower3.SetActive(false);
        }
        else if(hp > .3 && hp <= .8)
        {
            Tower.SetActive(false);
            Tower2.SetActive(true);
            Tower3.SetActive(false);
        }
        else if(hp >= 0 && hp < .3)
        {
            Tower.SetActive(false);
            Tower2.SetActive(false);
            Tower3.SetActive(true);
        }
    }
}
