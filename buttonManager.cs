using System.Collections;
using UnityEngine;
public class buttonManager : GorillaPressableButton
{

    public static string currentPage = "home";
    void Update()
    {
        GameObject modsScreen = GameObject.Find("Player Objects/Player VR Controller/GorillaPlayer/TurnParent/LeftHand Controller/monkePhone/mods");
        GameObject homeScreen = GameObject.Find("Player Objects/Player VR Controller/GorillaPlayer/TurnParent/LeftHand Controller/monkePhone/homescreen");
        GameObject camScreen = GameObject.Find("Player Objects/Player VR Controller/GorillaPlayer/TurnParent/LeftHand Controller/monkePhone/cam");
        GameObject settings = GameObject.Find("Player Objects/Player VR Controller/GorillaPlayer/TurnParent/LeftHand Controller/monkePhone/settings");
        if (ControllerInputPoller.instance.rightControllerPrimaryButton)
        {
            Debug.Log("going home " + ControllerInputPoller.instance.rightControllerPrimaryButton);
            currentPage = "home";
        }
        if (currentPage == "mods")
        {
            modsScreen.SetActive(true);
            homeScreen.SetActive(false);
            camScreen.SetActive(false);
            settings.SetActive(false);
        }
        else if (currentPage == "home")
        {
            modsScreen.SetActive(false);
            homeScreen.SetActive(true);
            camScreen.SetActive(false);
            settings.SetActive(false);
        }
        else if (currentPage == "cam")
        {
            modsScreen.SetActive(false);
            homeScreen.SetActive(false);
            camScreen.SetActive(true);
            settings.SetActive(false);
        }
        else if (currentPage == "settings")
        {
            modsScreen.SetActive(false);
            homeScreen.SetActive(false);
            camScreen.SetActive(false);
            settings.SetActive(false);
        }
        

    }





}