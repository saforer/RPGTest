using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class Player {
	
	int CurHP;
	public string name;
	public int MaxHP;
	public int MaxMP;
	public int CurMP;
	public int Damage;
	public int Defense;
	
	public void NewPlayer () {
		
		Mobs ThisEnemy = new Mobs(ValidMobs.Player);
		
		Player ThisPlayer = new Player();
		
		ThisPlayer.CurHP = ThisEnemy.CurHP;
		ThisPlayer.MaxHP = ThisEnemy.MaxHP;
		ThisPlayer.CurMP = ThisEnemy.CurMP;
		ThisPlayer.MaxMP = ThisEnemy.MaxMP;
		ThisPlayer.Damage = ThisEnemy.Damage;
		ThisPlayer.Defense = ThisEnemy.Defense;
		
		
	}
	

}

