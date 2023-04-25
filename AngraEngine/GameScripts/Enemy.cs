using SFML.Graphics;
using SFML.System;

namespace AngraEngine
{
    public class Enemy : GameObejct
    {
        SpriteRenderer sprite;
        public Enemy(Texture texture) : base()
        {
            Tag = "Enemy";
            sprite = new SpriteRenderer(texture);
            Rigidbody rigidbody = new Rigidbody();
            AddComponent(rigidbody, new AudioPlayer(), sprite, 
                new Collider(sprite.Size));

            PhysicsManager.AddRigidBody(rigidbody);
        }

        public override void Awake()
        {
            base.Awake();
        }

        public override void Start()
        {
            base.Start();
            Position = new Vector2f(20, 20);
        }

        public override void Update()
        {
            base.Update();
        }

        public override void OnDestroy()
        {
            base.OnDestroy();
        }
    }
}
