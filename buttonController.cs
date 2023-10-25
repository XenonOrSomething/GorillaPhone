using System.Collections;
using UnityEngine;
public class buttonController
{

    public string currentPage = "home";
    public override void Start()
    {
        gameObject.layer = 18;
        StartCoroutine(allowCollision());

    }
    bool canCollide = false;
    public void OnTriggerEnter(Collider collision)
    {
        Debug.Log("collided");
        Debug.Log(collision.name);
        if(this.name == "camButton") { 
            if (collision.name == "GorillaHandClimber" && canCollide)
            {
                Debug.Log("collided by hand");
                buttonManager.currentPage = "cam";
            }
        }else if(this.name == "modsButton")
        {
            if (collision.name == "GorillaHandClimber" && canCollide)
            {
                Debug.Log("collided by hand");
                buttonManager.currentPage = "mods";
            }

        }else if (this.name == "settingsButton")
        {
            if (collision.name == "GorillaHandClimber" && canCollide)
            {
                Debug.Log("collided by hand");
                buttonManager.currentPage = "settings";
            }

        }
    }

    void Update()
    {
        currentPage = buttonManager.currentPage;
    }
    IEnumerator allowCollision()
    {
        yield return new WaitForSeconds(1);
        canCollide = true;
    }
}
