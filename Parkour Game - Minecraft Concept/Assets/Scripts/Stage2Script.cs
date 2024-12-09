using UnityEngine;
using UnityEngine.SceneManagement;

public class Stage2Script : MonoBehaviour
{
    public Transform groundCheck; // Objek untuk memeriksa tanah
    public float groundDistance = 1.1f; // Jarak pemeriksaan tanah
    public LayerMask groundMask; // Layer yang dianggap tanah
    public bool isTeleport;
    public GameObject[] healthbar;
    public int playerHealth;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        healthbar[0].gameObject.SetActive(playerHealth > 2);
        healthbar[1].gameObject.SetActive(playerHealth > 1);
        healthbar[2].gameObject.SetActive(playerHealth > 0);

        isTeleport = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
        if (isTeleport)
        {
            SceneManager.LoadScene("Stage3");
        }

        if (Input.GetKey(KeyCode.Escape)) SceneManager.LoadScene(0);
    }
}
