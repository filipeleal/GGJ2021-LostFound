using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;
using UnityEngine.SceneManagement;
using UnityEngine.Tilemaps;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Tilemap tilemap;

    [Range(1, 100)]
    public int NumberOfSheeps;

    public GameObject SpawnCenter;

    public SheepBehaviour SheepPrefab;

    public float Radius = 5;

    public int DayDuration = 60;

    public Color[] DaylightColors;

    public Light2D CurrentColor;

    public Transform[] Hideouts;

    private float daytime = 0f;

    private int dayNumber = 1;

    private float changeColorEvery;
    private int currentColor = 0;

    private bool isGameOver= false;

    [SerializeField]
    public Image ClockPointer;

    private List<SheepBehaviour> Sheeps;


    private static GameManager _instance;

    public static GameManager Instance { get { return _instance; } }


    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _instance = this;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        Sheeps = new List<SheepBehaviour>();

        if (dayNumber == 1)
            SpawnSheepsAtHideouts();
        else
            SpawnSheeps();
        changeColorEvery = DayDuration / (DaylightColors.Length - 1);

       
    }

    // Update is called once per frame
    void Update()
    {
        if (isGameOver)
            return;

        daytime += Time.deltaTime;
        if (daytime > DayDuration)
        {
            EndDay();
        }
        else
        {
            UpdateSky();
            UpdateClock();
        }
    }

    void SpawnSheeps()
    {
        for (int i = 0; i < NumberOfSheeps; i++)
        {
            Vector3 pos = Random.insideUnitCircle * Radius;


            var obj = Instantiate(SheepPrefab, SpawnCenter.transform.position + pos, Quaternion.identity, SpawnCenter.transform);
            // Debug.Log(obj);
            obj.transform.parent = SpawnCenter.transform;
        }
    }

    void SpawnSheepsAtHideouts()
    {
        for (int i = 0; i < Hideouts.Length; i++)
        {
            Vector3 pos = Hideouts[i].position;


            var sheep = Instantiate(SheepPrefab, pos, Quaternion.identity, SpawnCenter.transform);
            sheep.IsHidding = true;

            Sheeps.Add(sheep);
        }
    }

    void UpdateClock()
    {
        ClockPointer.transform.rotation = Quaternion.Euler(0,0, -(daytime / DayDuration) * 360f);
    }

    void UpdateSky()
    {

        //CurrentColor.color = DaylightColors[currentColor];
        if (daytime > (currentColor + 1) * changeColorEvery)
        {

            if (++currentColor == DaylightColors.Length)
                currentColor = 0;

        }

        var nextColor = currentColor + 1;
        if (nextColor >= DaylightColors.Length)
            nextColor = DaylightColors.Length - 1;

        CurrentColor.color = Color.Lerp(DaylightColors[currentColor], DaylightColors[nextColor], (daytime % changeColorEvery) / changeColorEvery);
    }

    void EndDay()
    {
        //daytime = 0f;
        currentColor = 0;

        if (Sheeps.Any(x => !x.IsSafe()))
        {
            GameOver();
        }
        else
        {
            YouWon();
        }
    }

    void GameOver()
    {
        isGameOver = true;
        SceneManager.LoadScene(1);
        Debug.Log("Game OVER");
    }
    void YouWon()
    {
        SceneManager.LoadScene(2);
        Debug.Log("You WON!");

    }

    private void OnDrawGizmos()
    {
        //Gizmos.color.a = 0.3f;

        Gizmos.DrawSphere(SpawnCenter.transform.position, Radius);
    }
}
