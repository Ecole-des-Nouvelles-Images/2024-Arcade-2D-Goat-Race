using System;
using System.Collections;
using System.Collections.Generic;
using Julien.Scripts.BonusScripts;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

namespace Julien.Scripts
{
    public class InventaryBonus : MonoBehaviour
    {
        public float BonusTime;
        public bool HaveBonus;
        public bool IsUsingBonus;
        public string BonusName;

        public bool CanUse;
        [SerializeField] private GameObject _sfxManager;
        private SongSFX _songSFX;
        private AudioSource _audioSource;
        
        [SerializeField] Goat _goat;
        [SerializeField] private GameObject Spike;
        [SerializeField] private List<Bonus> _bonusScripts;
        [SerializeField] private GameObject _bonusLogoHUD;
        
        [SerializeField] private Bonus Bonus;
        [SerializeField] private Sprite _noneSprite;

        private void Awake()
        {
          _sfxManager = GameObject.Find("SFXManager");
          _songSFX = _sfxManager.GetComponent<SongSFX>();
          _audioSource = gameObject.GetComponent<AudioSource>();
        }

        private void Start()
        {
            
        }

        private void Update()
        {
            if (gameObject.GetComponent<Goat>().PlayerNumber == 1 && GameObject.Find("BonusLogo1") != null)
            {
                _bonusLogoHUD = GameObject.Find("BonusLogo1");
            }
            if (gameObject.GetComponent<Goat>().PlayerNumber == 2 && GameObject.Find("BonusLogo2") != null)
            {
                _bonusLogoHUD = GameObject.Find("BonusLogo2");
            }
            if (gameObject.GetComponent<Goat>().PlayerNumber == 3 && GameObject.Find("BonusLogo3") != null)
            {
                _bonusLogoHUD = GameObject.Find("BonusLogo3");
            }
            if (gameObject.GetComponent<Goat>().PlayerNumber == 4 && GameObject.Find("BonusLogo4") != null)
            {
                _bonusLogoHUD = GameObject.Find("BonusLogo4");
            }
        }

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
            BonusName = "Speed";
            Bonus = _bonusScripts[0];
            BonusTime = _bonusScripts[0].Timer;
           _bonusLogoHUD.GetComponent<Image>().sprite = _bonusScripts[0]._sprite;
        }
        public void Bonus2()
        {
            BonusName = "Traverser";
            Bonus = _bonusScripts[1];
            BonusTime = _bonusScripts[1].Timer;
            _bonusLogoHUD.GetComponent<Image>().sprite = _bonusScripts[1]._sprite;
        }
        public void Bonus3()
        {
            BonusName = "Pic";
            Bonus = _bonusScripts[2];
            BonusTime = _bonusScripts[2].Timer;
            _bonusLogoHUD.GetComponent<Image>().sprite = _bonusScripts[2]._sprite;
        }

        public void Use()
        {
            Bonus.BonusEffect(gameObject, Spike, _songSFX);
            StartCoroutine("DelayBonusRest");
            _bonusLogoHUD.GetComponent<Image>().sprite = _noneSprite ;
            _bonusLogoHUD.GetComponent<Image>().color = new Color(1, 1, 1, 0);
        }

        public IEnumerator DelayBonusRest()
        {
            IsUsingBonus = true;
            yield return new WaitForSeconds(BonusTime);
            Bonus.BonusReset(gameObject, Spike, _songSFX);
            StartCoroutine(DestroySound());
            IsUsingBonus = false;
        }

        public IEnumerator DestroySound()
        {
            yield return new WaitForSeconds(2f);
            Bonus.DestroySound(gameObject, Spike, _songSFX);
        }
    }
}
