using System.Collections.Generic;
using Julien.Scripts.BonusScripts;
using UnityEngine;

public class InventaryBonus : MonoBehaviour
{
    public bool HaveBonus;
    public string BonusName;
    [SerializeField] private List<Bonus> _bonusScripts;
    [SerializeField] private Bonus _bonus;
    
    public void RandomBonus()
    {
        System.Action[] methods = new System.Action[]
        {
            Bonus1,
            Bonus2,
            Bonus3
        }; 
        
        int randomIndex = Random.Range(0, methods.Length);
        methods[randomIndex]();
        
        Debug.Log(BonusName);
    }

    public void Bonus1()
    {
        Debug.Log("Bonus 1");
        BonusName = "Speed";
        _bonus = _bonusScripts[0];
    }
    public void Bonus2()
    {
        Debug.Log("Bonus 2");
        BonusName = "Traverser";
        _bonus = _bonusScripts[1];
    }
    public void Bonus3()
    {
        Debug.Log("étoile");
        BonusName = "Etoile";
        _bonus = _bonusScripts[2];
    }

    public void Use()
    {
        _bonus.BonusEffect();
    }
}
