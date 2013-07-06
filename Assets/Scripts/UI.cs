using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public static class UI {
	

	public static FSprite _PBackground;
	public static FContainer _PlayerBox;
	public static FSprite _PlayerSprite;
	public static FContainer _PlayerName;
	public static FLabel _PlayerFName;
	public static FLabel _PlayerLName;
	public static FContainer _PlayerInfo;
	public static FLabel _PlayerHP;
	public static FLabel _PlayerMP;
	public static FLabel _ECurHP;
	public static FLabel _EMaxHP;
	public static FLabel _ECurMP;
	public static FLabel _EMaxMP;
	public static FLabel _EDef;
	public static FLabel _EDam;
	public static FContainer _EHealthBar;
	public static FSprite _EHealthBack;
	public static FSprite _EHealthFill;
	
	
	public static FContainer DrawPlayer(Mobs Player) {
		
		//Make the background!
		_PlayerBox = new FContainer();
		_PBackground = new FSprite("UIPlayerBackground");
		
		//Make the player sprite
		FSprite _PlayerSprite = new FSprite(Player.name);
		
		//Make a holder for the player's name info
		FContainer _PlayerName = new FContainer();
		//Make the players name info & move it to the good spot
		_PlayerFName = new FLabel("Normal", "Johnny");
		_PlayerFName.y = 20;
		_PlayerLName = new FLabel("Normal", "Dergen");
		_PlayerLName.y = -20;
		//Add the name info to the name box
		_PlayerName.AddChild (_PlayerFName);
		_PlayerName.AddChild (_PlayerLName);
		
		//Make a holder for the players health info
		_PlayerInfo = new FContainer();
		//Make the players health info & move it to the good spot
		_PlayerHP = new FLabel("Normal", "HP:" + Player.CurHP + "/" + Player.MaxHP);
		_PlayerHP.y = 20;
		_PlayerMP = new FLabel("Normal", "MP:" + Player.CurMP + "/" + Player.MaxMP);
		_PlayerMP.y = -20;
		//Add the health info to the health info box
		_PlayerInfo.AddChild (_PlayerHP);
		_PlayerInfo.AddChild (_PlayerMP);
		
		//Move the boxes to the correct area and manipulate
		_PlayerSprite.scale = 2;
		_PlayerSprite.x = -130;
		_PlayerName.x = -50;
		_PlayerInfo.x = 80;
		
		//Add the containers to the player UI container
		_PlayerBox.AddChild (_PBackground);
		_PlayerBox.AddChild (_PlayerSprite);
		_PlayerBox.AddChild (_PlayerName);
		_PlayerBox.AddChild (_PlayerInfo);
		_PlayerBox.y = -300;
		
		//Give the player UI container
		return _PlayerBox;
	}
	
	public static FButton _AttackButton;
	public static FButton _MetaButton;
	public static FContainer DrawMenuBox() {
		FContainer _MenuBox = new FContainer();
		
		FSprite _MenuBackground = new FSprite("MenuBox");
		
		_AttackButton = new FButton("MenuButtonOff","MenuButtonOn");

		_AttackButton.AddLabel("Normal","Attack",Color.black);
		_AttackButton.anchorY=1;
		_AttackButton.y= 178;
		
		_MetaButton = new FButton("MenuButtonOff","MenuButtonOn");

		_MetaButton.AddLabel("Normal","MetaMagic",Color.black);
		_MetaButton.anchorY=1;
		_MetaButton.y= 178 - 50;
		
		
		//Manipulate elements
		_MenuBox.x = -350;
		
		//add elements to _MenuBox
		_MenuBox.AddChild (_MenuBackground);
		_MenuBox.AddChild (_AttackButton);
		_MenuBox.AddChild (_MetaButton);
		
		return _MenuBox;
	}
	
	
	
	
	public static FContainer DrawHealthBar(Mobs Enemy) {
	
		_EHealthBar = new FContainer();
		
		_EHealthFill = new FSprite("HealthBar");
		_EHealthBack = new FSprite("Health");
		
		
		_EHealthFill.anchorX = 0;
		_EHealthFill.x = -100;
		_EHealthFill.scaleX = ((float) Enemy.CurHP / (float) Enemy.MaxHP);
		
		
		_EHealthBar.AddChild (_EHealthFill);
		_EHealthBar.AddChild (_EHealthBack);
		
		_EHealthBar.y =150;
		
		return _EHealthBar;
	}
	
	
	
	public static FContainer DrawInfoBox(Mobs Enemy) {
		FContainer _InfoBox = new FContainer();
		
		FSprite _InfoBackground = new FSprite("InfoBox");
		
		_ECurHP = new FLabel("Normal","Cur HP: " + Enemy.CurHP);
		_EMaxHP = new FLabel("Normal","Max HP: " +Enemy.MaxHP);
		_EDam = new FLabel("Normal","Dam: " + Enemy.Damage);
		_ECurMP = new FLabel("Normal","Cur MP:" + Enemy.CurMP);
		_EMaxMP = new FLabel("Normal","Max MP:" + Enemy.MaxMP);
		_EDef = new FLabel("Normal","Def: " + Enemy.Defense);
		
		
		int LeftEdge = -130;
		
		_ECurHP.x = LeftEdge;
		_EMaxHP.x = LeftEdge;
		_ECurMP.x = LeftEdge;
		_EMaxMP.x = LeftEdge;
		_EDam.x = LeftEdge;
		_EDef.x = LeftEdge;
		
		_ECurHP.y = 150;
		_EMaxHP.y = 100;
		_ECurMP.y = 50;
		_EMaxMP.y = 0;
		_EDam.y = -100;
		_EDef.y = -150;
		
		_ECurHP.anchorX=0;		
		_ECurMP.anchorX=0;		
		_EMaxHP.anchorX=0;		
		_EMaxMP.anchorX=0;		
		_EDam.anchorX=0;		
		_EDef.anchorX=0;
		
		
		_InfoBox.AddChild(_InfoBackground);
		
		_InfoBox.AddChild (_ECurHP);
		_InfoBox.AddChild (_EMaxHP);
		_InfoBox.AddChild (_ECurMP);
		_InfoBox.AddChild (_EMaxMP);
		_InfoBox.AddChild (_EDam);
		_InfoBox.AddChild (_EDef);
		
		
		_InfoBox.x = 350;
		
		return _InfoBox;
	}
	
	public static FContainer DrawMessageBox() {
		FContainer _MessageBox = new FContainer();
		
		FSprite _MessageBackground = new FSprite("MessageBox");
		
		_MessageBox.AddChild (_MessageBackground);
		
		_MessageBox.y = 300;
		
		return _MessageBox;
	}
	
	public static FContainer _SubMenu;
	
	
	public static FButton _TestButton;
	public static FContainer SubMenuBox() {
		
		_SubMenu = new FContainer();
		
		FSprite _SubBackground = new FSprite("MenuBox");
		
		_TestButton = new FButton("MenuButtonOff","MenuButtonOn");
		_TestButton.AddLabel ("Normal","Wobble",Color.black);
		_TestButton.anchorY = 1;
		_TestButton.y= 178 - 50;
		
		
		_SubMenu.AddChild (_SubBackground);
		_SubMenu.AddChild (_TestButton);
		
		_SubMenu.x=-73;
		_SubMenu.isVisible = false;
		
		return _SubMenu;
	}
	
	public static void UpdateEnemyInfobox (Mobs Enemy) {
		_ECurHP.text = "Cur HP:" + Enemy.CurHP;
		_EMaxHP.text = "Max HP: " + Enemy.MaxHP;
		_EDam.text = "Dam: " + Enemy.Damage;
		_ECurMP.text= "Cur MP:" + Enemy.CurMP;
		_EMaxMP.text = "Max MP:" + Enemy.MaxMP;
		_EDef.text = "Def: " + Enemy.Defense;
		
			
	}

	public static void UpdatePlayer (Mobs myPlayer) {
		
	}

	public static void UpdateEnemyHealth (Mobs Enemy)	{
		_EHealthFill.scaleX = ((float) Enemy.CurHP / (float) Enemy.MaxHP);
	}
}
