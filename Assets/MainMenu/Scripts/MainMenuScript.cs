using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class MainMenuScript : MonoBehaviour
{
    [SerializeField] private GameObject CurrentWorld;
    [SerializeField] private Canvas MainMenu;
    [SerializeField] private GameObject SubPlayMenu0;
    [SerializeField] private GameObject SubPlayMenu1;
    [SerializeField] private GameObject SubPlayMenu2;
    [SerializeField] private GameObject SubPlayMenu3;
    [SerializeField] private List<GameObject> Worlds;
    [SerializeField] private int chooseWorld;
    [SerializeField] private TMP_Text CoinSum;
    [SerializeField] private GameObject RightArrow;
    [SerializeField] private GameObject LeftArrow;
    [SerializeField] private List<GameObject> TitlesList;
    [SerializeField] private int chooseTitle;
    [SerializeField] private GameObject Titles;
    private bool isDone;

    // Start is called before the first frame update
    void Start()
    {
        spawnWorld();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        if (isDone==true)
        {
            spawnWorld();
            isDone = false;
        }
        CoinSum.text = "CoinNum";
        
    }
    private void spawnWorld()
    {
        CurrentWorld = Instantiate(Worlds[chooseWorld],new Vector3(0,1,-8.7f), Quaternion.identity);
        
        Titles = Instantiate(TitlesList[chooseTitle],new Vector3(540,1380,0), Quaternion.identity,
            GameObject.FindGameObjectWithTag("MainMenu").transform);
    }

    void DestroyWorld()
    {
        Destroy(Titles);
        Destroy(CurrentWorld);
        isDone = true;
    }

    public void WorldUP()
    {
        chooseWorld++;
        if (chooseWorld<=1)
        {
            LeftArrow.SetActive(true);
            
        }
        if (chooseWorld == 3)
        {
            RightArrow.SetActive(false);
        }
        chooseTitle ++;
        if (chooseTitle <= 1)
        {
            LeftArrow.SetActive(true);

        }
        if (chooseTitle == 3)
        {
            RightArrow.SetActive(false);
        }
        DestroyWorld();

    }
    public void WorldDown()
    {
        chooseWorld= chooseWorld-1;
        if (chooseWorld == 0)
        {
            LeftArrow.SetActive(false);
        }
        if (chooseWorld <= 2)
        {
            RightArrow.SetActive(true);

        }
        chooseTitle = chooseTitle - 1;
        if (chooseTitle == 0)
        {
            LeftArrow.SetActive(false);
        }
        if (chooseTitle <= 2)
        {
            RightArrow.SetActive(true);

        }
        DestroyWorld();
    }
    public void OpenSubMenu()
    {
        if (chooseWorld == 0)
        {
            SubPlayMenu0.SetActive(true);
        }
        if (chooseWorld == 1)
        {
            SubPlayMenu1.SetActive(true);
        }
        if (chooseWorld == 2)
        {
            SubPlayMenu2.SetActive(true);
        }
        if (chooseWorld == 3)
        {
            SubPlayMenu3.SetActive(true);
        }

    }

}
