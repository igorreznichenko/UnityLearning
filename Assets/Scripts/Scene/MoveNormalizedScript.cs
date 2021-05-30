using UnityEngine;

namespace Scene1.Moving
{
    public class MoveNormalizedScript : MonoBehaviour
    {
        [SerializeField] private float _speed;
        Vector3 _normalized;
        private void Start()
        {
            _normalized = transform.position.normalized;
        }

        private void Update()
        {
            Move();
        }

        private void Move()
        {
            transform.Translate(_normalized * _speed * Time.deltaTime);
        }
    }
}