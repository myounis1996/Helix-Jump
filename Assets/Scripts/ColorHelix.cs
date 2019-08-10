using UnityEngine;

public class ColorHelix : MonoBehaviour
{
    public Material[] materials;
    public float speed = -5.5f;

    int getRandomToRotate;
    float eulerAngleX;
    float eulerAngleY;
    float eulerAngleZ;
    Vector3 localRotationValues;
    Vector3 targetRotationValues;

    GameObject[] coloredHelixes = new GameObject[3];

    void Awake()
    {
        for (int i = 0; i < gameObject.transform.childCount - 1; i++)
        {
            gameObject.transform.GetChild(i).GetComponent<MeshRenderer>().material.color = Color.gray;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        Material matierial = materials[Random.Range(0, materials.Length)];
        for (int i = 0; i < 3; i++)
        {
            int random = Random.Range(0, gameObject.transform.childCount - 1);
            gameObject.transform.GetChild(random).GetComponent<MeshRenderer>().material = matierial;
            gameObject.transform.GetChild(random).tag = "lose";
            coloredHelixes[i] = gameObject.transform.GetChild(random).gameObject;
        }
        getRandomToRotate = Random.Range(0, coloredHelixes.Length);
        eulerAngleX = coloredHelixes[getRandomToRotate].transform.localEulerAngles.x;
        eulerAngleY = coloredHelixes[getRandomToRotate].transform.localEulerAngles.y;
        eulerAngleZ = coloredHelixes[getRandomToRotate].transform.localEulerAngles.z;
        localRotationValues = new Vector3(eulerAngleX, eulerAngleY, eulerAngleZ);
        targetRotationValues = new Vector3(eulerAngleX, eulerAngleY, eulerAngleZ + 60);
        coloredHelixes[getRandomToRotate].transform.localScale = new Vector3(coloredHelixes[getRandomToRotate].transform.localScale.x,
                                                                             coloredHelixes[getRandomToRotate].transform.localScale.y + 0.08f,
                                                                             coloredHelixes[getRandomToRotate].transform.localScale.z + 0.05f);
    }

    // Update is called once per frame
    void Update()
    {
        PingPongRotation.current.SetPartialRotate(coloredHelixes[getRandomToRotate], localRotationValues, targetRotationValues, speed);
    }
}

