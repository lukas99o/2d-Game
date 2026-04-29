using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace _2dGame;

public class Level
{
    private static readonly List<Rectangle> _platforms = new()
    {
        // Ground
        new Rectangle(0,    500, 1280, 80),
        // Platforms
        new Rectangle(150,  390,  200, 16),
        new Rectangle(450,  310,  200, 16),
        new Rectangle(720,  390,  200, 16),
        new Rectangle(950,  280,  200, 16),
    };

    public IReadOnlyList<Rectangle> Platforms => _platforms;

    private Texture2D _texture;

    public Level(GraphicsDevice graphicsDevice)
    {
        _texture = new Texture2D(graphicsDevice, 1, 1);
        _texture.SetData(new[] { Color.White });
    }

    public void Draw(SpriteBatch spriteBatch)
    {
        foreach (Rectangle platform in _platforms)
            spriteBatch.Draw(_texture, platform, Color.SaddleBrown);
    }
}
