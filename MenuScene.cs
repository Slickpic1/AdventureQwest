using System.Collections.Generic;
using System.Diagnostics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace AdventureQwest;

public class MenuScene : IScene
{
    protected ContentManager contentManager;
    protected GraphicsDeviceManager graphics;
    protected SpriteString option;
    protected SpriteString title;
    protected SpriteFont titleFont;
    protected SpriteFont optionFont;
    protected MenuCursor menuCursor;
    protected Texture2D backroundTexture;
    protected KeyboardState prevKBState;
    protected KeyboardState currentKBState;
    protected SceneManager sceneManager;
    protected List<SpriteString> menuOptions = new();
    protected List<Vector2> cursorPositions = new();
    protected List<string> optionList;
    protected Color optionColor;
    protected Vector2 titlePosition;
    protected Vector2 optionsPosition;

    public MenuScene(ContentManager contentManager, GraphicsDeviceManager graphics, SceneManager sceneManager) : base()
    {
        this.contentManager = contentManager;
        this.graphics = graphics;
        this.sceneManager = sceneManager;
    }

    public virtual void Load()
    {
        //Individual classes modify the positions after this
    }

    public virtual void LoadOptions()
    {
        //Load list options
        foreach (string option in optionList)
        {  
            menuOptions.Add(new SpriteString(optionFont,option,optionsPosition,optionColor));
        }
    }

    public virtual void LoadCursor()
    {
        //Make list of cursor positions
            foreach (SpriteString option in menuOptions)
            {
                cursorPositions.Add(
                    new Vector2(
                        option.position.X + option.StringLength() + 5, //need to better adjust
                        option.position.Y - menuOptions[1].GetStringHeight() * 1.5f));
            }

            //Load our cursor at initial position
            menuCursor = new MenuCursor(contentManager.Load<Texture2D>("Menus/selectorSword"),Vector2.Zero,cursorPositions);
            menuCursor.Load(contentManager);
    }

    public virtual void Update(GameTime gameTime)
    {   
        if (currentKBState.IsKeyDown(Keys.Down) && !prevKBState.IsKeyDown(Keys.Down))
        {   
            menuCursor.Move("down");
        }

        if (currentKBState.IsKeyDown(Keys.Up) && !prevKBState.IsKeyDown(Keys.Up))
        {   
            menuCursor.Move("up");
        }
        prevKBState = currentKBState;
    }

    public virtual void Draw(SpriteBatch spriteBatch)
    {
        //Draw our backround and our title
        spriteBatch.Draw(backroundTexture, new Rectangle(0,0,graphics.PreferredBackBufferWidth,graphics.PreferredBackBufferHeight), Color.White);
        title.DrawString(spriteBatch);
            
        //Draw our menu options
        foreach(SpriteString option in menuOptions)
        {
            //Note: this updates constantly, which might be annoying if not bad for computer
            option.DrawString(spriteBatch);                  
        }
        //Draw our selection cursor
        menuCursor.Draw(spriteBatch);
    }
}