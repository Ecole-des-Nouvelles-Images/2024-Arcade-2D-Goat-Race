using System.Collections;
using System.Collections.Generic;
using Julien.Scripts.BonusScripts;
using UnityEngine;

namespace Julien.Scripts
{
    public class InventaryBonus : MonoBehaviour
    {
        public float BonusTime = 2f;
        public bool HaveBonus;
        public bool IsUsingBonus;
        public string BonusName;

        [SerializeField] private GameObject Spike;
        [SerializeField] private List<Bonus> _bonusScripts;
        [SerializeField] private Bonus _bonus;
    
        public void RandomBonus()
        {
            System.Action[] methods = new System.Action[]
            {
                Bonus1,
                //Bonus2,
                Bonus3
            }; 
        
            int randomIndex = Random.Range(0, methods.Length);
            methods[randomIndex]();
        
            Debug.Log(BonusName);
        }

        public void Bonus1()
        {
            Debug.Log("Speed");
            BonusName = "Speed";
            _bonus = _bonusScripts[0];
        }
        public void Bonus2()
        {
            Debug.Log("Traverser");
            BonusName = "Traverser";
            _bonus = _bonusScripts[1];
        }
        public void Bonus3()
        {
            Debug.Log("Pic");
            BonusName = "Etoile";
            _bonus = _bonusScripts[2];
        }

        public void Use()
        {
            _bonus.BonusEffect(gameObject, Spike);
            StartCoroutine("Delay");
        }

        public IEnumerator Delay()
        {
            IsUsingBonus = true;
            yield return new WaitForSeconds(BonusTime);
            _bonus.BonusReset(gameObject, Spike);
        }
    }
}
