using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fruit : MonoBehaviour
{
    [SerializeField] GameObject[] fruitPrefab;
    [SerializeField] float secondSpawn = 0.5f;
    [SerializeField] float minTres = 0.5f;
    [SerializeField] float maxTres = 0.5f;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(FruitSpawn());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator FruitSpawn()
    {
        while(true)
        {
            var wanted = Random.Range(minTres, maxTres);
            var position = new Vector3(wanted, transform.position.y);
            GameObject gameObject = Instantiate(
                fruitPrefab[Random.Range(0, fruitPrefab.Length)], 
                position,
                Quaternion.identity);
            yield return new WaitForSeconds(secondSpawn);
            Destroy(gameObject, 5f);
        }
    }
}
