using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
public class LineCutter : MonoBehaviour
{
    [SerializeField] LayerMask raycastMask;
    [SerializeField] Transform p1;
    [SerializeField] Transform p2;
    [SerializeField] float lineHeigh = .5f;
    [SerializeField] float lineWidth = .5f;


    LineRenderer line;
    RaycastHit hit;

    private void Start()
    {
        line = GetComponent<LineRenderer>();
        line.positionCount = 2;
    }

    private void Update() 
    {
        line.startWidth = lineWidth;
        line.endWidth = lineWidth;
        line.SetPosition(0, p1.position + Vector3.up * lineHeigh);
        line.SetPosition(1, p2.position + Vector3.up * lineHeigh);
    }

    private void FixedUpdate() 
    {
        Physics.Linecast(p1.position + Vector3.up * lineHeigh, p2.position + Vector3.up * lineHeigh, out hit, raycastMask);

        if(hit.transform != null) Destroy(hit.transform.gameObject);
    }
}
