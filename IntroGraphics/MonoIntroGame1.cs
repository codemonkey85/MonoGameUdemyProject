using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace IntroGraphics;

public class MonoIntroGame1 : Game
{
    private GraphicsDeviceManager graphics;
    private SpriteBatch spriteBatch;

    private Texture2D daffySpriteTexture;
    private Texture2D cartoonSpriteTexture;

    public MonoIntroGame1()
    {
        graphics = new(this);
        Content.RootDirectory = "Content";
        IsMouseVisible = true;
    }

    protected override void Initialize()
    {
        // TODO: Add your initialization logic here

        base.Initialize();
    }

    protected override void LoadContent()
    {
        spriteBatch = new(GraphicsDevice);

        // TODO: use this.Content to load your game content here
        daffySpriteTexture = Content.Load<Texture2D>("images/daffy");
        cartoonSpriteTexture = Content.Load<Texture2D>("images/cartoon");
    }

    protected override void Update(GameTime gameTime)
    {
        if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed ||
            Keyboard.GetState().IsKeyDown(Keys.Escape))
        {
            Exit();
        }

        // TODO: Add your update logic here

        base.Update(gameTime);
    }

    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(Color.CornflowerBlue);

        // TODO: Add your drawing code here
        spriteBatch.Begin();
        
        spriteBatch.Draw(daffySpriteTexture, new Vector2(0, 0), Color.White);
        spriteBatch.Draw(cartoonSpriteTexture, new Vector2(400, 200), Color.White);
        
        spriteBatch.End();

        base.Draw(gameTime);
    }
}
