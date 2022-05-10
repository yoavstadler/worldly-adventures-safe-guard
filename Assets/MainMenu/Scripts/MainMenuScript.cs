using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenuScript : MonoBehaviour
{
    [SerializeField] private GameObject CurrentWorld;
    [SerializeField] private Canvas MainMenu;
    [SerializeField] private Canvas SubPlayMenu;
    [SerializeField] private List<GameObject> Worlds;
    [SerializeField] private int chooseWorld;
    [SerializeField] private Text CoinSum;
    public GameObject RightArrow;
    public GameObject LeftArrow;


    // Start is called before the first frame update
    void Start()
    {
        spawnWorld();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void spawnWorld()
    {
        CurrentWorld = Instantiate(Worlds[chooseWorld],new Vector3(0,1,-8.7f), Quaternion.identity);
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
    }


}
