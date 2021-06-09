using UnityEngine;

namespace Scene1.Cub
{
    public class CubRotation : MonoBehaviour
    {
        [SerializeField] private float _rpm;
        private float _deltaTime;
        private void Start()
        {
            _deltaTime = Time.time;
        }
        private void Update()
        {
            RotateByQuat();
            //RotateByEuler();
        }
        private void RotateByQuat()
        {

            Quaternion rotate = Quaternion.Euler(new Vector3(0f, (_rpm / 60f) * 360 * Time.deltaTime, 0f));
            transform.rotation *= new Quaternion(rotate.x, rotate.y, rotate.z, rotate.w);
            Debug.Log(Time.time - _deltaTime);
        }
        private void RotateByEuler()
        {
            Quaternion rotate = Quaternion.Euler(0, (_rpm / 60f) * 360 * Time.deltaTime, 0);
            transform.rotation *= rotate;
            
        }
    }
}