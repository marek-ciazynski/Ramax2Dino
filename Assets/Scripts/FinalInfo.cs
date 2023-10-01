using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class FinalInfo : MonoBehaviour
{
    [SerializeField] GameObject[] dinoPrefabs;
    // Start is called before the first frame update
    void Start()
    {
        var dd = Statistics.statistics;
        var maxValue = dd.Aggregate((x, y) => x.Value >= y.Value ? x : y).Key;

        GameObject dino = dinoPrefabs.ToList().Where(x => x.tag == maxValue).First();
        GameObject gameObject = Instantiate(
            dino,
            transform.position,
            Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
