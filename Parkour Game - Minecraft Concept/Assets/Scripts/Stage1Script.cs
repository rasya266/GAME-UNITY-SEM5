using UnityEngine;
using UnityEngine.SceneManagement;

public class Stage1Script : MonoBehaviour
{
    public Transform groundCheck; // Objek untuk memeriksa tanah
    public float groundDistance = 1.1f; // Jarak pemeriksaan tanah
    public LayerMask groundMask; // Layer yang dianggap tanah
    public bool isTeleport;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        isTeleport = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
        if (isTeleport)
        {
            SceneManager.LoadScene("Stage2");
        }

        if (Input.GetKey("escape")) SceneManager.LoadScene(0);
    }
}
