using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace IntroGraphics;

public class MonoIntroGame1 : Game
{
    private GraphicsDeviceManager graphics;
    private SpriteBatch spriteBatch;

    private Texture2D daffySpriteTexture;

    private Vector2 daffyPosition = new(0, 0);

    // add a velocity variable
    private Vector2 daffyVelocity = new(5, 1);

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

        daffySpriteTexture = Content.Load<Texture2D>("images/daffy");
        scoreFont = Content.Load<SpriteFont>("fonts/score");
    }

    protected override void Update(GameTime gameTime)
    {
        if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed ||
            Keyboard.GetState().IsKeyDown(Keys.Escape))
        {
            Exit();
        }

        daffyPosition += daffyVelocity;
        if (daffyPosition.X + daffySpriteTexture.Width > graphics.GraphicsDevice.Viewport.Width || daffyPosition.X < 0)
        {
            scoreCount++;
            daffyVelocity.X *= -1;
        }

        if (daffyPosition.Y + daffySpriteTexture.Height > graphics.GraphicsDevice.Viewport.Height ||
            daffyPosition.Y < 0)
        {
            scoreCount++;
            daffyVelocity.Y *= -1;
        }

        base.Update(gameTime);
    }

    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(Color.CornflowerBlue);

        spriteBatch.Begin();

        spriteBatch.Draw(daffySpriteTexture, daffyPosition, Color.White);
        spriteBatch.DrawString(scoreFont, $"Score: {scoreCount}", new(400, 200), Color.White);

        spriteBatch.End();

        base.Draw(gameTime);
    }
}
