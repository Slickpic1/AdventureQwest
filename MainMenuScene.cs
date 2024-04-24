using System.Collections.Generic;
using System.Diagnostics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace AdventureQwest;

public class MainMenuScene : MenuScene
{
    //Audio
    private Song mainMenuMusic;
     public MainMenuScene(ContentManager contentManager, GraphicsDeviceManager graphics, SceneManager sceneManager) : base(contentManager, graphics, sceneManager)
    {
        //Initialize our menu sizeing and position (need to better adjust)
        titlePosition = new Vector2(graphics.PreferredBackBufferWidth/3 - 25,graphics.PreferredBackBufferHeight/5);
        optionsPosition = new Vector2(graphics.PreferredBackBufferWidth/3 + 50,graphics.PreferredBackBufferHeight/3);
        optionColor = Color.Black;
    }
     public override void Load()
    {
        //Load our content specifically for the main menu
        backroundTexture = contentManager.Load<Texture2D>("Menus/MainMenuBackground");
        titleFont = contentManager.Load<SpriteFont>("Fonts/ancientModern64");
        optionFont = contentManager.Load<SpriteFont>("Fonts/goblinAppears12");
        title = new SpriteString(titleFont,"Adventure Qwest!",titlePosition,Color.Black);
         LoadOptions();
         //Load Cursor
        LoadCursor();
         //Introduce and play main menu music upon starting game
        mainMenuMusic = contentManager.Load<Song>("Audio/Music/mainMenuMusic");
        MediaPlayer.Play(mainMenuMusic);
        
    }
     //Maybe rename, also can we move this elsewhere?
    public override void LoadOptions()
    {
        //Load our menu options
        optionList = new List<string>{
            "New Game",
            "Load Game",
            "Settings",
            "Quit"
        };
         //Loads our options into lists                
        base.LoadOptions();
         //Custom displace y pos of each option for the menu (update for better positioning)
        int count = 0;
        foreach(SpriteString option in menuOptions)
        {
            option.SetYPos((int)option.position.Y + (25 * count));  
            count++;                 
        }
    }
     //public override void LoadCursor()
    //{ 
    //    base.LoadCursor();
    //}
     public override void Update(GameTime gameTime)
    {
        currentKBState = Keyboard.GetState();
        //Check to see if keyPressed is enter (might abstract later)
        if (currentKBState.IsKeyDown(Keys.Enter) && !prevKBState.IsKeyDown(Keys.Enter))
        {
            switch(menuCursor.GetCurrentRowPos())
            {
                //New Game
                case 1:
                    sceneManager.AddScene(new NewGameMenuScene(contentManager, graphics, sceneManager, currentKBState));
                    break;
                 //Load Game
                case 2:
                    //sceneManager.AddScene(new LoadGameMenuScene(contentManager, graphics, sceneManager));
                    break;
                
                //Options
                case 3:
                    //sceneManager.AddScene(new OptionsMenuScene(conentManager, graphics, sceneManager));
                    break;
                 //Quit
                default:
                    Program.game.Exit(); //Double check this doesn't break anything
                    break;
            }
        }
        base.Update(gameTime);
    }
     public override void Draw(SpriteBatch spriteBatch)
    {
        base.Draw(spriteBatch);
    }
}