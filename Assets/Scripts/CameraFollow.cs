using UnityEngine;

[ExecuteInEditMode]
public class CameraFollow : MonoBehaviour
{
    [SerializeField] Transform target;
    [SerializeField] Vector3 offset;

    // Update is called once per frame
    void LateUpdate()
    {
        UpdatePosition();
    }

    private void UpdatePosition()
    {
        if(target)
        {
            transform.LookAt(target);
            transform.position = target.position + offset;
        }
    }
}
