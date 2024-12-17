using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Stage3Script : MonoBehaviour
{
    public Transform groundCheck; // Objek untuk memeriksa tanah
    public float groundDistance = 1.1f; // Jarak pemeriksaan tanah
    public LayerMask groundMask; // Layer yang dianggap tanah
    public LayerMask waterMask; // Layer yang dianggap tanah
    public bool isTeleport;
    public bool End;
    public GameObject player;
    public int playerHealth;
    public bool heathCooldown;
    public GameObject[] healthbar;
    public GameObject Panel;
    public GameObject PanelStat;
    public Image PanelBg;

    public GameObject obs1; 

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerHealth = 3;
        heathCooldown = false;
        PanelBg = Panel.GetComponent<Image>();
    }

    // Update is called once per frame
    private void resetCD()
    {
        heathCooldown = false;
    }

    private void end()
    {
        SceneManager.LoadScene(0);

    }

    void Update()
    {
        if (End)
        {
            player.GetComponent<CharacterController>().enabled = false;
            Panel.gameObject.SetActive(true);
            PanelStat.gameObject.SetActive(false);
            PanelBg.color = new Color(0,0,0,PanelBg.color.a+(1f*Time.deltaTime));
            print(PanelBg.color.a);
            if (PanelBg.color.a >=1f) Invoke("end", 2f);
        }

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
                if (playerHealth == 0)
                {
                    SceneManager.LoadScene("Stage1");
                }

                Invoke("resetCD", 1f);
            }
            
        }

        if (isTeleport)
        {
            End = true;
        }

        if (Input.GetKey("escape")) SceneManager.LoadScene(0);
    }
}
