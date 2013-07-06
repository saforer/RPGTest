using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public enum Moves
  {
    Attack,
    Wobble
  }

public static class MovesManager
{
  
  
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
    }
  }
  
  public static void Attack(Mobs caster, Mobs target) {
	int Damage = (caster.Damage - target.Defense);
			
		if(Damage<0) {
			Damage=1;
		}
			
    target.CurHP -= Damage;
  }
  
  public static void Wobble(Mobs caster, Mobs target) {
	if (target.Defense>1) {
		target.Defense--;  // wobbles cause target to have lowered defenses
	}
  }
	
	
	
	
	
}
 
