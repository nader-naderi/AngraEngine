
using SFML.Graphics;
using SFML.System;

namespace AngraEngine
{
    public class SpriteRenderer : Component, Drawable
    {
        private Sprite sprite;
        private Transform? transform;
        public Sprite Sprite { get => sprite; }

        public virtual Texture Texture
        {
            get { return sprite.Texture; }
            set { sprite.Texture = value; }
        }

        public virtual Color Color
        {
            get { return sprite.Color; }
            set { sprite.Color = value; }
        }

        public virtual Vector2f Size
        {
            get { return sprite.Scale; }
            set { sprite.Scale = value; }
        }

        public virtual FloatRect GlobalBounds
        {
            get { return sprite.GetGlobalBounds(); }
        }

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
            transform = gameObject.GetComponent<Transform>();
            sprite.Position = gameObject.Position;
            sprite.Rotation = gameObject.Rotation;
            sprite.Scale = gameObject.Size;
        }

        public override void Update(float deltaTime)
        {
            // Update the position, scale, and rotation based on the Transform component
            sprite.Position = transform.Position;
            sprite.Scale = transform.Scale;
            sprite.Rotation = transform.Rotation;
        }

        public override void Draw(RenderTarget target, RenderStates states)
        {
            target.Draw(sprite, states);
        }

        public override void Start()
        {
            // Set the initial position, scale, and rotation based on the Transform component
            transform = gameObject.GetComponent<Transform>();
            sprite.Position = transform.Position;
            sprite.Scale = transform.Scale;
            sprite.Rotation = transform.Rotation;
        }


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