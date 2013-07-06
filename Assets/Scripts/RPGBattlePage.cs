using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class RPGBattlePage : RPGPage {
	
	public Mobs MyPlayer;	
	public Mobs MyEnemy;
	public FContainer _UI;
	bool boolYourTurn = true;
	bool boolEnemyTurn = true;
	public int Framecount;
	
	public RPGBattlePage () {
		//Draw Background
		DrawBackground();
		
		//construct player
		MyPlayer = new Mobs(ValidMobs.Player);
		//construct enemy
		MyEnemy = new Mobs(ValidMobs.Knight);
		//Draw Enemy
		DrawEnemy(MyEnemy);
		//Draw UI
		FContainer _UI = new FContainer();
		_UI.AddChild (UI.DrawPlayer (MyPlayer));
		_UI.AddChild (UI.DrawInfoBox (MyEnemy));
		_UI.AddChild (UI.DrawMessageBox());
		_UI.AddChild (UI.DrawMenuBox());
		_UI.AddChild (UI.DrawHealthBar (MyEnemy));
		_UI.AddChild (UI.SubMenuBox());
		
		UI._AttackButton.SignalRelease += HandleUI_AttackButtonSignalRelease;
		UI._MetaButton.SignalRelease += HandleUI_MetaButtonSignalRelease;
		UI._TestButton.SignalRelease += HandleUI_TestButtonSignalRelease;
		
		
		AddChild (_UI);
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


	
	void HandleUpdate() {
		UI.UpdateEnemyInfobox(MyEnemy);
		UI.UpdatePlayer (MyPlayer);
		UI.UpdateEnemyHealth (MyEnemy);
		Framecount++;
		
		if(!boolEnemyTurn) {
		EnemyTurn(MyEnemy);
		}
		
	}
	
	void EnemyTurn(Mobs Enemy) {
		//Get how many moves he can use
		int Max = Enemy.moveList.Count;
		//Get what move he should do out of the list
		int MoveToUse = Random.Range (0,Max)
		//actually use the move.
		
	}

	void HandleUI_TestButtonSignalRelease (FButton button)	{
		if(boolYourTurn) {
			MovesManager.Wobble (MyPlayer,MyEnemy);
			if(!UI._SubMenu.isVisible) {
			UI._SubMenu.isVisible=true;
			} else {
			UI._SubMenu.isVisible=false;
			}	
			
		}
	}

	void HandleUI_AttackButtonSignalRelease (FButton Attack) {
		if(boolYourTurn) {
			if(UI._SubMenu.isVisible) {
			UI._SubMenu.isVisible=false;
			} else {
			MovesManager.Attack (MyPlayer,MyEnemy);
			}
		}
	}
	
		void HandleUI_MetaButtonSignalRelease (FButton Meta)	{
		if(boolYourTurn) {
			if(!UI._SubMenu.isVisible) {
			UI._SubMenu.isVisible=true;
			} else {
			UI._SubMenu.isVisible=false;
			}	
		}
	}
	
		override public void HandleAddedToStage()
	{
		Futile.instance.SignalUpdate += HandleUpdate;
		base.HandleAddedToStage();
	}

	override public void HandleRemovedFromStage()
	{
		Futile.instance.SignalUpdate -= HandleUpdate;
		base.HandleRemovedFromStage();
	}
	
}


