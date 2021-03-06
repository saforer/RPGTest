using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public enum MenuOptions {
	Attack,
	Skills,
	MetaMagic,
	Items,
	Run
}


public enum BattlePhase {
	PlayerPhase,
	EnemyPhase
}

public static class UI {
	
	//what phase is it state machine
	public static BattlePhase _CurrentPhase = BattlePhase.PlayerPhase;
	
	//player stuffs
	public static FSprite _PBackground;
	public static FContainer _PlayerBox;
	public static FSprite _PlayerSprite;
	public static FContainer _PlayerName;
	public static FLabel _PlayerFName;
	public static FLabel _PlayerLName;
	public static FContainer _PlayerInfo;
	public static FLabel _PlayerHP;
	public static FLabel _PlayerMP;
	
	//enemy stuffs
	public static FLabel _ECurHP;
	public static FLabel _EMaxHP;
	public static FLabel _ECurMP;
	public static FLabel _EMaxMP;
	public static FLabel _EDef;
	public static FLabel _EDam;
	public static FContainer _EHealthBar;
	public static FSprite _EHealthBack;
	public static FSprite _EHealthFill;
	
	//message stuff
	public static FContainer _MessageBox;
	public static FSprite _MessageBackground;
	public static List<FContainer> messageList = new List<FContainer>();
	public const int MaxMessages = 2;
	
	
	//menu box stuff
	public static FContainer _MenuBox;
	private static int _MenuSelection;	
	
	static bool Menulock;
		
	
	//sub menu stuff
	public static FContainer _SubMenu;
	public static FSprite _SubBackground;
	static int _SubSelection = 0;
	public static FContainer _SubOption;
	public static FSprite _OptionBack;
	public static FLabel _OptionText;
	public static MenuOptions MenuOpen;

	
	//Attack box
	public static FContainer _AttackContainer;
	public static FSprite _AttackBackground;
	public static FLabel _AttackText;
	
	//skill box
	public static FContainer _SkillContainer;
	public static FSprite _SkillBackground;
	public static FLabel _SkillText;
	public static string MoveName;
	public static List<FSprite> skillSpriteList;
	
	//metamagic box
	public static FContainer _MetaContainer;
	public static FSprite _MetaBackground;
	public static FLabel _MetaText;
	public static int metaMax;
	public static string MetaName;
	public static List<FSprite> metaSpriteList;
	
	
	//item box
	public static FContainer _ItemContainer;
	public static FSprite _ItemBackground;
	public static FLabel _ItemText;
	public static List<FSprite> itemSpriteList;
	public static ValidItems ItemName;
	
	
	//run box
	public static FContainer _RunContainer;
	public static FSprite _RunBackground;
	public static FLabel _RunText;

	
	
	
	
	
	
	
	

	
	
	
	
	public static FContainer DrawPlayer(Player Player) {
		
		//Make the background!
		_PlayerBox = new FContainer();
		_PBackground = new FSprite("UIPlayerBackground");
		
		//Make the player sprite
		_PlayerSprite = new FSprite(Player.name);
		
		//Make a holder for the player's name info
		FContainer _PlayerName = new FContainer();
		
		//Make the players name info & move it to the good spot
		_PlayerFName = new FLabel("Normal", Player.FName);
		_PlayerFName.color = Color.black;
		_PlayerFName.y = 20;
		_PlayerLName = new FLabel("Normal", Player.LName);
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
	
	
	public static FContainer DrawMenuBox() {
		_MenuBox = new FContainer();
		
		_AttackContainer = new FContainer();
		_SkillContainer = new FContainer();
		_MetaContainer = new FContainer();
		_ItemContainer = new FContainer();
		_RunContainer = new FContainer();
		
		FSprite _MenuBackground = new FSprite("MenuBox");
		
		_AttackBackground = new FSprite("MenuButtonOff");
		_AttackText = new FLabel("Normal","Attack");
		_AttackText.color = Color.black;
		
		_SkillBackground = new FSprite("MenuButtonOff");
		_SkillText = new FLabel("Normal","Skills");
		_SkillText.color = Color.black;
		
		_MetaBackground = new FSprite("MenuButtonOff");
		_MetaText = new FLabel("Normal","MetaMagic");
		_MetaText.color = Color.black;
		
		_ItemBackground = new FSprite("MenuButtonOff");
		_ItemText = new FLabel("Normal","Item");
		_ItemText.color = Color.black;
		
		_RunBackground = new FSprite("MenuButtonOff");
		_RunText = new FLabel("Normal","Run");
		_RunText.color = Color.black;
		
		_AttackContainer.AddChild (_AttackBackground);
		_AttackContainer.AddChild (_AttackText);
		
		
		_SkillContainer.AddChild (_SkillBackground);
		_SkillContainer.AddChild (_SkillText);
		
		_MetaContainer.AddChild (_MetaBackground);
		_MetaContainer.AddChild (_MetaText);
		
		_ItemContainer.AddChild (_ItemBackground);
		_ItemContainer.AddChild (_ItemText);
		
		_RunContainer.AddChild (_RunBackground);
		_RunContainer.AddChild (_RunText);
		
		
		//Manipulate elements
		_MenuBox.x = -350;
		
		const int MenuConst = 49;
		
		_AttackContainer.y = MenuConst*3+6;
		_SkillContainer.y = MenuConst*2+6;
		_MetaContainer.y = MenuConst*1+6;
		_ItemContainer.y = +6;
		_RunContainer.y = -(MenuConst*1)+6;
		
		
		//add elements to _MenuBox
		_MenuBox.AddChild (_MenuBackground);
		_MenuBox.AddChild (_AttackContainer);
		_MenuBox.AddChild (_SkillContainer);
		_MenuBox.AddChild (_MetaContainer);
		_MenuBox.AddChild (_ItemContainer);
		_MenuBox.AddChild (_RunContainer);
		
		
		return _MenuBox;
	}
	
	public static FContainer SubMenuBox() {
		
		_SubMenu = new FContainer();
		


		_SubMenu.x=-73;
		_SubMenu.isVisible = false;
		
		return _SubMenu;
	}
	

	public static void SelectedMenuUp (Player caster) {
		
		if (!Menulock) {
			_MenuSelection--;
			ChangeMenuOption();
		}
		if (Menulock) {
			_SubSelection--;
			ChangeSubOption(MenuOpen, caster);
		}
	}
	
	public static void SelectedMenuDown (Player caster) {
		if (!Menulock) {
			_MenuSelection++;
			ChangeMenuOption();
		}
		if (Menulock) {
			_SubSelection++;
			ChangeSubOption(MenuOpen, caster);
		}
	}

	public static void ChangeMenuOption () {
		if (_MenuSelection>4) _MenuSelection = 4;
		if (_MenuSelection<0) _MenuSelection = 0;
		switch (_MenuSelection){
		case 0:
			SelectedMenuOption (MenuOptions.Attack);
			break;
		case 1:
			SelectedMenuOption (MenuOptions.Skills);
			break;
		case 2:
			SelectedMenuOption (MenuOptions.MetaMagic);
			break;
		case 3:
			SelectedMenuOption (MenuOptions.Items);
			break;
		case 4:
			SelectedMenuOption (MenuOptions.Run);
			break;
			
		}
	}
	
	
	public static void SelectedMenuOption (MenuOptions Selected) {
		//set all fsprite back to normal
		_AttackBackground.SetElementByName ("MenuButtonOff");
		_SkillBackground.SetElementByName ("MenuButtonOff");
		_MetaBackground.SetElementByName ("MenuButtonOff");
		_ItemBackground.SetElementByName ("MenuButtonOff");
		_RunBackground.SetElementByName ("MenuButtonOff");
		//change selected menuoption to fancy
		switch (Selected) {
		
		case MenuOptions.Attack:
			_AttackBackground.SetElementByName ("MenuButtonOn");
			break;
		case MenuOptions.Skills:
			_SkillBackground.SetElementByName ("MenuButtonOn");
			break;
		case MenuOptions.MetaMagic:
			_MetaBackground.SetElementByName ("MenuButtonOn");
			break;
		case MenuOptions.Items:
			_ItemBackground.SetElementByName ("MenuButtonOn");
			break;
		case MenuOptions.Run:
			_RunBackground.SetElementByName ("MenuButtonOn");
			break;
			
		}
	}
	
	public static bool DoSelectedOption (Player caster, Mobs target) {
		bool Acted = false;
		if (_CurrentPhase==BattlePhase.PlayerPhase) {
			if (Menulock==false) {
				switch (_MenuSelection) {
					case 0:
						MovesManager.PerformMove (caster, target,Moves.Attack);
						Acted = true;
						break;
					case 1:
						if (caster.moveList.Count>0) OpenSkillsMenu(MenuOptions.Skills, caster);
						break;
					case 2:
						if (caster.metaList.Count>0) OpenMetaMenu(MenuOptions.MetaMagic, caster);
						break;
					case 3:
						if (caster.itemList.Count>0) OpenItemMenu(MenuOptions.Items, caster);
						break;
					case 4:
						AddMessage ("Run","You are unable to run from this fight");
						Acted = true;
						break;
					}
			} else {
				switch (MenuOpen) {
					case MenuOptions.Items:	
						DoUseItem(caster, target);
						break;
					case MenuOptions.MetaMagic:
						DoUseMeta(caster, target);
						break;
					case MenuOptions.Skills:
						DoUseSkill(caster, target);
						break;
						
				}
				Acted = true;
			}	
		}
		return Acted;
		
	}
	
	public static void DoUseSkill (Player caster, Mobs target) {
		MovesManager.PerformMove(caster,target,caster.moveList[_SubSelection]);
		CloseSubMenu();
	}
	
	public static void DoUseMeta (Player caster, Mobs target) {
		MovesManager.PerformMove(caster,target,caster.metaList[_SubSelection]);
		CloseSubMenu();
	}
	
	public static void DoUseItem (Player caster, Mobs target) {
		ItemName = caster.itemList[_SubSelection];
		Item.UseItem (caster,caster,ItemName);
		AddMessage(ItemName.ToString(),"You used " + ItemName.ToString());
		caster.itemList.RemoveAt (_SubSelection);
		CloseSubMenu();
	}
	

	public static void OpenSkillsMenu (MenuOptions Open, Player caster) {
		Menulock = true;
		_SkillBackground.SetElementByName("MenuButtonLock");
		_SubBackground = new FSprite("MenuBox");
		_SubMenu.AddChild(_SubBackground);
		_SubMenu.isVisible = true;
		int moveMax = 7;
		if (caster.moveList.Count<7) moveMax = caster.moveList.Count;
		skillSpriteList = new List<FSprite>();
		
		for (int n = 0; n<moveMax; n++) {
			 _SubOption = new FContainer();
			_OptionBack = new FSprite("MenuButtonOff");
			MoveName = caster.moveList[n].ToString ();
			if (MoveName.Equals (null)) MoveName = " ";
			_OptionText = new FLabel("Normal",MoveName);
			_SubOption.y=153+((-n)*49);
			_SubOption.AddChild (_OptionBack);
			_SubOption.AddChild (_OptionText);
			_SubMenu.AddChild(_SubOption);
			
			skillSpriteList.Add (_OptionBack);
		}	
		_SubSelection = 0;
		MenuOpen = MenuOptions.Skills;
		
		ChangeSubOption(MenuOpen, caster);
		
	}
	
	

	
	
	public static void OpenMetaMenu (MenuOptions Open, Player caster) {
		Menulock = true;
		_MetaBackground.SetElementByName("MenuButtonLock");
		_SubBackground = new FSprite("MenuBox");
		_SubMenu.AddChild(_SubBackground);
		_SubMenu.isVisible = true;
		int metaMax = 7;
		if (caster.metaList.Count<7) metaMax = caster.metaList.Count;
		metaSpriteList = new List<FSprite>();
		
		for (int n = 0; n<metaMax; n++) {
			 _SubOption = new FContainer();
			_OptionBack = new FSprite("MenuButtonOff");
			MetaName = caster.metaList[n].ToString ();
			if (MetaName.Equals (null)) MetaName = " ";
			_OptionText = new FLabel("Normal",MetaName);
			_SubOption.y=153+((-n)*49);
			_SubOption.AddChild (_OptionBack);
			_SubOption.AddChild (_OptionText);
			_SubMenu.AddChild(_SubOption);
			
			metaSpriteList.Add (_OptionBack);
		}	
		_SubSelection = 0;
		MenuOpen = MenuOptions.MetaMagic;
		
		ChangeSubOption(MenuOpen, caster);
		
	}
	
	
	
	
	public static void OpenItemMenu (MenuOptions Open, Player caster) {
		
		Menulock = true;
		_ItemBackground.SetElementByName("MenuButtonLock");
		_SubBackground = new FSprite("MenuBox");
		_SubMenu.AddChild(_SubBackground);
		_SubMenu.isVisible = true;
		int itemMax = 7;
		if (caster.itemList.Count<7) itemMax = caster.itemList.Count;
		itemSpriteList = new List<FSprite>();
		
		if (caster.itemList.Count>0) {
			for (int n = 0; n<itemMax; n++) {
				 _SubOption = new FContainer();
				_OptionBack = new FSprite("MenuButtonOff");
				ItemName = caster.itemList[n];
				_OptionText = new FLabel("Normal",ItemName.ToString ());
				_SubOption.y=153+((-n)*49);
				_SubOption.AddChild (_OptionBack);
				_SubOption.AddChild (_OptionText);
				_SubMenu.AddChild(_SubOption);
				
				itemSpriteList.Add (_OptionBack);
			}	
		}
		_SubSelection = 0;
		MenuOpen = MenuOptions.Items;
		
		ChangeSubOption(MenuOpen, caster);
		
	}
	
	
	

	public static void ChangeSubOption(MenuOptions Open, Player caster) {
	
		switch (Open) {
		case MenuOptions.Items:


			if (_SubSelection>=caster.itemList.Count) _SubSelection = caster.itemList.Count-1; //This is makes sure you can't select options lower than the option
			
			if (_SubSelection<0) _SubSelection = 0; //This makes sure subselection cant' go below 0
			
			foreach (FSprite name in itemSpriteList) {
				name.SetElementByName ("MenuButtonOff"); //This turns every other element's background off
			}
			
			itemSpriteList[_SubSelection].SetElementByName ("MenuButtonOn");			 //This turns the background of the selected element on
			
			break;
		case MenuOptions.MetaMagic:
			
			if (_SubSelection>=caster.metaList.Count) _SubSelection = caster.metaList.Count-1;
			if (_SubSelection<0) _SubSelection = 0;
			
			foreach (FSprite name in metaSpriteList) {
				name.SetElementByName ("MenuButtonOff");	
			}
			metaSpriteList[_SubSelection].SetElementByName ("MenuButtonOn");
			break;
		case MenuOptions.Skills:
			
			if (_SubSelection>=caster.moveList.Count) _SubSelection = caster.moveList.Count-1;
			if (_SubSelection<0) _SubSelection = 0;
			
			foreach (FSprite name in skillSpriteList) {
				name.SetElementByName ("MenuButtonOff");	
			}
			
			skillSpriteList[_SubSelection].SetElementByName ("MenuButtonOn");
			
			
			break;
		}
		
	}
	
	public static void CloseSubMenu() {
		//Close the submenu
		_SubMenu.isVisible = false;
		//unlock the menu
		Menulock = false;
		//Make the old element not blue
		ChangeMenuOption();
		//Remove the propogated items from the submenu
		_SubMenu.RemoveAllChildren();			
		
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
	
	public static void UpdateMenu (Player MyPlayer) {
		if (MyPlayer.moveList.Count==0) {
		_SkillText.text = "No Skills";
		}
		if (MyPlayer.metaList.Count==0) {
		_MetaText.text = "No MetaMagic";
		}
		if (MyPlayer.itemList.Count==0) {
		_ItemText.text = "No Items";
		}
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
	
	public static void PhaseShift() {
		if (_CurrentPhase == BattlePhase.PlayerPhase) {
			_MenuBox.isVisible = false;
			_SubMenu.isVisible = false;
			
			_CurrentPhase = BattlePhase.EnemyPhase;
		} 
		else if (_CurrentPhase == BattlePhase.EnemyPhase) {
			_MenuBox.isVisible = true;
			_SubMenu.isVisible = true;
			
			_CurrentPhase = BattlePhase.PlayerPhase;
		}
	}

}