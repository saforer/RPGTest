using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class Player : Mobs {
	
	public string FName;
	public string LName;
	
	public Player () {
		
		name = "Player";
		FName = "Dingus";
		LName = "Fringus";
		MaxHP = 40;
		CurHP = 40;
		MaxMP = 10;
		CurMP = 10;
		Damage = 3;
		Defense = 1;
		moveList = new List<Moves>();
  		moveList.Add(Moves.Attack);
  		moveList.Add(Moves.Wobble);
	}
}

