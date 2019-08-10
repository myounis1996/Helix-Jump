using UnityEngine;

public class PingPongRotation : MonoBehaviour
{
    public static PingPongRotation current;
    public int dir = 1;
    public float smoother = 0;

    float speed = 0.5f;

    void Awake()
    {
        current = this;
    }

    // Update is called once per frame
    void Update()
    {
        SetPartialRotate(gameObject, Vector3.zero, Vector3.up * 45, speed);
    }

    public void SetPartialRotate(GameObject obj, Vector3 currentAng, Vector3 targetAng, float speed)
    {
        obj.transform.localRotation = Quaternion.Lerp(Quaternion.Euler(currentAng), Quaternion.Euler(targetAng), smoother);
        smoother += dir * Time.deltaTime * speed;
        if (smoother >= 1 && dir == 1)
        {
            dir = -1;
        }
        else if (dir == -1 && smoother <= 0)
        {
            dir = 1;
        }
    }
}