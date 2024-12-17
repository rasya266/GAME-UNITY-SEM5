using UnityEngine;

public class Collapse : MonoBehaviour
{

    public LayerMask PlayerMask;
    public bool isTouched;
    public Rigidbody RB;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        RB = this.GetComponent<Rigidbody>();
        RB.useGravity = false;
    }

    // Update is called once per frame
    void Update()
    {
        isTouched = Physics.CheckSphere(this.transform.position, 1.1f,  PlayerMask);
        if (isTouched)
        {
            RB.useGravity = true;
        }
    }
}
