using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GamePlayStats : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreText;

    private FlyerMovement flyerPlayer;
    private PlatformPlayerMovement platformPlayer;
    private MazePlayerMovement mazePlayer;
    private RunnerFixMovement runnerPlayer;
    private DoodleMovement doodlePlayer;

    [Header("Button")]
    [SerializeField] public GameObject Firebutton;

    private void Start()
    {
        StartCoroutine(GameCheck());
    }
    IEnumerator GameCheck()
    {
        yield return new WaitForSeconds(0.1f);

        if (FindObjectOfType<FlyerMovement>())
        {
            flyerPlayer = FindObjectOfType<FlyerMovement>();
        }
        if (FindObjectOfType<PlatformPlayerMovement>())
        {
            platformPlayer = FindObjectOfType<PlatformPlayerMovement>();
        }
        if (FindObjectOfType<MazePlayerMovement>())
        {
            mazePlayer = FindObjectOfType<MazePlayerMovement>();
        }
        if (FindObjectOfType<RunnerFixMovement>())
        {
            runnerPlayer = FindObjectOfType<RunnerFixMovement>();
        }
        if (FindObjectOfType<DoodleMovement>())
        {
            doodlePlayer = FindObjectOfType<DoodleMovement>();
        }
    }
    void Update()
    {
        if (flyerPlayer)
        {
            scoreText.text = flyerPlayer.scoreCoin.ToString();
        }
        if(platformPlayer)
        {
            scoreText.text = platformPlayer.GetComponent<PlatformPlayerMovement>().scoreCoin.ToString();
        }
        if(mazePlayer)
        {
            scoreText.text = mazePlayer.scoreCoin.ToString();
        }
        if (runnerPlayer)
        {
            scoreText.text = runnerPlayer.scoreCoin.ToString();
        }
        if (doodlePlayer)
        {
            scoreText.text = doodlePlayer.scoreCoin.ToString();
        }
    }
}
