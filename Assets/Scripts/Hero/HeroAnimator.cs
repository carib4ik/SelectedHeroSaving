using System;
using UnityEngine;
using UnityEngine.AI;

namespace Hero
{
    public class HeroAnimator : MonoBehaviour
    {
        private Animator _animator;
        private NavMeshAgent _navMeshAgent;
        private static readonly int IsWalking = Animator.StringToHash("isWalking");

        private void Awake()
        {
            _animator = GetComponent<Animator>();
            _navMeshAgent = GetComponent<NavMeshAgent>();
        }
        
        private void Update()
        {
            var speed = _navMeshAgent.velocity.magnitude;
            var isWalking = speed > 0.1f;

            _animator.SetBool(IsWalking, isWalking);
        }
    }
}
