using System.Collections.Generic;
using System.Diagnostics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace AdventureQwest;

public class NewGameMenuScene : MenuScene
{
    public NewGameMenuScene(ContentManager contentManager, GraphicsDeviceManager graphics, SceneManager sceneManager, KeyboardState keyboardState) : base(contentManager, graphics, sceneManager)
    {
        titlePosition = new Vector2(graphics.PreferredBackBufferWidth/3 - 25,graphics.PreferredBackBufferHeight/4);
        optionsPosition = new Vector2(graphics.PreferredBackBufferWidth/3,graphics.PreferredBackBufferHeight/3);
        optionColor = Color.White;

        prevKBState = keyboardState;
        Debug.WriteLineIf(prevKBState.IsKeyDown(Keys.Enter),"NewGame kbstate initialized as 'Enter Down'");
        Debug.WriteLineIf(!prevKBState.IsKeyDown(Keys.Enter),"NewGame kbstate initialized as 'Enter Up'");
    }

    public override void Load()
    {
        backroundTexture = contentManager.Load<Texture2D>("Menus/subMainMenu");
        titleFont = contentManager.Load<SpriteFont>("Fonts/goblinAppears24");
        optionFont = contentManager.Load<SpriteFont>("Fonts/goblinAppears12");
        title = new SpriteString(titleFont,"New Game",titlePosition,Color.White);

        LoadOptions();
        LoadCursor();
    }

    public override void LoadOptions()
    {
        optionList = new List<string>{
            "- Small  (11x11)",
            "- Medium (21x21)",
            "- Large  (31x31)"
        };

        base.LoadOptions();

        //Custom displace y pos of each option for the menu (update for better positioning)
        int count = 0;
        foreach(SpriteString option in menuOptions)
        {
            option.SetYPos((int)option.position.Y + (25 * count));  
            count++;                 
        }
    }

    public override void Update(GameTime gameTime)
    {
        currentKBState = Keyboard.GetState();

        if (currentKBState.IsKeyDown(Keys.Enter) && !prevKBState.IsKeyDown(Keys.Enter))
        {
            MediaPlayer.Stop();
            switch(menuCursor.GetCurrentRowPos())
                {
                    //Small world
                    case 1:
                        Debug.WriteLine("Small World chosen");
                        break;

                    //Medium World
                    case 2:
                        Debug.WriteLine("Med World chosen");
                        break;
                    
                    //Large World
                    case 3:
                        Debug.WriteLine("Lrge World chosen");
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