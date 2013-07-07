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
	public static FContainer _MessageBox;
	public static FSprite _MessageBackground;
	public static FContainer _MenuBox;
	public static List<FContainer> messageList = new List<FContainer>();
	
	public const int MaxMessages = 2;
	
	
	
	
	public static FContainer DrawPlayer(Mobs Player) {
		
		//Make the background!
		_PlayerBox = new FContainer();
		_PBackground = new FSprite("UIPlayerBackground");
		
		//Make the player sprite
		_PlayerSprite = new FSprite(Player.name);
		
		//Make a holder for the player's name info
		FContainer _PlayerName = new FContainer();
		
		//Make the players name info & move it to the good spot
		_PlayerFName = new FLabel("Normal", "Johnny");
		_PlayerFName.color = Color.black;
		_PlayerFName.y = 20;
		_PlayerLName = new FLabel("Normal", "Dergen");
		_PlayerLName.color = Color.black;
		_PlayerLName.y = -20;
		
		//Add the name info to the name box
		_PlayerName.AddChild (_PlayerFName);
		_PlayerName.AddChild (_PlayerLName);
		
		//Make a holder for the players health info
		_PlayerInfo = new FContainer();
		//Make the players health info & move it to the good spot
		_PlayerHP = new FLabel("Normal", "HP:" + Player.CurHP + "/" + Player.MaxHP);
		_PlayerHP.y = 20;
		_PlayerHP.color = Color.red;
		
		_PlayerMP = new FLabel("Normal", "MP:" + Player.CurMP + "/" + Player.MaxMP);
		_PlayerMP.y = -20;
		_PlayerMP.color = Color.blue;
		
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
	public static FContainer DrawMenuBox(bool Draw) {
		_MenuBox = new FContainer();
		
		FSprite _MenuBackground = new FSprite("MenuBox");
		
		_AttackButton = new FButton("MenuButtonOff","MenuButtonOn");

		_AttackButton.AddLabel("Normal","Attack",Color.black);
		_AttackButton.anchorY=1;
		_AttackButton.y= 178;
		
		_MetaButton = new FButton("MenuButtonOff","MenuButtonOn");

		_MetaButton.AddLabel("Normal","MetaMagic",Color.black);
		_MetaButton.anchorY=1;
		_MetaButton.y= 178 - 48;
		
		
		//Manipulate elements
		_MenuBox.x = -350;
		
		//add elements to _MenuBox
		_MenuBox.AddChild (_MenuBackground);
		_MenuBox.AddChild (_AttackButton);
		_MenuBox.AddChild (_MetaButton);
		
		_MenuBox.isVisible = Draw;
		
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
		
		_ECurHP.color = Color.black;		
		_ECurMP.color = Color.black;		
		_EMaxHP.color = Color.black;		
		_EMaxMP.color = Color.black;		
		_EDam.color = Color.black;		
		_EDef.color = Color.black;
		
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
		_MessageBox = new FContainer();
		
		_MessageBackground = new FSprite("MessageBox");
		
		_MessageBox.AddChild (_MessageBackground);
		
		_MessageBox.y = 300;
		
		return _MessageBox;
	}
	
	public static FContainer _SubMenu;
	
	
	public static FButton _SubButton1;
	public static FContainer SubMenuBox() {
		
		_SubMenu = new FContainer();
		
		FSprite _SubBackground = new FSprite("MenuBox");
		
		_SubButton1 = new FButton("MenuButtonOff","MenuButtonOn");
		_SubButton1.AddLabel ("Normal","Wobble",Color.black);
		_SubButton1.anchorY = 1;
		_SubButton1.y= 178;
		
		
		_SubMenu.AddChild (_SubBackground);
		_SubMenu.AddChild (_SubButton1);
		
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

	public static void UpdatePlayer (Mobs Player) {
		_PlayerHP.color = Color.red;
		_PlayerMP.color = Color.blue;
		_PlayerHP.text = "HP:" + Player.CurHP + "/" + Player.MaxHP;
		_PlayerMP.text = "MP:" + Player.CurMP + "/" + Player.MaxMP;
		
		if (Player.CurHP == 0) {
		_PlayerSprite.SetElementByName("Dead");	
		}
	}

	public static void UpdateEnemyHealth (Mobs Enemy)	{
		_EHealthFill.scaleX = ((float) Enemy.CurHP / (float) Enemy.MaxHP);
	}
	
	
	public static void AddMessage (string Title, string Text) {
			
		FContainer _MessageToAdd = new FContainer();
		FSprite _LabelBackground = new FSprite("Message");
		FLabel _MessageTitle = new FLabel("Normal",Title);
		FLabel _MessageText = new FLabel("MessageText",Text);
		
		
		foreach(FContainer message in messageList) {
			
			message.x+=277;
			
		}
		
		
		if (messageList.Count > MaxMessages) {
				FContainer removeMessage = messageList[0];

				_MessageBox.RemoveChild (removeMessage);
				
				messageList.RemoveAt (0);
				
			}
		
		messageList.Add (_MessageToAdd);
		
		_MessageTitle.color = Color.black;
		_MessageText.color = Color.black;
		
		_MessageTitle.anchorX=0;
		_MessageText.anchorX=0;
		
		_MessageTitle.x = -130;
		_MessageText.x = -130;
		
		_MessageTitle.y = 40;
		_MessageText.y = 0;
		
		
		_MessageToAdd.AddChild(_LabelBackground);
		_MessageToAdd.AddChild(_MessageTitle);
		_MessageToAdd.AddChild(_MessageText);
		
		_MessageToAdd.x=-270;
		
		_MessageBox.AddChild (_MessageToAdd);
		
	}
}
