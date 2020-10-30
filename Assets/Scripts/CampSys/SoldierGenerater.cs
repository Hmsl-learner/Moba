using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SoldierGenerater : MonoBehaviour
{
    [SerializeField] private Transform startParent;
    [SerializeField] private Transform[] Midtowers;
    [SerializeField] private Transform[] Uptowers;
    [SerializeField] private Transform[] Downtowers;
    public CampType CampType;

    bool canGenerate = true;
    int soldierCount = 2;
    float waitTime = 5;
    float delayTime = 1f;
    float spawnTime = 10;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Generate(waitTime,delayTime,spawnTime));
    }

    
    void GeneraterSoldier(Transform[] towers, RoadType road, CampType type) 
    {
        FactoryManager.soldierFactory.CreatCharacter<SoldierWarrior>(startParent.position, startParent, road, type, towers);
    }

    private IEnumerator Generate(float waitTime, float delayTime, float spawnTime)
    {
        yield return new WaitForSeconds(waitTime);  // 第一批小兵出生时间
        while (canGenerate)
        {
            for (int i = 0; i < soldierCount; i++)
            {
                GeneraterSoldier(Uptowers, RoadType.Up, CampType);
                GeneraterSoldier(Midtowers, RoadType.Mid, CampType);
                GeneraterSoldier(Downtowers, RoadType.Down, CampType);
                yield return new WaitForSeconds(delayTime);
            }
            yield return new WaitForSeconds(spawnTime);
        }

    }
}
