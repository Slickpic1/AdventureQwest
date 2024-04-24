using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace AdventureQwest;

public class Game1 : Game
{
    private GraphicsDeviceManager graphics;
    private SpriteBatch spriteBatch;
    private SceneManager sceneManager;
    private KeyboardState prevKBState;
    private KeyboardState currentKBState;
    private const int aspectRatioHeight = 9;
    private const int aspectRatioWidth = 16;

    public Game1()
    {
        graphics = new GraphicsDeviceManager(this);
        Content.RootDirectory = "Content";
        IsMouseVisible = true;
        sceneManager = new();
    }

    protected override void Initialize()
    {
        //Custom Aspect Ratio
        int aspectRatioScale = 80;
        graphics.PreferredBackBufferWidth = aspectRatioWidth * aspectRatioScale;
        graphics.PreferredBackBufferHeight = aspectRatioHeight * aspectRatioScale;
        graphics.ApplyChanges();

        base.Initialize();
    }

    protected override void LoadContent()
    {
        spriteBatch = new SpriteBatch(GraphicsDevice);

        // TODO: use this.Content to load your game content here
        sceneManager.AddScene(new MainMenuScene(Content, graphics, sceneManager));
    }

    protected override void Update(GameTime gameTime)
    {
        currentKBState = Keyboard.GetState();
        
        if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Delete))
            Exit();

        if (Keyboard.GetState().IsKeyDown(Keys.Escape) && sceneManager.GetSceneStackSize() == 1 && !prevKBState.IsKeyDown(Keys.Escape))
        {
            Exit();
        }
        //This might need to be fixed so players can't escape from game w/out quiting
        else if (Keyboard.GetState().IsKeyDown(Keys.Escape) && !prevKBState.IsKeyDown(Keys.Escape))
        {
            sceneManager.RemoveScene();
        }

        // TODO: Add your update logic here
        sceneManager.GetCurrentScene().Update(gameTime);
        prevKBState = currentKBState;

        base.Update(gameTime);
    }

    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(Color.CornflowerBlue);

        // TODO: Add your drawing code here
        spriteBatch.Begin(samplerState: SamplerState.PointClamp);
        sceneManager.GetCurrentScene().Draw(spriteBatch);
        spriteBatch.End();

        base.Draw(gameTime);
    }
}
