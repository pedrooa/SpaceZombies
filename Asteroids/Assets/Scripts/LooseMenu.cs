using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LooseMenu : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene("MainMenu", LoadSceneMode.Single);
    }
    // Start is called before the first frame update

}
