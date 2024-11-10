using UnityEngine;

public class HomeScript : MonoBehaviour
{
    public Camera mainCamera;
    public Transform cT;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        cT = mainCamera.transform;
    }

    // Update is called once per frame
    void Update()
    {
        cT.rotation = Quaternion.Euler(5, cT.rotation.eulerAngles.y +  10*Time.deltaTime, 0);
    }
}
