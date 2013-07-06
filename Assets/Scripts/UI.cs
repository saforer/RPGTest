using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public static class UI {
	

	
	public static FSprite _PBackground;
	
	
	public static FContainer DrawPlayer(Mobs Player) {
		FContainer _Playerbox;
		FContainer _Playerbox = new FContainer();
		_PBackground = new FSprite("UIPlayerBackground");
		
		
		_Playerbox.AddChild (_PBackground);
		
		return _Playerbox;
	}
	
	public static void DrawMenuBox() {
		
	}
	
	public static void DrawInfoBox(Mobs Enemy) {
		
	}
	
	public static void DrawMessageBox() {
		
	}
}
