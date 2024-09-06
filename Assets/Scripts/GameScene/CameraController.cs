using Hero;
using UnityEngine;

namespace GameScene
{
    public class CameraFollow : MonoBehaviour
    {
        [SerializeField] private Vector3 _offset;
        [SerializeField] private float _smoothSpeed = 0.125f;
        
        private Transform _target;

        private void Start()
        {
            _target = FindObjectOfType<HeroController>().transform;
        }

        private void LateUpdate()
        {
            if (_target == null) return;

            var desiredPosition = _target.position + _offset;
            var smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, _smoothSpeed);
            
            transform.position = smoothedPosition;

            // Опционально: если нужно, чтобы камера всегда смотрела на игрока
            // transform.LookAt(_target);
        }
    }
}