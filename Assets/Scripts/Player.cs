using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public Rigidbody rb;
    public float speed = 5f;
    public float offset= 2.3f;
    public GameObject points;
    public Text pointsText;
    public GameObject pauseMenuUI , startMenuUI;
    public static bool isPaused = true;
    public float helixHealth = 30f;

    int pointsCounter = 0;

    void Start()
    {
        rb.isKinematic = true;
        Color randomColor = new Color(Random.value, Random.value, Random.value, 1f);
        GetComponent<MeshRenderer>().material.color = randomColor;
        gameObject.transform.GetChild(0).GetComponent<ParticleSystem>().startColor = randomColor;
    }
    // Update is called once per frame
    void Update()
    {
        if (transform.position.y < Camera.main.transform.position.y - offset)
        {
            Camera.main.transform.position = new Vector3(Camera.main.transform.position.x,transform.position.y + 4f, Camera.main.transform.position.z);
        }
 
    }

    private void OnCollisionEnter(Collision collision)
    {
        rb.velocity = Vector3.up * speed;
        if (collision.relativeVelocity.magnitude >= 14)
        {
            helixHealth = 0;
        }
        if (helixHealth<=0)
        {
            collision.gameObject.transform.parent.gameObject.SetActive(false);
            helixHealth = 30f;
            return;
        }
        if (collision.gameObject.tag == "lose")
        {
            rb.isKinematic = true;
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            isPaused = true;
            return;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Points")
        {   
            pointsCounter++;
            pointsText.text = pointsCounter.ToString();
        }
    }

    public void StartGame()
    {
        rb.isKinematic = false;
        startMenuUI.SetActive(false);
        isPaused = false;
    }

    public void Pause()
    {
        rb.isKinematic = true;
        pauseMenuUI.SetActive(true);
        isPaused = true;
    }

    public void Countinue()
    {
        rb.isKinematic = false;
        pauseMenuUI.SetActive(false);
        isPaused = false;
    }

    public void MainMenu()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        pauseMenuUI.SetActive(false);
        startMenuUI.SetActive(true);
        isPaused = true;
    }

    public void Quit()
    {
        Application.Quit();
    }
}