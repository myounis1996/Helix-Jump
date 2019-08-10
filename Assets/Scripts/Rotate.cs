using UnityEngine;

public class Rotate : MonoBehaviour
{
    public float rotationSpeed = 100f;
    // Update is called once per frame
    void Update()
    {
        if (Player.isPaused == false)
        {
            if (Input.GetKey(KeyCode.A))
            {
                transform.Rotate(0f, Time.deltaTime * rotationSpeed, 0f);
            }
            if (Input.GetKey(KeyCode.D))
            {
                transform.Rotate(0f, -1 * Time.deltaTime * rotationSpeed, 0f);
            }
        }
    }
}
