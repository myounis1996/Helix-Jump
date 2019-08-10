using UnityEngine;

public class ColorCylinder : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Color randomColor = new Color(Random.value, Random.value, Random.value, 0.5f);
        for (int i = 0; i < gameObject.transform.childCount; i++)
        {
            gameObject.transform.GetChild(i).GetComponent<MeshRenderer>().material.color = randomColor;
        }
    }
}
