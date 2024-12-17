using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public GameObject player;
    public float speed;
    public int run;
    public CharacterController CC;
    public float gravity = -9.81f; // Kekuatan gravitasi
    public float jumpHeight = 1.5f;
    public GameObject CharacterModel;
    public Animator Animator;

    public Transform groundCheck; // Objek untuk memeriksa tanah
    public float groundDistance = 1.1f; // Jarak pemeriksaan tanah
    public LayerMask groundMask; // Layer yang dianggap tanah
    public bool isGrounded;
    private Vector3 velocity;

    public float mouseSensitivity = 100f; // Sensitivitas mouse
    public Transform playerBody; // Transform tubuh karakter

    private float xRotation = 0f; // Untuk membatasi rotasi pada sumbu X (vertikal)
    public Camera camera;

    void Start()
    {
        speed = 2;
        run = 1;
        Cursor.lockState = CursorLockMode.Locked;
        Animator = CharacterModel.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
        if (isGrounded && velocity.y < 0)
        {
            Animator.SetBool("isJumping", false);
            velocity.y = -2f; // Tidak nol agar tetap menempel di tanah
        }

        Vector3 moveDirectio = transform.forward * Input.GetAxis("Vertical");
        Vector3 moveDirectionX = transform.right ;

        if((Input.GetKey("w") || Input.GetKey("d") || Input.GetKey("s") || Input.GetKey("a")) && CC.enabled)
        {
            if (Input.GetKey("w")) CC.Move(moveDirectio * speed * Time.deltaTime * run);
            if (Input.GetKey("s")) CC.Move(-moveDirectio * -speed * Time.deltaTime * run);
            if (Input.GetKey("a")) CC.Move(moveDirectionX * -speed * Time.deltaTime * run);
            if (Input.GetKey("d")) CC.Move(moveDirectionX * speed * Time.deltaTime * run);
            if (Input.GetKey("space") && isGrounded)
            {
                velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
                Animator.SetBool("isJumping", true);
            }
            Animator.SetBool("isWalking", true);
        }
        else
        {
            Animator.SetBool("isWalking", false);
        }
       
        run = Input.GetKey("left shift") ? 2 : 1;
        if (Input.GetKey("left shift")) Animator.SetBool("isRunning", true);
        else Animator.SetBool("isRunning", false);

        //Bagian Mouse untuk rotasi karakter
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        // Mengatur rotasi vertikal (pitch) dan membatasi agar tidak berputar 360 derajat
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f); // Batas pandangan atas dan bawah

        // Terapkan rotasi vertikal pada kamera
        camera.transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);

        // Terapkan rotasi horizontal (yaw) pada tubuh karakter
        transform.Rotate(Vector3.up * mouseX);


        velocity.y += gravity * Time.deltaTime;
        if(CC.enabled)CC.Move(velocity * Time.deltaTime);
    }
}
