using SFML.Graphics;
using SFML.System;

namespace AngraEngine
{
    public class Bullet : GameObject
    {
        float bulletSpeed = 10;
        Rigidbody rb = new Rigidbody();
        SpriteRenderer sprite;

        public Bullet(Texture texture) : base()
        {
            Tag = "Bullet";
            sprite = new SpriteRenderer(texture);
            AddComponent(rb, new AudioPlayer(), sprite,
                 Collider = new Collider(Transform.Scale));
        }

        public override void Awake()
        {
            base.Awake();
        }

        public override void Start()
        {
            base.Start();
        }

        public override void Update()
        {
            base.Update();

            HandleMovement();
            HandleDeath();
        }

        private void HandleDeath()
        {
            if (Position.X < 0 || Position.X > ResourceManager.Window.Size.X ||
                            Position.Y < 0 || Position.Y > ResourceManager.Window.Size.Y)
            {
                // RemoveAt(i);
                // Remove the bullet.
                OnDestroy();
            }
        }

        private void HandleMovement()
        {
            Position -= new Vector2f(0, bulletSpeed);
        }

        public override void OnDestroy()
        {
            base.OnDestroy();
        }
    }
}
