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
    public GameObject[] healthbar;


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
        healthbar[0].gameObject.SetActive(playerHealth > 2);
        healthbar[1].gameObject.SetActive(playerHealth > 1);
        healthbar[2].gameObject.SetActive(playerHealth > 0);
        isTeleport = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
        if(Physics.CheckSphere(groundCheck.position, groundDistance, waterMask))
        {

            player.GetComponent<CharacterController>().enabled = false;
            player.transform.position = new Vector3(348.62f, 5.78f, 71.05f);
            player.GetComponent<CharacterController>().enabled = true;

            if (!heathCooldown)
            {
                heathCooldown = true;
                playerHealth -= 1;
                if (playerHealth == 0) SceneManager.LoadScene("Stage1");
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
