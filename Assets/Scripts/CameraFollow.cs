using System;
using UnityEngine;

[ExecuteInEditMode]
public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Transform target1;
    [SerializeField] private Transform target2;
    [SerializeField] private Vector3 minOffset;
    [SerializeField] private Vector3 maxOffset;
    [SerializeField] private Vector3 lookAtOffset;
    [SerializeField] private float maxDistance = 20;
    [SerializeField] private AnimationCurve cameraOffsetBehaviour;

    // Update is called once per frame
    void LateUpdate()
    {
        UpdatePosition();
    }

    private void UpdatePosition()
    {
        if(target1 && target2)
        {
            Vector3 middlePoint = Vector3.Lerp(target1.position, target2.position, .5f);
            
            float distance = Vector3.Distance(target1.position, target2.position);

            Vector3 resultOffset = Vector3.Lerp(minOffset, maxOffset, cameraOffsetBehaviour.Evaluate(distance / maxDistance));

            Vector3 newPos =  resultOffset + middlePoint;

            transform.LookAt(middlePoint + lookAtOffset);
            transform.position = newPos;
        }
    }
}
