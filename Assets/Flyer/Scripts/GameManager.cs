using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private List<GameObject> characters;
    [SerializeField] private int chooseCharacter;
    [SerializeField] private GameObject coinPrefab;
    [SerializeField] private Transform coinsParent;
    [SerializeField] private float waitTime;
    [SerializeField] private int numCoins;
    [SerializeField] private Vector3 spawnCoinPosition;

    public GameObject currentCharacter;

    void Start()
    {
        spawnCharacter();
        StartCoroutine(SpawnCoins());
    }

    IEnumerator SpawnCoins()
    {
        yield return new WaitForSeconds(waitTime);

        for (int i = 0; i < numCoins; i++)
        {
            float randCoinx = Random.Range(-3f, 3f);
            float randCoiny = Random.Range(10f, 15f);

            spawnCoinPosition.x = randCoinx;
            spawnCoinPosition.y += randCoiny;

            Instantiate(coinPrefab, spawnCoinPosition, Quaternion.identity, coinsParent);
        }
    }
    private void spawnCharacter()
    {
        currentCharacter=Instantiate(characters[chooseCharacter], characters[chooseCharacter].transform.position, Quaternion.identity);
    }
    public void RestartScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
