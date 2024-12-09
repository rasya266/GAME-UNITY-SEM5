using UnityEngine;

public class Obs1 : MonoBehaviour
{
    float moveCount = 0;
    bool hold = false;
    float inverse = 1;
    public GameObject player;
    public float groundDistance;
    public LayerMask groundMask;
    public bool isOnPlayer;
    public int dir;
    public float moveSpeed;
    public float time;
    public Vector3[] direction;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        direction = new Vector3[3] { Vector3.right, Vector3.up, Vector3.forward};
    }

    private void changeState()
    {
        inverse *= -1;
        hold = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!hold)
        {
            hold = true;
            Invoke("changeState", time);
        }
        this.transform.Translate(moveSpeed * inverse * Time.deltaTime * direction[dir]);
        if (isOnPlayer=Physics.CheckSphere(this.transform.position, groundDistance, groundMask)){
            player.GetComponent<CharacterController>().Move(moveSpeed * inverse * Time.deltaTime * direction[dir]);
        }
        
    }
}
