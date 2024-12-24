using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class Stage2Script : MonoBehaviour
{
    public Transform groundCheck; // Objek untuk memeriksa tanah
    public float groundDistance = 1.1f; // Jarak pemeriksaan tanah
    public LayerMask groundMask; // Layer yang dianggap tanah
    public bool isTeleport;
    public GameObject[] healthbar;
    public int playerHealth;
    public bool heathCooldown;
    public GameObject player;
    public LayerMask waterMask; // Layer yang dianggap tanah
    public Vector3 tpLocation;
    public GameObject MenuPanel;
    public PlayerScript PS;

    public bool End;
    public GameObject Panel;
    public GameObject PanelStat;
    public Image PanelBg;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Time.timeScale = 1;
        playerHealth = 3;
        heathCooldown = false;
        PanelBg = Panel.GetComponent<Image>();

    }
    private void end()
    {
        SceneManager.LoadScene(3);

    }

    private void resetCD()
    {
        heathCooldown = false;
    }

    // Update is called once per frame
    [System.Obsolete]
    void Update()
    {

        if (End)
        {
            player.GetComponent<CharacterController>().enabled = false;
            Panel.gameObject.SetActive(true);
            PanelStat.gameObject.SetActive(false);
            PanelBg.color = new Color(0, 0, 0, PanelBg.color.a + (1f * Time.deltaTime));
            print(PanelBg.color.a);
            if (PanelBg.color.a >= 1f) Invoke("end", 2f);
        }
        healthbar[0].gameObject.SetActive(playerHealth > 2);
        healthbar[1].gameObject.SetActive(playerHealth > 1);
        healthbar[2].gameObject.SetActive(playerHealth > 0);

        isTeleport = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
        if (Physics.CheckSphere(groundCheck.position, groundDistance, waterMask))
        {

            player.GetComponent<CharacterController>().enabled = false;
            player.transform.position = tpLocation;
            player.GetComponent<CharacterController>().enabled = true;

            if (!heathCooldown)
            {
                heathCooldown = true;
                playerHealth -= 1;
                if (playerHealth == 0) SceneManager.LoadScene("Stage1");
                Invoke("resetCD", 1f);
            }

        }

        if (isTeleport) End = true;

        if (Input.GetKeyDown(KeyCode.Escape)) ShowMenu(!MenuPanel.active);
    }

    private void ShowMenu(bool state)
    {
        MenuPanel.SetActive(state);
        PS.state = state;
        Time.timeScale = state ? 0 : 1;
    }

    public void backHome()
    {
        SceneManager.LoadScene(0);
    }
}
