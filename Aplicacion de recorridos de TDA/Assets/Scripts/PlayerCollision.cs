using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    [SerializeField] WeaponsManager weaponsManager;
    private PlayerData playerData;
    // Start is called before the first frame update
    void Start()
    {
        playerData = GetComponent<PlayerData>();
        HUDManagers.SetHPBar(playerData.HP);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("PowerUps"))
        {
            Destroy(other.gameObject);
            Destroy(other.gameObject);
            playerData.Healing(other.gameObject.GetComponent<Apple>().HealPoints);
            HUDManagers.SetHPBar(playerData.HP);
            GameManager.Score++;
            Debug.Log(GameManager.Score);
        }

        if (other.gameObject.CompareTag("Munitions"))
        {
            Destroy(other.gameObject);
            Debug.Log("ENTRANDO EN COLISION CON " + other.gameObject.name);
            playerData.Damage(other.gameObject.GetComponent<Munition>().DamagePoints);
            HUDManagers.SetHPBar(playerData.HP);
         
            if (playerData.HP <= 0)
            {
                Debug.Log("GAME OVER");
            }
            GameManager.Score--;
            Debug.Log(GameManager.Score);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Weapons"))
        {
            other.gameObject.SetActive(false);
            weaponsManager.WeaponsList.Add(other.gameObject);

            weaponsManager.WeaponDirectory.Add(other.gameObject.name, other.gameObject);
            Debug.Log(weaponsManager.WeaponDirectory[other.gameObject.name]);
        }
    }
  
}
