using UnityEngine;

public class HomeScript : MonoBehaviour
{
    public Camera mainCamera;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        mainCamera.transform.Rotate( 0, 10 * Time.deltaTime, 0);
    }
}
