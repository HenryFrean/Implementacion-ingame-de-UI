using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponsManager : MonoBehaviour
{
    [SerializeField] GameObject[] weapons;

    [SerializeField] Transform playerHand;

    [SerializeField] List<GameObject> weaponsList;

    public List<GameObject> WeaponsList { get => weaponsList; set => weaponsList = value; }
    public Dictionary<string, GameObject> WeaponDirectory { get => weaponDirectory; set => weaponDirectory = value; }

    private Dictionary<string, GameObject> weaponDirectory;

    // Start is called before the first frame update
    void Start()
    {
        weaponsList = new List<GameObject>();
        weaponDirectory = new Dictionary<string, GameObject>();
    }

    void DiseableAllWeapons()
    {
        for (int i = 0; i < weapons.Length; i++)
        {
            weapons[i].SetActive(false);
        }
    }

    void EnableAllWeapon()
    {
        foreach(var weapon in weaponsList)
        {
            weapon.SetActive(true);
            HUDManagers.Instance.SetSelectedText(weapon.gameObject.name);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1) && HasWeapon("WeaponA")) EquipWeapon(weaponDirectory["WeaponA"], 0);
        if (Input.GetKeyDown(KeyCode.Alpha2) && HasWeapon("WeaponB")) EquipWeapon(weaponDirectory["WeaponB"], 1);
        if (Input.GetKeyDown(KeyCode.Alpha3) && HasWeapon("WeaponC")) EquipWeapon(weaponDirectory["WeaponC"], 2);
        if (Input.GetKeyDown(KeyCode.Alpha4) && HasWeapon("WeaponD")) EquipWeapon(weaponDirectory["WeaponD"], 3);
    }
    public bool HasWeapon(string key)
    {
        return weaponDirectory.ContainsKey(key);
    }

    private void EquipWeapon(GameObject weapon, int indexIcon)
    {
        DetachWeapons();
        weapon.SetActive(true);
        weapon.transform.parent = playerHand;
        weapon.transform.localPosition = Vector3.zero;
        HUDManagers.Instance.SetSelectedText(weapon.gameObject.name);
        HUDManagers.EnableWeapon(indexIcon);
    }
    private void DetachWeapons()
    {

        foreach (Transform child in playerHand)
        {
            child.parent = null;
            child.transform.position = new Vector3(Random.Range(0f, 3f), 1f, Random.Range(0f, 3f));
            child.gameObject.SetActive(true);
        }
    }
}


