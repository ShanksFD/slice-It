using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingsMenu : MonoBehaviour
{
    
    Sprite soundOn;
    [SerializeField] Sprite soundOff;
    [SerializeField] Transform guideHolder;

    bool isExpanded = false;
    bool isMuted = false;
    Button settingsButton;
    Animator settingsAnimator;

    Button[] menuItems;
    int itemsCount;

    Transform settingsUI;
    Transform settingsHolder;


    private enum MenuItems
    {
        Sound = 1,
        HowTo
    }

    
    private void Start()
    {
        // Caching comps
        settingsUI = transform.GetChild(0);
        settingsHolder = transform.GetChild(1);

        settingsButton = settingsUI.GetComponent<Button>();
        settingsButton.onClick.AddListener(ToggleMenu);

        settingsAnimator = settingsHolder.GetComponent<Animator>();
        soundOn = settingsHolder.GetChild((int)MenuItems.Sound).GetComponent<Image>().sprite;

        // Buttons count
        itemsCount = settingsHolder.childCount;
        
        // Attaching Comps
        menuItems = new Button[itemsCount];
        for (int i = 1; i < itemsCount; i++)
        {
            menuItems[i] = settingsHolder.transform.GetChild(i).GetComponent<Button>(); 
            int x = i; // avoid closure..
            menuItems[i].onClick.AddListener(() => OnItemClick(x));
        }
    }

    void ToggleMenu()
    {
        isExpanded = !isExpanded;
        if(isExpanded)
        {
            // menu opened
            settingsAnimator.SetBool("SettingsShowed", true);
        }
        else
        {
            // menu closed
            settingsAnimator.SetBool("SettingsShowed", false);
        }
    }
    void OnItemClick(int index)
    {
        switch (index)
        {
            case (int)MenuItems.Sound: // Sound
                ToggleSound();
                break;
            case (int)MenuItems.HowTo: // How-to
                Debug.Log("How-to");
                // TODO: Show How-to UI
                break;
        }
    }

    private void ToggleSound()
    {
        if (isMuted)
        {
            // Sound unmuted    
            settingsHolder.GetChild((int)MenuItems.Sound).GetComponent<Image>().sprite = soundOn;
        }
        else
        {
            // Sound muted
            settingsHolder.GetChild((int)MenuItems.Sound).GetComponent<Image>().sprite = soundOff;
        }
        isMuted = !isMuted;
    }
    private void ToggleGuide()
    {
        if (isMuted)
        {
            guideHolder.gameObject.SetActive(true);
        }
        else
        {
            guideHolder.gameObject.SetActive(false);
        }
        isMuted = !isMuted;
    }

    
}
