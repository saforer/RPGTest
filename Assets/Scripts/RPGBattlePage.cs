using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class RPGBattlePage : RPGPage {
	
	public Mobs MyPlayer;	
	public Mobs MyEnemy;
	public FContainer _UI;
	
	public RPGBattlePage () {
		//Draw Background
		DrawBackground();
		
		//construct player
		Mobs MyPlayer = new Mobs(ValidMobs.Player);
		//construct enemy
		Mobs MyEnemy = new Mobs(ValidMobs.Knight);
		//Draw UI
		_UI.AddChild(UI.DrawInfoBox(MyEnemy));

		//Draw Enemy
		DrawEnemy(MyEnemy);
		//Start Combat
		PlayerTurn();
	}
	
	FSprite _BattleBackground;
	
	private void DrawBackground() {
		_BattleBackground = new FSprite("ForestBackground");
		AddChild(_BattleBackground);
	}
	
		


		FSprite _EnemySprite;
	private void DrawEnemy(Mobs MyEnemy) {
		_EnemySprite = new FSprite(MyEnemy.name);
		_EnemySprite.scale = 5;
		AddChild (_EnemySprite);
	}
	
	private void PlayerTurn() {
		
	}
}


