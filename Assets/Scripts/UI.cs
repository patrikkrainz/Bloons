using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UI : MonoBehaviour
{
    public Selectable select;

    public Button StartB;
    public Button ContinueB;
    public Button BackB;

    public Slider MainV;

    public GameObject MM;
    public GameObject PM;
    public GameObject VM;
    public GameObject Back;
    public GameObject VMButton;
    public GameObject VMSlider;

    private KeyCode Pause = KeyCode.Escape;

    private float cursorTimer;

    public Vector3 lastMousePos;

    public AudioMixer Volume;

    void Start()
    {
        HandleMainVSlider(GlobalData.getVolume());
    }

    void Update()
    {
        if (lastMousePos != Input.mousePosition)
        {
            cursorTimer = 0;
            Cursor.visible = true;
        }
        else
        {
            cursorTimer += Time.deltaTime;
            if (cursorTimer >= 2)
            {
                Cursor.visible = false;
            }
        }

        if (select != null && lastMousePos != Input.mousePosition)
        {
            EventSystem.current.SetSelectedGameObject(null);
            select = null;
        }

        if (SceneManager.GetActiveScene().name == "MainMenu" && !MM.activeSelf)
        {
            MM.SetActive(true);
            VM.SetActive(true);
        }

        if (SceneManager.GetActiveScene().name == "MainMenu" && select == null && Input.anyKeyDown)
        {
            if (Input.GetKeyDown(KeyCode.Mouse0) || Input.GetKeyDown(KeyCode.Escape))
            {

            }
            else
            {
                StartB.Select();
                select = StartB;
            }
        }
        else if (SceneManager.GetActiveScene().name == "Bloons" && PM.activeSelf && select == null && Input.anyKeyDown)
        {
            ContinueB.Select();
            select = ContinueB;
        }

        if (SceneManager.GetActiveScene().name == "Bloons" && !PM.activeSelf && Input.GetKeyDown(Pause))
        {
            PlayerController.canShoot = false;
            Time.timeScale = 0;
            PM.SetActive(true);
            VM.SetActive(true);
        }

        lastMousePos = Input.mousePosition;
    }

    public void pressStart()
    {
        select = null;
        SceneManager.LoadScene("Bloons");
        PlayerController.canShoot = true;
    }

    public void pressVolume()
    {
        VMSlider.SetActive(true);
        MainV.value = GlobalData.getVolume();
        VMButton.SetActive(false);
        MainV.Select();
        select = MainV;

        Back.SetActive(true);
    }

    public void pressQuit()
    {
        print("Quit");
        Application.Quit();
    }

    public void pressContinue()
    {
        Time.timeScale = 1;
        PlayerController.canShoot = true;
        select = null;
        PM.SetActive(false);
        VM.SetActive(false);
    }

    public void pressBackToMM()
    {
        select = null;
        Time.timeScale = 1;
        SceneManager.LoadScene("MainMenu");
    }

    public void pressBack()
    {
        VMSlider.SetActive(false);
        Back.SetActive(false);
        VMButton.SetActive(true);

        if(SceneManager.GetActiveScene().name == "MainMenu")
        {
            StartB.Select();
            select = StartB;
        }
        else if(SceneManager.GetActiveScene().name == "Bloons")
        {
            ContinueB.Select();
            select = ContinueB;
        }
        
    }

    public void HandleMainVSlider(float volume)
    {
        Volume.SetFloat("MainV", volume);

        GlobalData.setVolume(volume);
    }
}
