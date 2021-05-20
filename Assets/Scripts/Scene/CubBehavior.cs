using UnityEngine;
using UnityEngine.EventSystems;
public class CubBehavior : MonoBehaviour, IPointerClickHandler
{
    Renderer mesh;
    Rigidbody rb;
    [SerializeField] float _force;
    [SerializeField] float _interactionDistance;
    public void OnPointerClick(PointerEventData eventData)
    {
        if (Vector3.Distance(Camera.main.transform.position, eventData.pointerCurrentRaycast.worldPosition) <= _interactionDistance)
        {
            int r = Random.Range(1, 255);
            int g = Random.Range(1, 255);
            int b = Random.Range(1, 255);
            mesh.material.color = new Color(r, g, b);
            Vector3 clickPoint = eventData.pointerCurrentRaycast.worldPosition;
            Vector3 cameraPoint = Camera.main.transform.position;
            Vector3 direction = clickPoint - cameraPoint;
            Debug.DrawLine(cameraPoint, eventData.pointerCurrentRaycast.worldPosition, Color.blue,1);
            direction.Normalize();
            rb.AddForce(direction * _force);
        }
        
    }

    // Start is called before the first frame update
    void Start()
    {
        mesh = GetComponent<Renderer>();
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
    }

   
}
