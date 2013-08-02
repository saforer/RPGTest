using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public enum ValidItems {
	Potion,
	Pancakes,
	Waffles,
	Lager,
	Jelly,
	Milk
}


public static class Item {
	
	public static string ItemName;
	public static int ItemPrice;
	
	public static void UseItem (Mobs caster, Mobs target, ValidItems item) 	{
		switch (item) {
		case ValidItems.Potion:
			ItemName="Potion";
			target.CurHP +=10;
			StandardCheck(target);
			ItemPrice = 50;
			break;
		case ValidItems.Pancakes:
			ItemName="Pancakes";
			target.CurHP +=20;
			StandardCheck(target);
			ItemPrice = 150;
			break;
		case ValidItems.Waffles:
			ItemName="Waffles";
			ItemPrice = 150;
			target.CurHP +=21;
			StandardCheck(target);
			break;
		case ValidItems.Lager:
			ItemName="Lager";
			ItemPrice=30;
			target.CurMP +=10;
			StandardCheck(target);
			break;
		case ValidItems.Jelly:
			ItemName="Jelly";
			ItemPrice=100;
			target.CurHP +=10;
			target.CurMP +=10;
			StandardCheck(target);
			break;
		case ValidItems.Milk:
			ItemName="Milk";
			ItemPrice=75;
			target.CurMP +=20;
			StandardCheck(target);
			break;
			
			
		}		
	}
	
	public static void StandardCheck(Mobs target) {
	if (target.CurHP>target.MaxHP) target.CurHP=target.MaxHP;	
	if (target.CurMP>target.MaxMP) target.CurMP=target.MaxMP;	
	}
	
}


