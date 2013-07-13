using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class Player : Mobs {
	
	public string FName;
	public string LName;
	
	public List<ValidItems> itemList;
	public List<Moves> metaList;
	
	public Player () {
		moveList = new List<Moves>();
		metaList = new List<Moves>();
		
		
		
		name = "Player";
		FName = "Var";
		LName = "Null";
		MaxHP = 40;
		CurHP = 40;
		MaxMP = 10;
		CurMP = 10;
		Damage = 3;
		Defense = 1;
		
  		moveList.Add(Moves.Wobble);
		
		metaList.Add(Moves.Flamethrower);
		
		
		itemList = new List<ValidItems>();
	}
}

