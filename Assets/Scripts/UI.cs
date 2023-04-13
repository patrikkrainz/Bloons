using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
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
    public GameObject OM;
    public GameObject Back;

    private KeyCode Pause = KeyCode.P;

    private float cursorTimer;

    public Vector3 lastMousePos;

    public AudioMixer Volume;

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
            UnityEngine.EventSystems.EventSystem.current.SetSelectedGameObject(null);
            select = null;
        }

        if (SceneManager.GetActiveScene().name == "MainMenu" && !MM.activeSelf && !OM.activeSelf)
        {
            MM.SetActive(true);
        }

        if(SceneManager.GetActiveScene().name == "MainMenu" && select == null && Input.anyKeyDown)
        {
            if(Input.GetKeyDown(KeyCode.Mouse0) || Input.GetKeyDown(KeyCode.Escape))
            {

            }
            else
            {
                StartB.Select();
                select = StartB;
            }
        }
        else if(SceneManager.GetActiveScene().name == "Waterpobbelz" && PM.activeSelf && select == null && Input.anyKeyDown)
        {
            ContinueB.Select();
            select = ContinueB;
        }

        if (SceneManager.GetActiveScene().name == "Waterpobbelz" && !PM.activeSelf && Input.GetKeyDown(Pause))
        {
            pauseGame();
            PM.SetActive(true);
        }

        if(OM.activeSelf && select == null && Input.anyKeyDown)
        {
            MainV.Select();
            select = MainV;
        }

        lastMousePos = Input.mousePosition;
    }

    public void pressStart()
    {
        select = null;
        SceneManager.LoadScene("Waterpobbelz");
    }

    public void pressOptions()
    {
        if (SceneManager.GetActiveScene().name == "MainMenu")
        {
            MM.SetActive(false);
        }
        else
        {
            PM.SetActive(false);
        }
        
        OM.SetActive(true);
        Back.SetActive(true);
        //BackB.Select();
        //select = BackB;
    }

    public void pressQuit()
    {
        print("Quit");
        Application.Quit();
    }

    public void pressContinue()
    {
        select = null;
        pauseGame();
    }

    public void pressBackToMM()
    {
        select = null;
        SceneManager.LoadScene("MainMenu");
    }

    public void pressBack()
    {
        if(SceneManager.GetActiveScene().name == "MainMenu")
        {
            OM.SetActive(false);
            Back.SetActive(false);
            MM.SetActive(true);
            StartB.Select();
            select = StartB;
        }
        else
        {
            OM.SetActive(false);
            Back.SetActive(false);
            PM.SetActive(true);
            ContinueB.Select();
            select = ContinueB;
        }
    }

    private void pauseGame()
    {
        if(Time.timeScale == 1)
        {
            Time.timeScale = 0;
        }
        else
        {
            Time.timeScale = 1;
        }
    }

    public void HandleMainVSlider(float volume1)
    {
        Volume.SetFloat("MainV", volume1);
    }
    public void HandleMusicVSlider(float volume2)
    {
        Volume.SetFloat("MusicV", volume2);
    }
    public void HandleSFXVSlider(float volume3)
    {
        Volume.SetFloat("SFXV", volume3);
    }
}
