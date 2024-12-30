using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class HomeScript : MonoBehaviour
{
    public Camera mainCamera;
    public Transform cT;
    public Slider slider;
    public GameObject Settings;
    public TextMeshProUGUI MouseSens;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Time.timeScale = 1;
        cT = mainCamera.transform;
        slider.value = PlayerPrefs.GetFloat("MouseSens");
        MouseSens.text = slider.value.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        Cursor.lockState = CursorLockMode.Confined;
        cT.rotation = Quaternion.Euler(5, cT.rotation.eulerAngles.y +  10*Time.deltaTime, 0);
    }

    public void startGame()
    {
        SceneManager.LoadScene(4);
    }

    public void quitGame()
    {
        Application.Quit();
    }

    public void MouseSensControll(float vol)
    {
        Debug.Log("vol is: " + slider.value);
        PlayerPrefs.SetFloat("MouseSens", slider.value);
        MouseSens.text = slider.value.ToString();
        PlayerPrefs.Save();
    }

    public void ToggleSetting(bool state)
    {
        Settings.gameObject.SetActive(state);
    }
}
