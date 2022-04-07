using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
public class LineCutter : MonoBehaviour
{
    [SerializeField] LayerMask raycastMask;
    [SerializeField] Transform p1;
    [SerializeField] Transform p2;
    [SerializeField] float lineHeigh = .5f;
    [SerializeField] AnimationCurve maxLineWidth;
    [SerializeField] float maxDistanceConnection = 5;


    LineRenderer line;
    RaycastHit hit;

    [SerializeField] float lineSize = 0;
    [SerializeField] float distanceDelta = 0;
    [SerializeField] float distance = 0;

    private void Start()
    {
        line = GetComponent<LineRenderer>();
        line.positionCount = 2;
    }

    private void Update() 
    {
        distance = Vector3.Distance(p1.position, p2.position);
        distanceDelta = distance / maxDistanceConnection;
        lineSize = maxLineWidth.Evaluate(Mathf.Clamp01(1 - distanceDelta));
        line.startWidth = lineSize;
        line.endWidth = lineSize;
        line.SetPosition(0, p1.position + Vector3.up * lineHeigh);
        line.SetPosition(1, p2.position + Vector3.up * lineHeigh);
    }

    private void FixedUpdate() 
    {
        if (Vector3.Distance(p1.position,p2.position) < maxDistanceConnection)
        {
            Physics.Linecast(p1.position + Vector3.up * lineHeigh, p2.position + Vector3.up * lineHeigh, out hit, raycastMask);
        }

        if(hit.transform != null) Destroy(hit.transform.gameObject);
    }
}
