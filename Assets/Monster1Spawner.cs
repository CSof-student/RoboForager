using UnityEngine;

public class Monster1Spawner : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public GameObject Monster1Prefab;

    void Start()
    {
       createMonster(25,25, 12,12);
       createMonster(25,25, -12,-12);
       createMonster(25,25, -12,12);
       createMonster(25,25, 12,-12);
       createMonster(25,25, 0,-12);
       createMonster(25,25, 0,12);
       createMonster(25,25, 0,24);
       createMonster(25,25, 0,-24);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void createMonster(float gridLength, float gridWidth, float centerX, float centerZ) {
        Vector3 mGridCenter = new Vector3(centerX, 0.5f, centerZ);
        Vector2 mGridDimensions = new Vector2(gridLength, gridWidth);
        MonsterBehaviorTemplate Monster = Instantiate(Monster1Prefab, mGridCenter, Quaternion.identity).GetComponent<MonsterBehaviorTemplate>();
        Monster.setGrid(mGridCenter,mGridDimensions);
        Monster.setTarget();
    }
}
