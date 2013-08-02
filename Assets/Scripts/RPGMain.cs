using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public enum RPGPageType
{
	None,
	TitlePage,
	InGamePage,
	BattlePage
}

public class RPGMain : MonoBehaviour {
	
	public static RPGMain instance;
	
	private RPGPageType _currentPageType = RPGPageType.None;
	private RPGPage _currentPage = null;
	
	private FStage _stage;
	
	// Use this for initialization
	void Start () {
		
		instance = this;
		
		
        FutileParams futileParams =  new FutileParams(true,true,false,false);

        futileParams.AddResolutionLevel(1040.0f, 1.0f, 1.0f, "");

        futileParams.origin = new Vector2(.5f, .5f);
		
		
        Futile.instance.Init(futileParams);
		
		Futile.atlasManager.LoadAtlas("Atlas/RPGAtlas");
		
		Futile.atlasManager.LoadFont("Normal","Normal_0","Atlas/Normal",0,0);
		
		Futile.atlasManager.LoadFont("MessageText","MessageText_0","Atlas/MessageText",0,0);
		
		_stage = Futile.stage;
		
		GoToPage(RPGPageType.TitlePage, 0) ;
	}
	
	// Update is called once per frame
	void Update () {
	
		
	}
	


	public void GoToPage (RPGPageType pageType, int EnemyToUse)
	{
		if(_currentPageType == pageType) return; //we're already on the same page, so don't bother doing anything

		RPGPage pageToCreate = null;

		//TODO:RPGTITLEPAGE
		if (pageType == RPGPageType.TitlePage)
		{
			pageToCreate = new RPGTitlePage();
		}
		//TODO:RPGINGAMEPAGE
		if (pageType == RPGPageType.BattlePage)
		{
			pageToCreate = new RPGBattlePage(EnemyToUse);
		}

		if(pageToCreate != null) //destroy the old page and create a new one
		{
			_currentPageType = pageType;	

			if(_currentPage != null)
			{
				_stage.RemoveChild(_currentPage);
			}

			_currentPage = pageToCreate;
			_stage.AddChild(_currentPage);
			_currentPage.Start();
		}

	}

}