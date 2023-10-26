using System.Collections;
using UnityEngine;
public class buttonManager
{

    public static string currentPage = "home";
    GameObject modsScreen;
    GameObject homeScreen;
    GameObject camScreen;
    GameObject settings;
    void Awake(){
         modsScreen = GameObject.Find("Player Objects/Player VR Controller/GorillaPlayer/TurnParent/LeftHand Controller/monkePhone/mods");
         homeScreen = GameObject.Find("Player Objects/Player VR Controller/GorillaPlayer/TurnParent/LeftHand Controller/monkePhone/homescreen");
         camScreen = GameObject.Find("Player Objects/Player VR Controller/GorillaPlayer/TurnParent/LeftHand Controller/monkePhone/cam");
         settings = GameObject.Find("Player Objects/Player VR Controller/GorillaPlayer/TurnParent/LeftHand Controller/monkePhone/settings");
    }
    void Update()
    {
        
        if (ControllerInputPoller.instance.rightControllerPrimaryButton)
        {
            Debug.Log("going home " + ControllerInputPoller.instance.rightControllerPrimaryButton);
            currentPage = "home";
        }
        switch (currentPage){
            case "mods":
                modsScreen.SetActive(true);
                homeScreen.SetActive(false);
                camScreen.SetActive(false);
                settings.SetActive(false);
                break;
            case "home":
                modsScreen.SetActive(false);
                homeScreen.SetActive(true);
                camScreen.SetActive(false);
                settings.SetActive(false);
                break;
            case "cam":
                modsScreen.SetActive(false);
                homeScreen.SetActive(false);
                camScreen.SetActive(true);
                settings.SetActive(false);
                break;
            case "settings":
                modsScreen.SetActive(false);
                homeScreen.SetActive(false);
                camScreen.SetActive(false);
                settings.SetActive(true);
                break;
        }
        

    }





}
