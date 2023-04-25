
using SFML.Graphics;
using SFML.System;

namespace AngraEngine
{
    public class SpriteRenderer : Component, Drawable
    {
        private Sprite sprite;

        public SpriteRenderer(Texture texture)
        {
            sprite = new Sprite(texture);
        }

        public SpriteRenderer(Sprite sprite)
        {
            this.sprite = sprite;
        }

        public override void Awake()
        {
            sprite.Position = gameObject.Position;
            sprite.Rotation = gameObject.Rotation;
            sprite.Scale = gameObject.Size;
        }

        public override void Update(float deltaTime)
        {
            sprite.Position = gameObject.Position;
            sprite.Rotation = gameObject.Rotation;
            sprite.Scale = gameObject.Size;
        }

        public override void Draw(RenderTarget target, RenderStates states)
        {
            target.Draw(sprite, states);
        }

        public override void Start()
        {

        }

        public Vector2f Size => new Vector2f(sprite.TextureRect.Width, sprite.TextureRect.Height);

        public FloatRect GlobalBounds => sprite.GetGlobalBounds();

        public Sprite Sprite { get => sprite; }

        public override void Load()
        {
            sprite = new Sprite(sprite);
        }

        public override void Unload()
        {
            sprite?.Dispose();
        }
    }
}