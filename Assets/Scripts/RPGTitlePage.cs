using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class RPGTitlePage : RPGPage
{
	private FSprite TitleBackground;
	private FSprite TitleLogo;
	private FButton BattleStartButton;
	
	public int EnemyNum =1;
	private FContainer EnemyContainer;
	private FLabel EnemySelector;
	private FButton EnemyButtonRight;
	private FButton EnemyButtonLeft;
	private FButton EnemyButtonPlay;
	
	public RPGTitlePage ()
	{
		TitleBackground = new FSprite("TitleBackground");
		TitleLogo = new FSprite("TitleLogo");
		
		TitleLogo.y = 180;
		
		AddChild(TitleBackground);
		AddChild (TitleLogo);
		
		EnemyContainer = new FContainer();
		
		EnemySelector = new FLabel("Normal",EnemyNum+"");
		
		EnemyButtonLeft = new FButton("ButtonLeft","ButtonLeftDown");
		EnemyButtonRight = new FButton("ButtonLeft","ButtonLeftDown");
		EnemyButtonRight.rotation = 180;
		EnemyButtonPlay = new FButton("MenuButtonOff","MenuButtonOn");
		EnemyButtonPlay.AddLabel("Normal","Play",Color.black);
		
		EnemySelector.y = 50;
		EnemyButtonLeft.x = -25;
		EnemyButtonRight.x = 25;
		EnemyButtonPlay.y = -50;
		
		EnemyContainer.y=-200;
		
		
		EnemyContainer.AddChild(EnemyButtonLeft);
		EnemyContainer.AddChild (EnemyButtonRight);
		EnemyContainer.AddChild (EnemySelector);
		EnemyContainer.AddChild (EnemyButtonPlay);
		
		AddChild (EnemyContainer);
		
		EnemyButtonLeft.SignalRelease += HandleEnemyButtonLeftSignalRelease;
		EnemyButtonRight.SignalRelease += HandleEnemyButtonRightSignalRelease;
		EnemyButtonPlay.SignalRelease += HandleEnemyButtonPlaySignalRelease;
	}

	void HandleEnemyButtonPlaySignalRelease (FButton button)	{
		RPGMain.instance.GoToPage(RPGPageType.BattlePage, EnemyNum);
	}

	void HandleEnemyButtonLeftSignalRelease (FButton Left)	{
		EnemyDown();
	}
	
	void HandleEnemyButtonRightSignalRelease (FButton Right)	{
		EnemyUp();
	}
	
	void EnemyDown() {
		EnemyNum--;
		if (EnemyNum<1) EnemyNum=1;
		EnemySelector.text = EnemyNum.ToString();
	}
	
	void EnemyUp() {
		EnemyNum++;
		if (EnemyNum>3) EnemyNum=3;
		EnemySelector.text = EnemyNum.ToString();
	}
	
}


