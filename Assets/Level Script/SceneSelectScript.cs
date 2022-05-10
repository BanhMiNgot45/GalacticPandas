using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSelectScript : MonoBehaviour
{
    public void selectScene() {
	switch (this.gameObject.name) {
	case "Button1":
		SceneManager.LoadScene("Plains");
		break;
	case "Button2":
		SceneManager.LoadScene("Desert");
		break;
	case "Button3":
		SceneManager.LoadScene("Mountain");
		break;
	case "Button4":
		SceneManager.LoadScene("Snow");
		break;
	case "Button5":
		SceneManager.LoadScene("Volcano");
		break;
		}
	}
}
