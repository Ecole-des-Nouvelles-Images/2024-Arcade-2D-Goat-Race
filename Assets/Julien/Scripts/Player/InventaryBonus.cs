using System;
using System.Collections;
using System.Collections.Generic;
using Julien.Scripts.BonusScripts;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;
using Random = UnityEngine.Random;

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
        [SerializeField] private GameObject _bonusLogoHUD;
        
        [SerializeField] private Bonus Bonus;
        [SerializeField] private Sprite _noneSprite;
        
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
            _bonusLogoHUD.GetComponent<Image>().color = new Color(1, 1, 1, 1);
            Debug.Log(BonusName);
        }
        
        public void Bonus1()
        {
            Debug.Log("Speed");
            BonusName = "Speed";
            Bonus = _bonusScripts[0];
           _bonusLogoHUD.GetComponent<Image>().sprite = _bonusScripts[0]._sprite;
        }
        public void Bonus2()
        {
            Debug.Log("Traverser");
            BonusName = "Traverser";
            Bonus = _bonusScripts[1];
            _bonusLogoHUD.GetComponent<Image>().sprite = _bonusScripts[1]._sprite;
        }
        public void Bonus3()
        {
            Debug.Log("Pic");
            BonusName = "Pic";
            Bonus = _bonusScripts[2];
            _bonusLogoHUD.GetComponent<Image>().sprite = _bonusScripts[2]._sprite;
        }

        public void Use()
        {
            Bonus.BonusEffect(gameObject, Spike);
            StartCoroutine("Delay");
            _bonusLogoHUD.GetComponent<Image>().sprite = _noneSprite ;
            _bonusLogoHUD.GetComponent<Image>().color = new Color(1, 1, 1, 0);
        }

        public IEnumerator Delay()
        {
            IsUsingBonus = true;
            yield return new WaitForSeconds(BonusTime);
            Bonus.BonusReset(gameObject, Spike);
            IsUsingBonus = false;
        }
    }
}
