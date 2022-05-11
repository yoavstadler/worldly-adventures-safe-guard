using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class SubMenuScript : MonoBehaviour
{

  
    [SerializeField] private GameObject PlayerButton1;
    [SerializeField] private GameObject PlayerButton2;
    [SerializeField] private GameObject PlayerButton3;
    [SerializeField] private GameObject PlayerButton4;
    [SerializeField] private GameObject MainMenu;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OpenTutorialJumper()
    {
        SceneManager.LoadScene("TutorialDoodleJump");
    }

    public void OpenTutorialRunner()
    {
        SceneManager.LoadScene("TutorialRunner");
    }
}
