using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;   // Player
    public float smoothSpeed = 5f;

    void LateUpdate()
    {
        if (target == null) return;

        Vector3 camPos = transform.position;
        camPos.x = Mathf.Lerp(camPos.x, target.position.x, smoothSpeed * Time.deltaTime);
        camPos.y = Mathf.Lerp(camPos.y, target.position.y, smoothSpeed * Time.deltaTime);

        transform.position = camPos;
    }
}
