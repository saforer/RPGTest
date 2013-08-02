using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class RPGBattlePage : RPGPage {
	
	FSprite _BattleBackground;
	public Player MyPlayer;	
	public Mobs MyEnemy;
	public FContainer _UI;
	public static int Framecount;
	bool Paused = false;
	bool Acted = false;
	
	
	
	public RPGBattlePage (int EnemyToUse) {
		//Draw Background
		DrawBackground();
		
		//construct player
		ConstructPlayer();
		//construct enemy
		ConstructEnemy(EnemyToUse);
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
	
		
	public void ConstructPlayer () {
		MyPlayer = new Player();
	}

	public void ConstructEnemy (int EnemyToUse) 	{	
		Debug.Log (EnemyToUse);
		switch (EnemyToUse-1) {
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
		UI.UpdateMenu (MyPlayer);
		Framecount++;
		
		Controls();
		
		if(Acted){
		EnemyTurn(MyEnemy);
		UI.PhaseShift();	
		}
		
		if (MyPlayer.CurHP==0&&!Paused) {YouDed();};
		if (MyEnemy.CurHP==0&&!Paused) {YouWin (_EnemySprite, MyEnemy);};
		
	}
	
	void EnemyTurn(Mobs Enemy) {
		
	
		
		//Get what move he should do out of the list
		int MoveToUse = FindMoveToUse(MyEnemy,MyPlayer);
		//actually use the move.
			MovesManager.PerformMove (MyEnemy,MyPlayer,Enemy.moveList[MoveToUse]);
		UI.PhaseShift();
		Acted = false;
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
			if (!Acted&&!Paused) {
			Acted = UI.DoSelectedOption(MyPlayer, MyEnemy);
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


