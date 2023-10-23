using UnityEngine;
using UnityEngine.Events;
using static GorillaPlayerLineButton;

public class homeButton : GorillaPressableButton
{
    

    public override void Start()
    {
        gameObject.layer = 18;

        
    }

    public void OnTriggerEnter(Collision collision)
    {
        if(collision.collider.name == "RightHandTriggerCollider")
        {
            GameObject camScreen = GameObject.Find("Player Objects/Player VR Controller/GorillaPlayer/TurnParent/LeftHand Controller/monkePhone/cam");
            GameObject homeScreen = GameObject.Find("Player Objects/Player VR Controller/GorillaPlayer/TurnParent/LeftHand Controller/monkePhone/homescreen");
            if (camScreen != null)
            {
                camScreen.SetActive(true);
                homeScreen.SetActive(false);
            }
            else
            {
                Debug.LogError("something went wrong idk man");
            }
        }
    }
}