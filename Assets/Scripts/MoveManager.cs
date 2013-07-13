using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public enum Moves
  {
    Attack,
    Wobble,
	Flamethrower
  }

public static class MovesManager
{
  
	public static string MoveName;
	
  public static void PerformMove(Mobs caster, Mobs target, Moves move)
  {
    switch(move)
    {
		case Moves.Attack:
        	Attack(caster, target);
        	break;
      	case Moves.Wobble:
        	Wobble(caster, target);
	        break;
		case Moves.Flamethrower:
			Flamethrower (caster,target);
			break;
    }
  }
  
  public static void Attack(Mobs caster, Mobs target) {
	int Damage = (caster.Damage - target.Defense);
			
		if(Damage<1) {
			Damage=1;
		}
		if(target.CurHP>0)	{
			target.CurHP -= Damage;
			UI.AddMessage ("Attack", caster.name + " has Attacked for " + Damage);
		}
  }
  
  public static void Wobble(Mobs caster, Mobs target) {
		
	if (target.Defense>1) {
		target.Defense--;  // wobbles cause target to have lowered defenses
		UI.AddMessage ("Wobble", caster.name + " has Wobbled lowering Defense");
	} else {
		UI.AddMessage ("Wobble", caster.name + " has Wobbled futilly");
	}
		
		
  }
	
	public static void Flamethrower(Mobs caster, Mobs target) {
	int Damage = (caster.Damage/3 - target.Defense);
	
		
		if(Damage<1) {
			Damage=1;
		}
		if(target.CurHP>0)	{
			target.CurHP -= Damage;
			UI.AddMessage ("Flamethrower", caster.name + " has Attacked for " + Damage);
		}
		if(Damage<1) {
			Damage=1;
		}
		if(target.CurHP>0)	{
			target.CurHP -= Damage;
			UI.AddMessage ("Flamethrower", caster.name + " has Attacked for " + Damage);
		}
		if(Damage<1) {
			Damage=1;
		}
		if(target.CurHP>0)	{
			target.CurHP -= Damage;
			UI.AddMessage ("Flamethrower", caster.name + " has Attacked for " + Damage);
		}
		
	}
	
	
}
 
