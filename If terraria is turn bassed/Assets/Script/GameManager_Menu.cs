using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager_Menu : MonoBehaviour
{
    public MenuState menuState;
    public GameObject Play;
    public GameObject Setting;
    public GameObject Quit;
    public GameObject Title;
    public GameObject B1;
    public GameObject B2;
    public GameObject resolution;
    public GameObject KingSlime;
    public Animator BG;
    public Animator CF;
    public Animator KS;
    public Animator CM;
    public Animator MS;
    public Animator DN;
    public GameObject JE;
    public AudioSource JEA;
    public bool reset = false;
    public enum MenuState
    {
        Menu,
        Play,
        Setting,
        Quit

    }

  

    private void FixedUpdate()
    {
        Invoke("playBGM",9.34f);
    }

    void Update()
    {
        if (menuState == MenuState.Quit)
        {
            Application.Quit();
        }

        if (menuState == MenuState.Play)
        {

            Play.SetActive(false);
            Setting.SetActive(false);
            Quit.SetActive(false);
            Title.SetActive(false);
            B1.SetActive(true);
            CF.Play("CliffUp"); 
            Invoke("SlimeKingAnim",1f);
            //Invoke("MCAnim",1.5f);
            CM.Play("Main Camera Shake");
            DN.Play("Day Night Cycle_None");
          
        }

        if (menuState == MenuState.Setting)
        {
            KingSlime.SetActive(false);
            B2.SetActive(true);
            resolution.SetActive(true);
            Play.SetActive(false);
            Setting.SetActive(false);
            Quit.SetActive(false);
            Title.SetActive(false);
            MS.Play("Menu_Setting");
            B2.SetActive(true);
            resolution.SetActive(true);
        }
        
        if (menuState == MenuState.Menu)
        {
            KingSlime.SetActive(true);
            CM.Play("Menu_Camera");
            KS.Play("Slime_Menu_real");
            DN.Play("Day"); 
            JEA.volume = 1f;
        } 
    }

    public void SlimeKingAnim()
    {
        KS.Play("Slime_Menu");
    } 
    public void MCAnim()
    {
        CM.Play("Main Camera Shake");
        Debug.Log("camera_anim_trigger");
    }
    
    public void SetState(MenuState MS)
    {
        if (menuState == MS) return;
        menuState = MS;
        {
            if (menuState == MenuState.Menu)
            {
                
            } 
            if (menuState == MenuState.Play)
            {
               
                
            } 
            if (menuState == MenuState.Setting)
            {
                
            } 
            if (menuState == MenuState.Quit)
            {
                
            }

        }
    }

    public void playBGM()
    {
        DN.Play("Day Night Cycle 2 Cycle");
        JE.SetActive(true);
    }
}
