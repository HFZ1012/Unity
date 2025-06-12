using UnityEngine;
using System.Collections;

public class CharacterSpawner : MonoBehaviour
{

	public GameObject Spawn (GameObject CharacterSlected)
	{
		if (CharacterSlected != null && GameObject.FindObjectsOfType(typeof(PlayerManager)).Length<=0) {
			
			string resetEveryround = PlayerPrefs.GetString ("ResetEveryRound");// in case of Casual mode. there's reset everyround
			string PlayerTemp = PlayerPrefs.GetString ("PlayerTemp");// Player name. we have to loading the latest save by name
			GameObject player = null;
			bool characterSaveFound = false; 
			
			// Spawning like a boss
			if (Network.isServer || Network.isClient) {
				player = (GameObject)Network.Instantiate (CharacterSlected, this.transform.position, Quaternion.identity, 0);
			} else {
				player = (GameObject)GameObject.Instantiate (CharacterSlected, this.transform.position, Quaternion.identity);
			}

			// Setting all component after spawned
			if (player != null && (player.GetComponent<NetworkView>().isMine || (!Network.isClient && !Network.isServer))) {
				
				Debug.Log ("Spawn " + player.name);
				
				if (!player.GetComponent<PlayerManager> ()) {
					player.AddComponent<PlayerManager> ();
				}
				
				if (resetEveryround != "True" || PlayerTemp != "") {
					// Load latest data of character
					if (player.GetComponent<PlayerSave> ())
						characterSaveFound = player.GetComponent<PlayerSave> ().Load ();	
				}
					// Update character data to server after spawned
				if (player.GetComponent<CharacterStatus> ())
					player.GetComponent<CharacterStatus> ().UpdateCharacterStatus (RPCMode.AllBuffered);
				
					// if old data is exist do not using items set from Character Starter Item
				if ((resetEveryround != "True" && characterSaveFound) || (characterSaveFound && PlayerTemp != "")) {
					if (player.GetComponent<CharacterStarterItem> ())
						player.GetComponent<CharacterStarterItem> ().Active = false;
				}

			}

			return player;
		}
		return null;
	}

}
