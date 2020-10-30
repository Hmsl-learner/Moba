using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoldierMono : MonoBehaviour
{
    public List<ICharacter> targets = new List<ICharacter>();

    private ISoldier soldier;
    [SerializeField]private CampType campType;
    [SerializeField] private CapsuleCollider Parentcollider;

    public void SetSoldier(ISoldier soldier)
    {
        this.soldier = soldier;
    }
    public void SetCamp(CampType campType)
    {
        this.campType = campType;
    }

    private void Start()
    {
        StartCoroutine(OpenCollider());
    }
    private void Update()
    {   
    }
    private void OnTriggerEnter(Collider other)
    {
        if (!other.gameObject.CompareTag("Soldier") && !other.gameObject.CompareTag("Player")) return;
        if (other.gameObject.GetComponentInChildren<SoldierMono>().campType!=campType)
        {
            Debug.Log(1);
            targets.Add(other.gameObject.GetComponentInChildren<SoldierMono>().soldier); 
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (!other.gameObject.CompareTag("Soldier") && !other.gameObject.CompareTag("Player")) return;
        if (other.gameObject.GetComponentInChildren<SoldierMono>().campType != campType)
        {
            Debug.Log(1);
            targets.Remove(other.gameObject.GetComponentInChildren<SoldierMono>().soldier);
        }
    }

    IEnumerator OpenCollider()
    {
        yield return new WaitForSeconds(1);
        gameObject.GetComponent<CapsuleCollider>().enabled = true;
        Parentcollider.enabled = true;
    }
}
