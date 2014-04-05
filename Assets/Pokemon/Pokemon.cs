using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Pokemon{
	public static List<Pokemon> party = new List<Pokemon>();
	public static Pokemon selected = null;

	private int number, health, attack, defense, sp_attack, sp_defense, speed, level;
	private string name = "";
	private float xp, hp, pp;
	private Texture2D icon = null;
	private List<Move> moves = new List<Move>();
	private bool isPlayer;
	private Item heldItem = null;

	public Pokemon(int number, bool isPlayer){
		number = number;
		health = getHealth(number);
		attack = getAttack(number);
		defense = getDefense(number);
		sp_attack = getSp_Attack(number);
		sp_defense = getSp_Defense(number);
		speed = getSpeed(number);
		level = getLevel(number);
		name = getName(number);
		xp = getXP(number);
		hp = getHp(number);
		pp = getPP(number);
		icon = getIcon(number);
		isPlayer = isPlayer;
		PopulateMoves();
		
		name = GetName(number);
		icon = GetIcon(number);
		level = 5;
		hp = 1;
		pp = 1;
		xp = Random.value;
		PopulateMoves();
	}

	public Pokemon(int number, bool isPlayer, int level){
		Debug.Log("New "+GetName(number));
		number = number;
		isPlayer = isPlayer;
		name = GetName(number);
		icon = GetIcon(number);
		level = level;
		
		hp = 1;
		pp = 1;
		PopulateMoves();
	}

	public void Damage(Pokemon otherPoke, Move move){
		//this must take into account weakness and attributes (defense, attack, sp_Defense, sp_Attack)
		//this must be object oriented
		float damage = 1;
		hp -= damage/(float)TotalHP();	//replace with some elabourate forumla
		GiveXP(10);
	}
	
	public string getName(int num){
		
	}
	
	public int getHealth(int num){
		
	}
	
	public int getHealth(int num){
		
	}
	
	public int getHealth(int num){
		
	}
	public int getHealth(int num){
		
	}
	
	public int TotalHP(){
		return (Pokemon_BaseStats.Health((Pokemon_Names)number)+50)*level/50 + 10;
	}
	public int TotalAttack(){
		return (Pokemon_BaseStats.Attack((Pokemon_Names)number))*level/50 + 5;
	}
	public int TotalDefence(){
		return (Pokemon_BaseStats.Defence((Pokemon_Names)number))*level/50 + 5;
	}
	public int TotalSpeed(){
		return (Pokemon_BaseStats.Speed((Pokemon_Names)number))*level/50 + 5;
	}
	public string GetName() {
		return this.name;
	}

	public void PopulateMoves(){
		switch(number){

		case 1:		//Bulbasaur
			moves.Add(new Move(MoveNames.Tackle));
			moves.Add(new Move(MoveNames.Growl));
			if (level>=7)	moves.Add(new Move(MoveNames.LeechSeed));
            if (level>=9)	moves.Add(new Move(MoveNames.VineWhip));
			break;

		case 4:		//Charmander
			moves.Add(new Move(MoveNames.Scratch));
			 moves.Add(new Move(MoveNames.Growl));
			if (level>=7)	moves.Add(new Move(MoveNames.Ember));
			if (level>=10)	moves.Add(new Move(MoveNames.Smokescreen));
			break;

		case 7:		//Squirtle
			moves.Add(new Move(MoveNames.Tackle));
			moves.Add(new Move(MoveNames.TailWhip));
			if (level>=7)	moves.Add(new Move(MoveNames.WaterGun));
			if (level>=10)	moves.Add(new Move(MoveNames.Withdraw));
			break;

		case 19:	//Rattata
			moves.Add(new Move(MoveNames.Tackle));
			moves.Add(new Move(MoveNames.TailWhip));
			if (level>=4)	moves.Add(new Move(MoveNames.QuickAttack));
			if (level>=7)	moves.Add(new Move(MoveNames.FocusEnergy));
			if (level>=10)	moves.Add(new Move(MoveNames.Bite));
			break;

		}
	}

	static int XPtoNextLevel(int level){
		return level*level*level;
	}
	public void GiveXP(int addXP){
		xp += (float)addXP/(float)XPtoNextLevel(level);
		if (xp>1){
			float excessXP = (xp-1)*(float)XPtoNextLevel(level);
			level++;
			xp = excessXP/(float)XPtoNextLevel(level);
		}
	}

	public static string GetName(int number){
		//instead of doing this it would be much easier to pass in a pokemon and take it's name from its inherent method
		switch(number){
		case 1: return "Bulbasaur";
		case 4: return "Charmander";
		case 7: return "Squirtle";
		case 19: return "Rattata";
		}
		return "Missingno";
	}
	public static int GetNumber(string name){
		name = name.ToLower();
		Debug.Log(name);
		switch(name){
		case "bulbasaur":	return 1;
		case "charmander":	return 4;
		case "squirtle":	return 7;
		case "rattata":		return 19;
		}
		return 0;
	}

	public static Texture2D GetIcon(int number){
		return (Texture2D)Resources.Load("Icons/"+GetName(number));
	}
	
	
}

enum ElementNames{
	Normal,
	Fire,
	Fighting,
	Water,
	Flying,
	Grass,
	Poison,
	Electric,
	Ground,
	Psychic,
	Rock,
	Ice,
	Bug,
	Dragon,
	Ghost,
	Dark,
	Steel,
	Fairy
}
