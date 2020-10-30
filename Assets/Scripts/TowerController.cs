using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerController : MonoBehaviour
{
    [SerializeField] private GameObject BulletPre;
    private Transform bulletsParent;
    public int towerType;
    public List<GameObject> targets = new List<GameObject>();
    private List<GameObject> players = new List<GameObject>();

    private float attackTime = 2f;
    private float timer = 1.8f;

    void Start()
    {
        this.enabled = false;
        bulletsParent = transform.Find("bulletsParent");
    }

    void Update()
    {
        if (timer >= attackTime)
        {
            // 攻击小兵
            if (targets.Count > 0)
            {
                CreatBullet(targets[0]);
            }
            else if (players.Count > 0)
            {
                CreatBullet(players[0]);
            }
            timer = 0;
        }
        else timer += Time.deltaTime;
       
    }

    //private void OnTriggerEnter(Collider other)
    //{
    //    GameObject go = other.gameObject;
    //    // 如果是英雄
    //    if (go.CompareTag("Player"))
    //    {
    //        PlayerController player = go.GetComponent<PlayerController>();
    //        if (player == null)
    //        {
    //            Debug.Log("这英雄出问题了" + go.name);
    //            return;
    //        }
    //        if (player.playerType == towerType) return;
    //        Debug.Log("发现一个敌方英雄过来了" + go.name);
    //        players.Add(go);
    //    }
    //    // 如果是小兵
    //    else if (go.CompareTag("Soldier"))
    //    {
    //        SoldierWarrior soldier = go.GetComponent<SmartSoldier>();
    //        if (soldier == null)
    //        {
    //            Debug.Log("这小兵出问题了" + go.name);
    //            return;
    //        }
    //        if (soldier.soldierType == towerType) return;
    //        Debug.Log("发现一个敌方小兵过来了" + go.name);
    //        targets.Add(go);
    //    }
    //    // TODO 还有可能是野怪或其他东西
        

    //}
    //private void OnTriggerExit(Collider other)
    //{
    //    GameObject go = other.gameObject;
    //    // 如果是英雄
    //    if (go.CompareTag("Player"))
    //    {
    //        players.Remove(go);
    //    }
    //    // 如果是小兵
    //    else if (go.CompareTag("Soldier"))
    //    {
    //        SmartSoldier soldier = go.GetComponent<SmartSoldier>();
    //        if (soldier == null)
    //        {
    //            Debug.Log("这小兵出问题了" + go.name);
    //            return;
    //        }
    //        if (soldier.soldierType == towerType) return;
    //        Debug.Log("发现一个敌方小兵跑了" + go.name);
    //        targets.Remove(go);
    //    }
    //    // TODO 还有可能是野怪或其他东西
    //}

    void CreatBullet(GameObject target)
    {
        GameObject go = Instantiate(BulletPre, transform.GetChild(0).position + new Vector3(0, 2, 0), Quaternion.identity, bulletsParent);
        Bullet bullet = go.GetComponent<Bullet>();
        bullet.SetTarget(target.transform);
        bullet.SetTower(this);
    }
    void SoldierDead(GameObject gameObject, TowerController tower)
    {
        if (tower == this)
        {
            targets.Remove(gameObject);
        }
    }
}
