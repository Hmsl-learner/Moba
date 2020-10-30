using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Transform target;
    private TowerController tower;
    public int bulletType;
    private int damage = 50;
    private float speed = 10;
    // Update is called once per frame
    void Update()
    {
        if (target == null) Destroy(gameObject);
        else
        {
            Vector3 dir = target.position - transform.position;
            GetComponent<Rigidbody>().velocity = dir.normalized * speed;
        }
    }

    public void SetTarget(Transform transform)
    {
        target = transform;
    }
    public void SetTower(TowerController tower)
    {
        this.tower = tower;
    }
    private void OnTriggerEnter(Collider other)
    {
        GameObject go = other.gameObject;
        if (go.transform == target)
        {
            // 造成伤害
            //DOHeart();
            Destroy(gameObject);
        }
    }
    void DOHeart(ICharacter soldier)
    {
        soldier.UnderAttack(damage);
    }
}
