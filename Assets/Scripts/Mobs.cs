using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public enum ValidMobs {
	Skeleton,
	Knight,
	Sniper
}

public class Mobs : FSprite {
	
	public string name;
	public int MaxHP;
	public int CurHP;
	public int MaxMP;
	public int CurMP;
	public int Damage;
	public int Defense;
	public List<Moves> moveList;
	public List<int> weightList;
	
	public Mobs (ValidMobs Name) {
		
		switch (Name) {
				
			case ValidMobs.Skeleton:
				name = "Skeleton";
				MaxHP = 10;
				CurHP = 10;
				MaxMP = 2;
				CurMP = 2;
				Damage = 7;
				Defense = 3;
			
				moveList = new List<Moves>();
				weightList = new List<int>();
	    		moveList.Add(Moves.Wobble);
	    		weightList.Add (15);	
				moveList.Add (Moves.Flamethrower);
				weightList.Add (20);
				moveList.Add(Moves.Attack);
				weightList.Add (100);
			
				break;
				
			case ValidMobs.Knight:
				name = "Knight";
				MaxHP = 20;
				CurHP = 20;
				MaxMP = 10;
				CurMP = 10;
				Damage = 2;
				Defense = 5;
				moveList = new List<Moves>();
				weightList = new List<int>();
	    		moveList.Add(Moves.Wobble);
				weightList.Add (50);
	    		moveList.Add(Moves.Attack);
				weightList.Add (100);
				break;
				
			case ValidMobs.Sniper:
				name = "Sniper";
				MaxHP = 20;
				CurHP = 20;
				MaxMP = 10;
				CurMP = 10;
				Damage = 5;
				Defense = 2;
				moveList = new List<Moves>();
				weightList = new List<int>();
				moveList.Add (Moves.Wobble);
	    		weightList.Add (15);	
				moveList.Add (Moves.Attack);
				weightList.Add (100);
				break;
				

					
				
		}
	}
	
	public Mobs () {
			
	}
	

	
}
