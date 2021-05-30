using System.Collections;
using UnityEngine;
using Scene1.Cub;
namespace Scene1.Gun
{
    public class GunScript : MonoBehaviour
    {
        [SerializeField] private Transform _gun;
        [SerializeField] private float _timeDelay = 0.3f;
        [SerializeField] private float _force = 10f;
        [SerializeField] private float _shootingDuration = 0.01f;
        [SerializeField] private AudioSource _shot;
        private LineRenderer _lineRenderer;
        private float _dTime;
        private bool _isShoot = false;
        private Transform _camera;
        private Vector3 _deltaMove;
        private Vector3 _initialPosition;
        private void Start()
        {
            _dTime = Time.time + _timeDelay;
            _camera = Camera.main.transform;
            _lineRenderer = GetComponent<LineRenderer>();
            _lineRenderer.enabled = false;
            _initialPosition = _gun.transform.localPosition;
            _deltaMove = new Vector3(0, 0, -0.3f);
        }

        private void FixedUpdate()
        {
            if (_isShoot)
            {
                _gun.transform.localPosition = Vector3.Lerp(_gun.transform.localPosition, _initialPosition + _deltaMove, 0.8f);
                if (_gun.transform.localPosition.z <= (_initialPosition + _deltaMove).z)
                {
                    _isShoot = false;
                }

            }
            else
            if (_gun.transform.localPosition.z < _initialPosition.z)
            {
                _gun.transform.localPosition = Vector3.Lerp(_gun.transform.localPosition, _initialPosition, 0.5f);
            }
        }
        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Mouse0) && _dTime - Time.time <= 0f)
            {
                Shot();
                _dTime = Time.time + _timeDelay;
            }

        }
        private void Shot()
        {
            RaycastHit raycastHit;
            Ray ray = new Ray(_camera.position, _camera.transform.forward);
            if (Physics.Raycast(ray.origin, ray.direction, out raycastHit))
            {
                _isShoot = true;
                StartCoroutine("ShotEffect");
                Rigidbody rigidbody = raycastHit.rigidbody;
                if (rigidbody)
                {
                    rigidbody.AddForce((raycastHit.point - Camera.main.transform.position).normalized * _force);
                }
                CubBehavior cub = raycastHit.collider.GetComponent<CubBehavior>();
                if (cub)
                {
                    cub.Interact(raycastHit.point, _force);
                }
                _lineRenderer.SetPosition(0, transform.position);
                _lineRenderer.SetPosition(1, raycastHit.point);
            }
        }

        IEnumerator ShotEffect()
        {
            _shot.Play();
            _lineRenderer.enabled = true;
            yield return new WaitForSeconds(_shootingDuration);
            _lineRenderer.enabled = false;

        }
    }
}