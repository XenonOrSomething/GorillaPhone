using System;
using System.Collections;
using System.IO;
using System.Reflection;
using BepInEx;
using UnityEngine;
using Utilla;

namespace monkePhone
{
	/// <summary>
	/// This is your mod's main class.
	/// </summary>

	/* This attribute tells Utilla to look for [ModdedGameJoin] and [ModdedGameLeave] */
	[ModdedGamemode]
	[BepInDependency("org.legoandmars.gorillatag.utilla", "1.5.0")]
	[BepInPlugin(PluginInfo.GUID, PluginInfo.Name, PluginInfo.Version)]
	public class Plugin : BaseUnityPlugin
	{
		bool inRoom;
		bool canHide = true;
        public AssetBundle LoadAssetBundle(string path)
        {
            Stream stream = Assembly.GetExecutingAssembly().GetManifestResourceStream(path);
            AssetBundle bundle = AssetBundle.LoadFromStream(stream);
            stream.Close();
            return bundle;
        }
        
        


        private void Start() => Events.GameInitialized += OnGameInitialized;

        
        void OnDisable()
		{
			/* Undo mod setup here */
			/* This provides support for toggling mods with ComputerInterface, please implement it :) */
			/* Code here runs whenever your mod is disabled (including if it disabled on startup)*/

			HarmonyPatches.RemoveHarmonyPatches();
		}
		
		void OnGameInitialized(object sender, EventArgs e)
		{
			//im sorry to whoever is reading this code lmfao
			
            var bundle = LoadAssetBundle("monkePhone.Resources.xenonphone");
            var phone = bundle.LoadAsset<GameObject>("phone");
            Texture texture = bundle.LoadAsset<Texture>("phoneTexture");
            GameObject tempPhone = Instantiate(phone);
			
			Transform leftHand = GorillaLocomotion.Player.Instance.leftControllerTransform;
            tempPhone.transform.SetParent(leftHand, false);
            tempPhone.transform.localPosition = new Vector3(0, 0, 0);
            tempPhone.transform.localScale = new Vector3(3, 3, 3);
			tempPhone.transform.localRotation = Quaternion.Euler(-89.9802f, 180, 0);
			tempPhone.transform.name = "monkePhone";
            GameObject camButton = GameObject.Find("Player Objects/Player VR Controller/GorillaPlayer/TurnParent/LeftHand Controller/monkePhone/homescreen/camButton");
            GameObject settingsButton = GameObject.Find("Player Objects/Player VR Controller/GorillaPlayer/TurnParent/LeftHand Controller/monkePhone/homescreen/settingsButton");
			
            //settingsButton.AddComponent<buttonController>();
            camButton.AddComponent<buttonController>();
            GameObject homeScreen = GameObject.Find("Player Objects/Player VR Controller/GorillaPlayer/TurnParent/LeftHand Controller/monkePhone/homescreen");
            homeScreen.SetActive(true);
            GameObject localButtonManager = Instantiate(new GameObject());
			localButtonManager.AddComponent<buttonManager>();
			
        }
		
		

		void Update()
		{
            /* Code here runs every frame when the mod is enabled */
            if (ControllerInputPoller.instance.rightControllerSecondaryButton)
            {
				if(canHide){
					canHide = false;
					Debug.Log("Right controller secondary button pressed, toggling phone");
					GameObject phone = GameObject.Find("Player Objects/Player VR Controller/GorillaPlayer/TurnParent/LeftHand Controller/monkePhone");
					phone.SetActive(!phone.activeInHierarchy);
					StartCoroutine(debounceTimer());
				}
                
            }
        }

		/* This attribute tells Utilla to call this method when a modded room is joined */
		[ModdedGamemodeJoin]
		public void OnJoin(string gamemode)
		{
			/* Activate your mod here */
			/* This code will run regardless of if the mod is enabled*/

			inRoom = true;
		}

		/* This attribute tells Utilla to call this method when a modded room is left */
		[ModdedGamemodeLeave]
		public void OnLeave(string gamemode)
		{
			/* Deactivate your mod here */
			/* This code will run regardless of if the mod is enabled*/

			inRoom = false;
		}

		IEnumerator debounceTimer(){
    		yield return new WaitUntil(() => !ControllerInputPoller.instance.rightControllerSecondaryButton);
			canHide = true;
		}

	}
}
