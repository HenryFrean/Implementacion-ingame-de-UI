using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUDManagers : MonoBehaviour
{
    // Start is called before the first frame update
    private static HUDManagers instance;
    public static HUDManagers Instance { get => instance; }

    [SerializeField] private Text selectedText;
    [SerializeField] private GameObject weaponPanel;
    [SerializeField] private Slider hpBar;

    private void Awake()
    {
        Debug.Log("EJECUTANDO AWAKE");
        if (instance == null)
        {
            instance = this;
            Debug.Log(instance);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        DisableAllWeaponsIcons();
    }

    // Update is called once per frame
    void Update()
    {
  
    }

    public void SetSelectedText(string newText)
    {
        selectedText.text = newText;
    }

    public static void EnableWeapon(int childIndex)
    {
       DisableAllWeaponsIcons();
       instance
           .weaponPanel
               .transform
                   .GetChild(childIndex)
                       .GetChild(0)
                          .GetComponent<Image>().color = Color.white;
    }

    public static void DisableAllWeaponsIcons()
    {
        foreach (Transform panel in instance.weaponPanel.transform)
        {
            panel.GetChild(0).GetComponent<Image>().color = Color.black;
        }
    }

    public static void SetHPBar(int newValue)
    {
        instance.hpBar.value = newValue;
    }
}
