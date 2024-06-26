using System.Diagnostics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace AdventureQwest;

public class SpriteString
{
    private SpriteFont font;
    public Vector2 position;
    private string drawString;
    private Color color;
    public SpriteString(SpriteFont font, string drawString, Color color)
    {
        this.font = font;
        this.drawString = drawString;
    }
    public SpriteString(SpriteFont font, string drawString, Vector2 position, Color color)
    {
        this.font = font;
        this.position = position;
        this.drawString = drawString;
        this.color = color;
    }

    //Can remove these
    public void SetXPos(int xPos)
    {
        this.position.X = xPos;
    }

    public void SetYPos(int yPos)
    {
        this.position.Y = yPos;
    }

    public void Update(GameTime gameTime)
    {
        
    }

    public void DrawString(SpriteBatch spriteBatch)
    {
        spriteBatch.DrawString(font,drawString,position,color);
    }

    public int StringLength()
    {
        return (int)font.MeasureString(drawString).X;
    }

    public int GetStringHeight()
    {
        return (int)font.MeasureString(drawString).Y;
    }
}