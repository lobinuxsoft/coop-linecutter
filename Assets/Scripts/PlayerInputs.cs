using UnityEngine;
using UnityEngine.Events;

public class PlayerInputs : MonoBehaviour
{
    public UnityEvent<Vector3> onP1Intups;
    public UnityEvent<Vector3> onP2Intups;

    // Update is called once per frame
    void Update()
    {
        onP1Intups?.Invoke(new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical")));

        onP2Intups?.Invoke(new Vector3(Input.GetAxis("Horizontal2"), 0, Input.GetAxis("Vertical2")));
    }
}
