using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MazeGameManager : MonoBehaviour
{
    [SerializeField] private List<GameObject> characters;
    [SerializeField] private int chooseCharacter;

    public GameObject currentCharacter;

    void Start()
    {
        spawnCharacter();
    }
    private void spawnCharacter()
    {
        currentCharacter = Instantiate(characters[chooseCharacter], characters[chooseCharacter].transform.position, Quaternion.identity);
    }

    public void RestartScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
