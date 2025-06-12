/// <summary>
/// Character status. is the Character Structure contain a basic Variables 
/// such as HP , SP , Defend , Name or etc... and you can adding more.
///  - this class will calculate all character Status. ex. Hp regeneration per sec
///  - Checking any event. ex. ApplyDamage , Dead , etc...
///  - After the Character is dead will replaced with Dead body or Ragdoll object [DeadbodyModel]
/// </summary>
using UnityEngine;
using System.Collections;
using System.Linq;
using System.Collections.Generic;
using UnityEngine.UI;
public class CharacterStatus : DamageManager
{
	public GameObject DeadbodyModel;
	public GameObject ParticleObject;
	public GameObject LevelUpFx;
	public GameObject Projectile;
	public Texture2D ThumbnailImage;
	public AudioClip[] SoundHit;
	public AudioClip[] SoundLaunch;
	public GameObject FloatingText;
	public string Name = "Player";
	//[HideInInspector]
	public int HP = 10;
	//[HideInInspector]
	public int SP = 10;
	[HideInInspector]	
	public int SPmax = 10;
	[HideInInspector]
	public int HPmax = 10;
	public int BaseHPmax = 10;
	public int BaseSPmax = 10;
	public int BaseDamage = 1;
	public int BaseDefend = 1;
	public float AttackSpeedMax = 1.5f;
	[HideInInspector]
	public float AttackSpeed = 0.2f;
	[HideInInspector]
	public float AttackSpeedInventory = 0;
	[HideInInspector]
	public int Damage = 2;
	[HideInInspector]
	public int Defend = 2;
	[HideInInspector]
	public int DamageInventory = 2;
	[HideInInspector]
	public int DefendInventory = 2;
	[HideInInspector]
	public int ModelIndex;
	public int HPregen = 1;
	public int SPregen = 1;
	public int EXPgive = 2;
	public int LEVEL = 1;
	public int STR = 2;
	public int AGI = 2;
	public int INT = 2;
	public int STRPlus = 1;
	public int AGIPlus = 1;
	public int INTPlus = 1;
	public int EXP = 0;
	public int EXPmax = 2;
	public int EXPPlus = 50;
	public int StatusPoint = 0;
	public int StatusPointPlus = 3;
	public WeaponType PrimaryWeaponType = WeaponType.Melee;
	public float PrimaryWeaponDistance = 2;
	public bool ForceSpeedAttackByAGI = true;
	public float AGIspeedForceMult = 0.02f;
	private GameObject killer;
	private Vector3 velocityDamage;
	private float lastRegen;
	private CharacterSystem character;
	public Slider barradesaude;
	public Text hphero;
	public Text levelhero;
	public int leveluser;
	public GameObject hero1;
	public int hero1valor;
	public int desumon;
	public int tipohero;
	public int vitoria_ENEMY;
	public int vitoria_player;
	//public string nameuser;
	void Start ()
	{

		character = gameObject.GetComponent<CharacterSystem> ();
		StateCal ();
		character.IsDead = false;

		leveluser = PlayerPrefs.GetInt ("nivel" + hero1valor);
		if (tipohero == 1) {
			//herois
			HP = PlayerPrefs.GetInt ("hitpoint" + hero1valor);
			HPmax = PlayerPrefs.GetInt ("hitpoint" + hero1valor);
			BaseDamage = PlayerPrefs.GetInt ("damage" + hero1valor);
		}
		if (tipohero == 2) {
			//PVP 2
			HP = PlayerPrefs.GetInt ("hitpoint_p" + hero1valor);
			HPmax = PlayerPrefs.GetInt ("hitpoint_p" + hero1valor);
			BaseDamage = PlayerPrefs.GetInt ("damage_p" + hero1valor);
		
		}

		if (tipohero == 3) {
			//PVP 2
			vitoria_ENEMY = PlayerPrefs.GetInt ("victory");
			vitoria_player = PlayerPrefs.GetInt ("vitoria");

			if(vitoria_ENEMY < 300){
				if(hero1valor == 51){
					HP = 1200;
					HPmax = 1200;
					BaseDamage = 34;

				}
				if(hero1valor == 41){
					HP = 790;
					HPmax = 790;
					BaseDamage = 23;
					
				}
			
			}
			if(vitoria_ENEMY >= 300){
				if(vitoria_ENEMY < 700){
				if(hero1valor == 51){
					HP = 1700;
					HPmax = 1700;
					BaseDamage = 45;
					
				}
				if(hero1valor == 41){
					HP = 1200;
					HPmax = 1200;
					BaseDamage = 35;
					}
				}
				
			}
			if(vitoria_ENEMY >= 700){
				if(vitoria_ENEMY < 1500){
				if(hero1valor < 51){
					HP = 2300;
					HPmax = 2300;
					BaseDamage = 55;
					
				}
				if(hero1valor == 41){
					HP = 1500;
					HPmax = 1500;
					BaseDamage = 45;
					
				}
				}
			}
			if(vitoria_ENEMY >= 1500){
				if(hero1valor == 51){
					HP = 3000;
					HPmax = 3000;
					BaseDamage = 75;
					
				}
				if(hero1valor == 41){
					HP = 1700;
					HPmax = 1700;
					BaseDamage = 55;
					
				}
				
			}
			//----------------------
			if(vitoria_player < 300){
				if(hero1valor == 50){
					HP = 1200;
					HPmax = 1200;
					BaseDamage = 34;
					
				}
				if(hero1valor == 40){
					HP = 790;
					HPmax = 790;
					BaseDamage = 23;
					
				}
				
			}
			if(vitoria_player >= 300){
				if(vitoria_player < 700){
					if(hero1valor == 50){
						HP = 1700;
						HPmax = 1700;
						BaseDamage = 45;
						
					}
					if(hero1valor == 40){
						HP = 1200;
						HPmax = 1200;
						BaseDamage = 35;
					}
				}
				
			}
			if(vitoria_player >= 700){
				if(vitoria_player < 1500){
				if(hero1valor < 50){
					HP = 2300;
					HPmax = 2300;
					BaseDamage = 55;
					
				}
				if(hero1valor == 40){
					HP = 1500;
					HPmax = 1500;
					BaseDamage = 45;
					
					}}
				
			}
			if(vitoria_player >= 1500){
				if(hero1valor == 50){
					HP = 3000;
					HPmax = 3000;
					BaseDamage = 75;
					
				}
				if(hero1valor == 40){
					HP = 1700;
					HPmax = 1700;
					BaseDamage = 55;
					
				}
				
			}
		}
		barradesaude.maxValue = HP;

	}

	void StateCal ()
	{
		SPmax = BaseSPmax + (INT * 3);
		HPmax = BaseHPmax + (STR * 5);
		
		if (HP > HPmax)
			HP = HPmax;	

		if (SP > SPmax)
			SP = SPmax;
		
		Damage = (STR * 2) + BaseDamage + DamageInventory;
		Defend = BaseDefend + DefendInventory;
		
		if (AttackSpeedInventory > 0) {
			if (ForceSpeedAttackByAGI) {
				AttackSpeed = AttackSpeedInventory + (AGI * AGIspeedForceMult);
			} else {
				AttackSpeed = AttackSpeedInventory;
			}
		} else {
			if (ForceSpeedAttackByAGI) {
				AttackSpeed = (AGI * AGIspeedForceMult);
			} else {
				AttackSpeed = 0;	
			}
		}
		if (AttackSpeed < 0) {
			AttackSpeed = 0.01f;	
		}
		if (AttackSpeed > AttackSpeedMax) {
			AttackSpeed = AttackSpeedMax;	
		}
		if (character)
			character.speedAttack = AttackSpeed;
	}
	
	private bool offlineMode;

	void Update ()
	{
		desumon = gerenciar_jogo1.fimdejogo1;
		if (desumon == 2) {
		if(hero1.gameObject.name != "1"){
		
				Destroy(hero1);
			}
		
		}

		offlineMode = (!Network.isServer && !Network.isClient);
		barradesaude.value = HP;
		hphero.text = HP.ToString ();

		levelhero.text = leveluser.ToString ();


		
		if (!character.IsDead) {
			if (Network.isServer || offlineMode) {
				if (Time.time - lastRegen >= 1) {
					lastRegen = Time.time;
					HP += HPregen;
					SP += SPregen;
				}
				if (HP > 0) {
					UpdateCharacterStatus (RPCMode.All);
				} else {
					character.IsDead = true;
					if (offlineMode) {
						Dead ();
					} else {
						if ((Network.isClient || Network.isServer) && GetComponent<NetworkView>()) {
							GetComponent<NetworkView>().RPC ("Dead", RPCMode.AllBuffered, null);	
						}
					}
				}
			}
			while (EXP >= EXPmax) {
				LevelUp ();
			}

		}
		StateCal ();
	}

	public void UpdateCharacterStatus (RPCMode mode)
	{
		if (!offlineMode) {
			if ((Network.isClient || Network.isServer) && GetComponent<NetworkView>())
				GetComponent<NetworkView>().RPC ("StateUpdate", mode, HP, SP, EXP, EXPmax, LEVEL, STR, AGI, INT, Damage);
		}
	}

	[RPC]
	public void StateUpdate (int hp, int sp, int exp, int expmax, int level, int Ssrt, int Sagi, int Sint, int dm)
	{
		EXP = exp;
		EXPmax = expmax;
		HP = hp;
		SP = sp;
		LEVEL = level;
		STR = Ssrt;
		AGI = Sagi;
		INT = Sint;
		Damage = dm;

	}

	[RPC]
	public void DamageUpdate (int hp, int sp)
	{
		HP = hp;
		SP = sp;
	}
	
	public void ApplayEXP (int expgot)
	{
		EXP += expgot;
	}
	
	public void LevelUp ()
	{
		EXP -= EXPmax;
		EXPmax += EXPPlus;
		LEVEL += 1;
		StatusPoint += StatusPointPlus;
		STR += STRPlus;
		AGI += AGIPlus;
		INT += INTPlus;
		
		var skillDeployer = this.gameObject.GetComponent<CharacterSkillBase> ();
		if (skillDeployer != null)
			skillDeployer.SkillPoint += 1;	
		
		if (LevelUpFx) {
			GameObject lvup = (GameObject)GameObject.Instantiate (LevelUpFx, this.gameObject.transform.position, Quaternion.identity);	
			lvup.gameObject.transform.parent = this.gameObject.transform;
		}
	}
	
	public void GiveExpToKiller ()
	{
		if (killer) {
			if (killer.GetComponent<CharacterStatus> ()) {
				killer.GetComponent<CharacterStatus> ().ApplayEXP (EXPgive);
			}
		}
	}
	
	public override int ApplayDamage (int damage, Vector3 dirdamge, GameObject attacker)
	{	
	
		if (HP < 0) {
			return 0;	
		}
		if (SoundHit != null && SoundHit.Length > 0) {
			int randomindex = Random.Range (0, SoundHit.Length);
			if (SoundHit [randomindex] != null) {
				AudioSource.PlayClipAtPoint (SoundHit [randomindex], this.transform.position);	
			}
		}
		if (character) {
			character.GotHit (1);
		}
		var damval = damage - Defend;
		if (damval < 1) {
			damval = 1;	
		}
		
		AddFloatingText (this.transform.position, damval.ToString ());
		
		if (Network.isServer || offlineMode) {
			killer = attacker;
			velocityDamage = dirdamge;
			HP -= damval;
		}
		return damval;
	}
	
	public override void AddParticle (Vector3 pos)
	{
		if (ParticleObject) {
			var bloodeffect = (GameObject)Instantiate (ParticleObject, pos, transform.rotation);
			GameObject.Destroy (bloodeffect, 1);	
		}
		base.AddParticle (pos);
	}

	public void AddFloatingText (Vector3 pos, string text)
	{
		// Adding Floating Text Effect
		if (FloatingText) {
			var floattext = (GameObject)Instantiate (FloatingText, pos, transform.rotation);
			if (floattext.GetComponent<FloatingText> ()) {
				floattext.GetComponent<FloatingText> ().Text = text;
			}
			GameObject.Destroy (floattext, 1);	
		}
	}
	
	public void RemoveCharacter ()
	{		
		if (GetComponent<NetworkView>()) 
			Network.RemoveRPCs (GetComponent<NetworkView>().viewID);
		GameObject.Destroy (this.gameObject);
		
	}

	[RPC]
	public void Dead ()
	{
		character.IsDead = true;
		if (DeadbodyModel) {
			var deadbody = (GameObject)Instantiate (DeadbodyModel, this.gameObject.transform.position, this.gameObject.transform.rotation);
			CopyTransformsRecurse (this.gameObject.transform, deadbody.transform);
			Destroy (deadbody, 10.0f);
		}
		if (this.GetComponent<CharacterDie> ()) {
			this.GetComponent<CharacterDie> ().OnDead ();
		}
		GiveExpToKiller ();

		RemoveCharacter ();	
	
	}
	
	public void CopyTransformsRecurse (Transform src, Transform dst)
	{
		// Copy all transforms to Dead object replacement (Ragdoll)
		dst.position = src.position;
		dst.rotation = src.rotation;
		dst.localScale = src.localScale;
		foreach (var child in dst.Cast<Transform>()) {
			var curSrc = src.Find (child.name);
			if (child.GetComponent<Rigidbody>())
				child.GetComponent<Rigidbody>().AddForce (velocityDamage / 3f);

			if (curSrc)
				CopyTransformsRecurse (curSrc, child);
		}
	}

	void OnGUI ()
	{
		
		/*Vector3 pos = Camera.main.WorldToScreenPoint (this.transform.position + (Vector3.up * 2));
		GUI.skin.label.normal.textColor = Color.white;
		GUI.skin.label.fontSize = 16;
		GUI.skin.label.alignment = TextAnchor.MiddleCenter;
		GUI.Label (new Rect (pos.x - 150, (Screen.height - pos.y), 300, 50), Name);
		//GUI.Label (new Rect (pos.x - 150, Screen.height - pos.y, 400, 50), "Level "+LEVEL+" ("+EXP+"/"+EXPmax+") STR:"+STR+" AGI:"+AGI+" INT:"+INT+" DM:"+Damage);*/
	}

}

