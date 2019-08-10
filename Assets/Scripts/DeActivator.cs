using UnityEngine;

public class DeActivator : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        if (transform.position.y > Camera.main.transform.position.y+10f)
        {
            gameObject.SetActive(false);
            GameObject obj = ObjectPooling.current.GetpooledObject();

            if (obj == null) return;

            obj.transform.position = gameObject.transform.position + new Vector3(0f, -32f, 0f);
            obj.SetActive(true);
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 2; j++)
                {
                    obj.transform.GetChild(i).GetChild(j).gameObject.SetActive(true);
                }
            }
        }
    }
}
