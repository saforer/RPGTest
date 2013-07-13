using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class RPGBattlePage : RPGPage {
	
	FSprite _BattleBackground;
	public Player MyPlayer;	
	public Mobs MyEnemy;
	public FContainer _UI;
	bool boolEnemyTurn = false;
	public static int Framecount;
	bool Paused = false;
	
	//Controls stuff
	//bool _KeyUp = false;
	//bool _KeyDown = false;
	
	
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
		_UI.AddChild (UI.DrawMenuBox());
		_UI.AddChild (UI.DrawHealthBar (MyEnemy));
		_UI.AddChild (UI.SubMenuBox());
		
	
	
		
		AddChild (_UI);
		
		UI.SelectedMenuOption (MenuOptions.Attack);
	}
	
	
	
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
		
		Controls();
		
		//TODO: Just call enemyturn from the move framework when it's set up
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
	}

	void YouWin (FSprite _EnemySprite, Mobs MyEnemy)	{
		_EnemySprite.SetElementByName ("Dead");
		UI._MenuBox.isVisible = false;
		UI._SubMenu.isVisible = false;
		UI.AddMessage ("Killed",MyEnemy.name + " has died.");
		Paused=true;
	}

	void YouDed ()	{
		UI._MenuBox.isVisible = false;
		UI._SubMenu.isVisible = false;
		UI.AddMessage ("Dead",MyPlayer.FName + " has died");
		Paused=true;
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

	void Controls ()
	{
		if (Input.GetKeyDown(KeyCode.UpArrow)) {
			UI.SelectedMenuUp(MyPlayer);
		}
		
		if (Input.GetKeyDown(KeyCode.DownArrow)) {
			UI.SelectedMenuDown(MyPlayer);
		}
		
		if (Input.GetKeyDown (KeyCode.Return)) {
			if (!boolEnemyTurn&&!Paused) {
			boolEnemyTurn = UI.DoSelectedOption(MyPlayer, MyEnemy);
			}
		}
	
		if (Input.GetKeyDown (KeyCode.LeftArrow)) {
			UI.CloseSubMenu();
		}
		
		if (Input.GetKeyDown (KeyCode.RightArrow)) {
			
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


