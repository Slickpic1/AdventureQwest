using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System.Diagnostics;

namespace AdventureQwest;

public class MenuCursor : Sprite
{
    private List<Vector2> positions;
    private int maxPosition;
    private int currentRowPos;
    private int currentColPos;
    private SoundEffect cursorMoveSound;


    public MenuCursor(Texture2D texture, Vector2 position,float SCALE, List<Vector2> positions) : base(texture, position, SCALE)
    {
        this.positions = positions;
        //this.offSet = offSet;

        //Set initial cursor position to the first from list of positions
        this.position = positions[0];

        //Set max number of positions equal to length of positions list
        maxPosition = positions.Count;
        currentRowPos = 1;  //or set to zero?
        currentColPos = 1;
    }

    public void Load(ContentManager contentManager)
    {
        cursorMoveSound = contentManager.Load<SoundEffect>("Audio/SFX/blipSelect");
    }

    public override void Update(GameTime gameTime)
    {
        base.Update(gameTime);
    }

    public override void Draw(SpriteBatch spriteBatch)
    {
        base.Draw(spriteBatch);
    }

    //Rn only supports up and down
    public void Move(string direction)
    {
        switch (direction)
        {
            case "down":
                currentRowPos++;
                if (currentRowPos <= maxPosition)
                {
                    position = positions[currentRowPos-1];
                    cursorMoveSound.Play();                    
                }
                else
                {
                    currentRowPos--;
                }
                Debug.WriteLine("cursorRowPos: " + currentRowPos);
                break;

            case "up":
                currentRowPos--;

                if (currentRowPos > 0)
                {
                    position = positions[currentRowPos-1];
                    cursorMoveSound.Play(); //Little bit slow, wonder if we can speed up
                }
                else
                {
                    currentRowPos++;
                }
                Debug.WriteLine("cursorRowPos: " + currentRowPos);
                break;

            case "right":
                currentColPos++;
                //if (currentColPos <= maxPosition.X)
                //{
                //    //Move pos to the right
                //    cursorMoveSound.Play();
                //}
                //else
                //{
                //    currentColPos--;
                //}
                Debug.WriteLine("cursorColPos: " + currentColPos);
                break;

            case "left":
                currentColPos++;
                //if (currentColPos > 0)
                //{
                //    //Move pos to the left
                //    cursorMoveSound.Play();
                //}
                //else
                //{
                //    currentColPos++;
                //}
                Debug.WriteLine("cursorColPos: " + currentColPos);
                break;
        }
    }

    public int GetCurrentRowPos()
    {
        return currentRowPos;
    }

    public int GetCurrentColPos()
    {
        return currentColPos;
    }
}