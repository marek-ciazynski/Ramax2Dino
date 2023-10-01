using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DinoFoodStatistics : MonoBehaviour
{
    [SerializeField] private Collider2D headCollider;
    [SerializeField] private Text timer;
    [SerializeField] private float timeLeft = 30f;
    [SerializeField] private bool timerOn = true;
    private Dictionary<string, int> statistics;
    // Start is called before the first frame update

    private void Awake()
    {
    }

    void Start()
    {
        statistics = new Dictionary<string, int>();
    }

    // Update is called once per frame
    void Update()
    {
        if(timerOn)
        {
            if(timeLeft > 0)
            {
                timeLeft -= Time.deltaTime;
                timer.text = ((int)timeLeft).ToString();
            }
            else
            {
                Statistics.statistics = statistics;
                SceneManager.LoadScene("FinalScene", LoadSceneMode.Single);
                timeLeft = 0;
                timerOn = false;
            }
        }
    }


    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.name != "Tilemap" && col.gameObject.name != "End" && col.gameObject.name != "Start")
        {
            if (col.otherCollider == headCollider)
            {
                var value = statistics.GetValueOrDefault(col.gameObject.tag, 0);
                value += 1;
                statistics[col.gameObject.tag] = value;
                Destroy(col.gameObject);
            }
        }
    }
}
