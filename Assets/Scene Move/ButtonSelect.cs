using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ButtonSelect : MonoBehaviour
{
    Button FirstSelectButton;
   

    // Start is called before the first frame update
    void Start()
    {
        FirstSelectButton = GameObject.Find("Canvas/ButtonRan/StartButton").GetComponent<Button>();

        FirstSelectButton.Select();
    }

    // Update is called once per frame
    public void OnClickStartButton()
    {
        SceneManager.LoadScene("GameScene");
    }
}
