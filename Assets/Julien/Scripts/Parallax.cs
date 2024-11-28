using UnityEngine;

public class Parallax : MonoBehaviour
{
   [SerializeField] private ParallaxData _parallaxData;
   [SerializeField] private bool _player1Layer;
   
   [SerializeField] private GameObject Plan1;
   [SerializeField] private GameObject Plan2;
   [SerializeField] private GameObject Plan3;
   [SerializeField] private GameObject Plan4;

   private Sprite SpritePlan1;
   private Sprite SpritePlan2;
   private Sprite SpritePlan3;
   private Sprite SpritePlan4;
   
   [SerializeField] private float _speedPlan1;
   [SerializeField] private float _speedPlan2;
   [SerializeField] private float _speedPlan3;
   [SerializeField] private float _speedPlan4;

   [SerializeField] private GameObject _player;
   [SerializeField] private Rigidbody2D _rb2dPlayer;

   private void Awake()
   {
      _rb2dPlayer = _player.GetComponent<Rigidbody2D>();
   }

   private void Start()
   {
      SetUpParallax();
   }

   private void FixedUpdate()
   {
      float velocityX = _rb2dPlayer.velocity.x;
      
      // PLAN 1
      if (_rb2dPlayer.velocity.x > 0)
      {
         Plan1.gameObject.transform.Translate(Vector3.right * (_speedPlan1 * velocityX * Time.deltaTime));
      }
      if (_rb2dPlayer.velocity.x < 0)
      {
         Plan1.gameObject.transform.Translate(Vector3.right * (-_speedPlan1 * -velocityX * Time.deltaTime));
      }
      
      // PLAN 2
      if (_rb2dPlayer.velocity.x > 0)
      {
         Plan2.gameObject.transform.Translate(Vector3.right * (_speedPlan2 * velocityX * Time.deltaTime));
      }
      if (_rb2dPlayer.velocity.x < 0)
      {
         Plan2.gameObject.transform.Translate(Vector3.right * (-_speedPlan2 * -velocityX * Time.deltaTime));
      }
      
      // PLAN 3
      if (_rb2dPlayer.velocity.x > 0)
      {
         Plan3.gameObject.transform.Translate(Vector3.right * (_speedPlan3 * velocityX * Time.deltaTime));
      }
      if (_rb2dPlayer.velocity.x < 0)
      {
         Plan3.gameObject.transform.Translate(Vector3.right * (-_speedPlan3 * -velocityX * Time.deltaTime));
      }
      
      if (_rb2dPlayer.velocity.x > 0)
      {
         Plan4.gameObject.transform.Translate(Vector3.right * ( velocityX * Time.deltaTime));
      }
      if (_rb2dPlayer.velocity.x < 0)
      {
         Plan4.gameObject.transform.Translate(Vector3.right * ( velocityX * Time.deltaTime));
      }
      
      
   }
   
   private void Update()
   {
      if (_player1Layer)
      {
         gameObject.layer = LayerMask.NameToLayer("Parallax1");
      }
      else
      {
         gameObject.layer = LayerMask.NameToLayer("Parallax2");
      }
   }

   public void SetUpParallax()
   {
      SpritePlan1 = _parallaxData.Sprite1;
      SpritePlan2 = _parallaxData.Sprite2;
      SpritePlan3 = _parallaxData.Sprite3;
      SpritePlan4 = _parallaxData.Sprite4;

      Plan1.GetComponent<SpriteRenderer>().sprite = SpritePlan1;
      Plan2.GetComponent<SpriteRenderer>().sprite = SpritePlan2;
      Plan3.GetComponent<SpriteRenderer>().sprite = SpritePlan3;
      Plan4.GetComponent<SpriteRenderer>().sprite = SpritePlan4;
   }
}
