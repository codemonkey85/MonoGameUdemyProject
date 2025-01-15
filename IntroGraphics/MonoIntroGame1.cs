using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace IntroGraphics;

public class MonoIntroGame1 : Game
{
    private GraphicsDeviceManager graphics;
    private SpriteBatch spriteBatch;

    private Texture2D player1SpriteTexture;

    private Vector2 player1Position = new(0, 0);

    // add a velocity variable
    private Vector2 player1Velocity = new(5, 1);

    private SpriteFont scoreFont;
    private int scoreCount;

    public MonoIntroGame1()
    {
        graphics = new(this);
        Content.RootDirectory = "Content";
        IsMouseVisible = true;
        Window.Position = new(400, 200);
    }

    protected override void LoadContent()
    {
        spriteBatch = new(GraphicsDevice);

        player1SpriteTexture = Content.Load<Texture2D>("sprites/player1");
        scoreFont = Content.Load<SpriteFont>("fonts/score");
    }

    protected override void Update(GameTime gameTime)
    {
        if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed ||
            Keyboard.GetState().IsKeyDown(Keys.Escape))
        {
            Exit();
        }

        player1Position += player1Velocity;
        if (player1Position.X + player1SpriteTexture.Width > graphics.GraphicsDevice.Viewport.Width ||
            player1Position.X < 0)
        {
            scoreCount++;
            player1Velocity.X *= -1;
        }

        if (player1Position.Y + player1SpriteTexture.Height > graphics.GraphicsDevice.Viewport.Height ||
            player1Position.Y < 0)
        {
            scoreCount++;
            player1Velocity.Y *= -1;
        }

        base.Update(gameTime);
    }

    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(Color.CornflowerBlue);

        spriteBatch.Begin();

        spriteBatch.Draw(player1SpriteTexture, player1Position, Color.White);
        spriteBatch.DrawString(scoreFont, $"Score : {scoreCount}", new(5, 0), Color.White);

        spriteBatch.End();

        base.Draw(gameTime);
    }
}
