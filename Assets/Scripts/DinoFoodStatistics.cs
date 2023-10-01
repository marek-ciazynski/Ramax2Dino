using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DinoFoodStatistics : MonoBehaviour
{
    [SerializeField] private Collider2D headCollider;
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
