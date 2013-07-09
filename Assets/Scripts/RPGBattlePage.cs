using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class RPGBattlePage : RPGPage {
	
	public Player MyPlayer;	
	public Mobs MyEnemy;
	public FContainer _UI;
	bool boolYourTurn = true;
	bool boolEnemyTurn = false;
	public static int Framecount;
	bool Paused = false;
	
	
	public RPGBattlePage () {
		//Draw Background
		DrawBackground();
		
		//construct player
		ConstructPlayer();
		//construct enemy
		ConstructEnemy();
		//Draw Enemy
		DrawEnemy(MyEnemy);
		//Draw UI
		_UI = new FContainer();
		_UI.AddChild (UI.DrawPlayer (MyPlayer));
		_UI.AddChild (UI.DrawInfoBox (MyEnemy));
		_UI.AddChild (UI.DrawMessageBox());
		_UI.AddChild (UI.DrawMenuBox(true));
		_UI.AddChild (UI.DrawHealthBar (MyEnemy));
		_UI.AddChild (UI.SubMenuBox("Wobble", "Dance", "Sing", "Eat", "Fart"));
		
		UI._AttackButton.SignalRelease += HandleUI_AttackButtonSignalRelease;
		UI._MetaButton.SignalRelease += HandleUI_MetaButtonSignalRelease;
		UI._SubButton1.SignalRelease += HandleUI_SubButton1SignalRelease;
		UI._SubButton2.SignalRelease += HandleUI_SubButton2SignalRelease;
		UI._SubButton3.SignalRelease += HandleUI_SubButton3SignalRelease;
		UI._SubButton4.SignalRelease += HandleUI_SubButton4SignalRelease;
		UI._SubButton5.SignalRelease += HandleUI_SubButton5SignalRelease;
		
		
	
		
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
		
		if(boolEnemyTurn) {
		EnemyTurn(MyEnemy);
		}
		
		if(MyEnemy.CurHP <= 0&&!Paused) {
			MyEnemy.CurHP = 0;
			YouWin(_EnemySprite, MyEnemy);
			Paused = true;
		}
		
		if (MyPlayer.CurHP <= 0&&!Paused) {
			MyPlayer.CurHP = 0;
			YouDed();
			Paused = true;
		}
		
	}
	
	void EnemyTurn(Mobs Enemy) {
		
		
		
		
		//Get what move he should do out of the list
		int MoveToUse = FindMoveToUse(MyEnemy,MyPlayer);
		//actually use the move.
		Debug.Log(MoveToUse);
			MovesManager.PerformMove (MyEnemy,MyPlayer,Enemy.moveList[MoveToUse]);
		
		boolEnemyTurn = false;
		boolYourTurn = true;
	}

	void YouWin (FSprite _EnemySprite, Mobs MyEnemy)	{
		_EnemySprite.SetElementByName ("Dead");
		UI._MenuBox.isVisible = false;
		UI.AddMessage ("Killed",MyEnemy.name + " has died.");
	}

	void YouDed ()	{
		UI._MenuBox.isVisible = false;
		UI.AddMessage ("Dead",MyPlayer.FName + " has died");
	}

	public void ConstructPlayer () {
		MyPlayer = new Player();
	}

	public void ConstructEnemy ()
	{	
		int MaxEnum = Enum.GetNames(typeof(ValidMobs)).Length;
		int n = UnityEngine.Random.Range (0,MaxEnum);
		Debug.Log (n);
		switch (n) {
		case 0:
			MyEnemy = new Mobs(ValidMobs.Sniper);
			break;
		case 1:	
			MyEnemy = new Mobs(ValidMobs.Knight);
			break;
		case 2:
			MyEnemy = new Mobs(ValidMobs.Skeleton);
			break;
		}
	}
	
	void HandleUI_SubButton1SignalRelease (FButton B1)	{
		if(boolYourTurn&&!Paused) {
			MovesManager.Wobble (MyPlayer,MyEnemy);
			boolEnemyTurn=true;
			boolYourTurn=false;
			UI._SubMenu.isVisible=false;
				
			
			
		}
	}
	
		void HandleUI_SubButton2SignalRelease (FButton b2)	{
		if(boolYourTurn&&!Paused) {
			MovesManager.Wobble (MyPlayer,MyEnemy);
			boolEnemyTurn=true;
			boolYourTurn=false;
			UI._SubMenu.isVisible=false;
				
			
			
		}
	}
	
		void HandleUI_SubButton3SignalRelease (FButton b3)	{
		if(boolYourTurn&&!Paused) {
			MovesManager.Wobble (MyPlayer,MyEnemy);
			boolEnemyTurn=true;
			boolYourTurn=false;
			UI._SubMenu.isVisible=false;
				
			
			
		}
	}
	
		void HandleUI_SubButton4SignalRelease (FButton b4)	{
		if(boolYourTurn&&!Paused) {
			MovesManager.Wobble (MyPlayer,MyEnemy);
			boolEnemyTurn=true;
			boolYourTurn=false;
			UI._SubMenu.isVisible=false;
				
			
			
		}
	}
	
		void HandleUI_SubButton5SignalRelease (FButton Button5)	{
		if(boolYourTurn&&!Paused) {
			MovesManager.Wobble (MyPlayer,MyEnemy);
			boolEnemyTurn=true;
			boolYourTurn=false;
			UI._SubMenu.isVisible=false;
				
			
			
		}
	}

	void HandleUI_AttackButtonSignalRelease (FButton Attack) {
		if(boolYourTurn&&!Paused) {
			if(UI._SubMenu.isVisible) {
			UI._SubMenu.isVisible=false;
			} else {
			MovesManager.Attack (MyPlayer,MyEnemy);
			boolEnemyTurn=true;
			boolYourTurn=false;
			}
		}
	}
	
		void HandleUI_MetaButtonSignalRelease (FButton Meta)	{
		if(boolYourTurn&&!Paused) {
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
	
		
	
	int FindMoveToUse(Mobs MyEnemy, Mobs MyPlayer) {
		int MoveToUse = 0;
		
		foreach (Moves name in MyEnemy.moveList) {
			 int Weight = MyEnemy.weightList[MoveToUse];
			int Rand = UnityEngine.Random.Range (0,100);
			if (Weight>Rand) {
				break;
			}		
			
			MoveToUse++;
		}
		
		return MoveToUse;
		
	}
		
}


