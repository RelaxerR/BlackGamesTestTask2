using System.Collections;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField] private GameObject SpawnPos;
    [SerializeField] private GameObject RedCubePrefab;
    [SerializeField] private GameObject BlueCubePrefab;

    public static int _CubesCount { get; private set; }

    void Start(){
        _CubesCount = Random.Range(5, 10);

        UI.Instance.GameStartedEvent += SpawnCubes;
    }
    void OnDestroy(){
        UI.Instance.GameStartedEvent -= SpawnCubes;
    }

    private void SpawnCubes(){
        StartCoroutine(Spawner());
    }

    private IEnumerator Spawner(){ // Sequential appearance of cubes
        for (int i = 0; i < _CubesCount; i++){
            GameObject prefab;

            if (Random.value < 0.5f)
                prefab = RedCubePrefab;
            else
                prefab = BlueCubePrefab;

            Instantiate(
                prefab,
                SpawnPos.transform.position + new Vector3(Random.Range(-1, 1), 0, Random.Range(-1, 1)),
                SpawnPos.transform.rotation,
                this.transform
            );

            yield return new WaitForSeconds(0.5f);
        }
    } 
}