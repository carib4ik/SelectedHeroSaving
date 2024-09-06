using UnityEngine;
using UnityEngine.AI;

namespace Hero
{
    public class HeroMovementController : MonoBehaviour
    {
        private NavMeshAgent _navMeshAgent;

        private void Awake()
        {
            _navMeshAgent = GetComponent<NavMeshAgent>();
        }

        private void Update()
        {
            if (!Input.GetMouseButtonDown(0))
            {
                return;
            }

            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out var hit))
            {
                _navMeshAgent.SetDestination(hit.point);
            }
        }
    }
}
