using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class enemy_spawner : MonoBehaviour
{

    public bool is_wave_active = false;

    [Header("enemies")]
    public GameObject enemy1;

    public float max_x, min_x, max_y, min_y;
    [SerializeField] private Vector2 position;

    private void Start()
    {

        StartCoroutine(spawner(enemy1));
    } 

    void Update()
    {

        position = new Vector2(Random.Range(max_x, min_x), Random.Range(max_y, min_y));
    }

    public IEnumerator spawner(GameObject enemy)
    {

        GameObject newEnemy = Instantiate(enemy, position, Quaternion.identity);
        enemy e = newEnemy.GetComponent<enemy>();
        int duration = e.duration;

        yield return new WaitForSeconds(duration);
        StartCoroutine(spawner(enemy1));
    }
}
