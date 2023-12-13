using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationEnemy : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    [SerializeField] private AudioSource _audioSource;
    public void OnHealthChange(float hp)
    {
        if(_animator == null)
        {
            return;
        }
        _animator.SetTrigger("Damage");
    }

    public void OnDeath()
    {
        if (_audioSource != null)
        {
            _audioSource.Play();
        }
        
        if(_animator == null)
        {
            return;
        }
        _animator.SetBool("Death",true);
    }
}
