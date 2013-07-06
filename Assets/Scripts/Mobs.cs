using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public enum ValidMobs {
	Player,
	Knight
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
	
	public Mobs (ValidMobs Name) {
		
		switch (Name) {
			case ValidMobs.Knight:
			name = "Knight";
			MaxHP = 20;
			CurHP = 20;
			MaxMP = 10;
			CurMP = 10;
			Damage = 2;
			Defense = 5;
			moveList = new List<Moves>();
    		moveList.Add(Moves.Attack);
    		moveList.Add(Moves.Wobble);
			break;
			case ValidMobs.Player:
			name = "Sniper";
			MaxHP = 40;
			CurHP = 40;
			MaxMP = 10;
			CurMP = 10;
			Damage = 3;
			Defense = 1;
			moveList = new List<Moves>();
    		moveList.Add(Moves.Attack);
    		moveList.Add(Moves.Wobble);
			break;
		}
	}
}
