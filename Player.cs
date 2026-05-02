using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace _2dGame;

public class Player
{
    private const float MoveSpeed  = 180f;
    private const float SprintSpeed = 320f;
    private const float JumpForce  = 420f;
    private const float Gravity    = 900f;

    private const int Width  = 32;
    private const int Height = 48;

    private Texture2D _texture;

    public Vector2 Position;
    public Vector2 Velocity;
    public bool IsOnGround;

    public Rectangle Bounds => new Rectangle((int)Position.X, (int)Position.Y, Width, Height);

    public Player(GraphicsDevice graphicsDevice, Vector2 startPosition)
    {
        Position = startPosition;
        _texture = new Texture2D(graphicsDevice, 1, 1);
        _texture.SetData(new[] { Color.DodgerBlue });
    }

    public void Update(GameTime gameTime, KeyboardState kb, IReadOnlyList<Rectangle> platforms)
    {
        float dt = (float)gameTime.ElapsedGameTime.TotalSeconds;

        // Horizontal input
        float speed = kb.IsKeyDown(Keys.LeftShift) ? SprintSpeed : MoveSpeed;
        float vx = 0f;
        if (kb.IsKeyDown(Keys.Left)  || kb.IsKeyDown(Keys.A)) vx = -speed;
        if (kb.IsKeyDown(Keys.Right) || kb.IsKeyDown(Keys.D)) vx =  speed;
        Velocity.X = vx;

        // Jump
        if ((kb.IsKeyDown(Keys.Space) || kb.IsKeyDown(Keys.Up) || kb.IsKeyDown(Keys.W)) && IsOnGround)
        {
            Velocity.Y = -JumpForce;
            IsOnGround = false;
        }

        // Gravity
        Velocity.Y += Gravity * dt;

        // Move X, then resolve X collisions
        Position.X += Velocity.X * dt;
        ResolveCollisions(platforms, horizontal: true);

        // Move Y, then resolve Y collisions
        IsOnGround = false;
        Position.Y += Velocity.Y * dt;
        ResolveCollisions(platforms, horizontal: false);
    }

    private void ResolveCollisions(IReadOnlyList<Rectangle> platforms, bool horizontal)
    {
        Rectangle bounds = Bounds;

        foreach (Rectangle platform in platforms)
        {
            if (!bounds.Intersects(platform))
                continue;

            Rectangle overlap = Rectangle.Intersect(bounds, platform);

            if (horizontal)
            {
                // Push out on X axis
                if (Velocity.X > 0)
                    Position.X -= overlap.Width;
                else if (Velocity.X < 0)
                    Position.X += overlap.Width;

                Velocity.X = 0f;
            }
            else
            {
                // Push out on Y axis
                if (Velocity.Y > 0)
                {
                    // Falling down — land on top of platform
                    Position.Y -= overlap.Height;
                    IsOnGround  = true;
                }
                else
                {
                    // Moving up — hit ceiling
                    Position.Y += overlap.Height;
                }

                Velocity.Y = 0f;
            }

            // Recalculate bounds after each correction
            bounds = Bounds;
        }
    }

    public void Draw(SpriteBatch spriteBatch)
    {
        spriteBatch.Draw(_texture, Bounds, Color.DodgerBlue);
    }
}
