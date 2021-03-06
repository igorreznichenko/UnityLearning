using UnityEngine;
namespace SavingObject.Moving
{
    public class ObjectMoving : MonoBehaviour
    {
        [SerializeField] float _speed;
        Rigidbody _rb;
        void Start()
        {
            _rb = GetComponent<Rigidbody>();
        }

        void Update()
        {
            Move();
        }
        public void Move()
        {
            if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S))
            {
                float val = Input.GetAxis("Vertical");
                _rb.MovePosition(transform.position + transform.forward * Time.deltaTime * _speed * val);
            }
            if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D))
            {
                float val = Input.GetAxis("Horizontal");
                _rb.MovePosition(transform.position + transform.right * Time.deltaTime * _speed * val);
            }
        }

    }
}