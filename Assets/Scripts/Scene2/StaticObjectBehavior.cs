using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Scene2.StaticObject
{
    public class StaticObjectBehavior : MonoBehaviour
    {
        int _countPassingThrough = 0;

        private void OnTriggerExit(Collider other)
        {
            _countPassingThrough++;
            Debug.Log("Passing through: " + _countPassingThrough + " Times");
            RaycastHit raycastHit = new RaycastHit();
            Ray ray = new Ray(other.transform.position, Vector3.down);
            Physics.Raycast(ray, out raycastHit);

        }
    }
}
