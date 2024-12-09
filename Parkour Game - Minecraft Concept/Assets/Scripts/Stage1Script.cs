using UnityEngine;
using UnityEngine.SceneManagement;

public class Stage1Script : MonoBehaviour
{
    public Transform groundCheck; // Objek untuk memeriksa tanah
    public float groundDistance = 1.1f; // Jarak pemeriksaan tanah
    public LayerMask groundMask; // Layer yang dianggap tanah
    public LayerMask waterMask; // Layer yang dianggap tanah
    public bool isTeleport;
    public GameObject player;
    public int playerHealth;
    public bool heathCooldown;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerHealth = 3;
        heathCooldown = false;
    }

    // Update is called once per frame
    private void resetCD()
    {
        heathCooldown = false;
    }

    void Update()
    {
        isTeleport = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
        if(Physics.CheckSphere(groundCheck.position, groundDistance, waterMask))
        {
            player.transform.position = new Vector3(348.62f, 5.78f, 71.05f);
            if (!heathCooldown)
            {
                heathCooldown = true;
                playerHealth -= 1;
                Invoke("resetCD", 1f);
            }
            
        }

        if (isTeleport)
        {
            SceneManager.LoadScene("Stage2");
        }

        if (Input.GetKey("escape")) SceneManager.LoadScene(0);
    }
}
