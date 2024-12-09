using UnityEngine;

public class TeleporterScript : MonoBehaviour
{
    public float groundDistance = 1.1f;
    public LayerMask groundMask;
    public GameObject player;
    public Vector3 targetPos;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Physics.CheckSphere(this.transform.position, groundDistance, groundMask))
        {
            player.GetComponent<CharacterController>().enabled = false;
            player.transform.position = targetPos;
            player.GetComponent<CharacterController>().enabled = true;
        }
    }
}
