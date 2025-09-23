using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponFactory : MonoBehaviour
{
    [SerializeField] private Weapon[] weaponsList;
    Dictionary<string, Weapon> weaponDic;

    private void Awake()
    {
        // iniciar el diccionario; iterar por la lista de weapons y pasarlas al dicionario.

        weaponDic = new Dictionary<string, Weapon>();

        foreach (var weapon in weaponsList)
        {
            // nombre de weapon y la prefab
            //weaponDic.Add(//)
            weaponDic.Add(weapon.Id, weapon);
        }
    }

    public Weapon CreateWeapon(string id, Vector3 position)
    {
        if (!weaponDic.TryGetValue(id, out Weapon weapon))
        {
            Debug.LogWarning($"WeaponFactory: no existe un weapon con Id '{id}'.");
            return null;
        }
        return Instantiate(weapon, position, Quaternion.identity);
    }
}
