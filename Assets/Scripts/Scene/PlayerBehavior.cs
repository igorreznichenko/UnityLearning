using UnityEngine;

namespace Scene1.Player
{
    public class PlayerBehavior : MonoBehaviour
    {
        [SerializeField] private float _speed;
        [SerializeField] private float _jump;
        private Rigidbody _rb;
        private bool _canJump = false;
        private void Start()
        {
            _rb = GetComponent<Rigidbody>();
            Cursor.lockState = CursorLockMode.Locked;

        }

        private void FixedUpdate()
        {
            Move();
        }


        private void Move()
        {
            if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S))
            {
                Debug.Log(Input.GetAxis("Vertical"));
                float moveAcceleration = Input.GetAxis("Vertical");
                Vector3 forward = new Vector3(Camera.main.transform.forward.x, 0, Camera.main.transform.forward.z);
                forward *= _speed * moveAcceleration * Time.fixedDeltaTime;
                _rb.MovePosition(transform.position + forward);


            }


            if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D))
            {
                float moveAcceleration = Input.GetAxis("Horizontal");
                Vector3 forward = Camera.main.transform.right * _speed * moveAcceleration * Time.fixedDeltaTime;
                _rb.MovePosition(transform.position + forward);

            }
            if (Input.GetKey(KeyCode.Space) && _canJump)
            {
                _rb.AddForce(Vector3.up * _jump);
            }
        }
        private void OnCollisionEnter(Collision collision)
        {
            _canJump = true;
        }
        private void OnCollisionExit(Collision collision)
        {
            _canJump = false;
        }
    }
}