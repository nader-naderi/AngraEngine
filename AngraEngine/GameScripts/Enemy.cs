﻿using SFML.Graphics;
using SFML.System;

namespace AngraEngine
{
    public class Enemy : GameObejct
    {
        public Enemy(Texture texture) : base(texture)
        {
            Tag = "Enemy";

            Rigidbody rigidbody = new Rigidbody();
            AddComponent(rigidbody, new AudioPlayer(), new SpriteRenderer());

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
