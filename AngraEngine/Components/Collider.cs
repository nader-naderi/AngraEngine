using SFML.Graphics;
using SFML.System;

namespace AngraEngine
{
    public class Collider : Component
    {
        public FloatRect Bounds => new FloatRect(gameObject.Position.X, gameObject.Position.Y, size.X, size.Y);

        private Vector2f size;
        private bool isTrigger;

        public Collider(Vector2f size, bool isTrigger = false)
        {
            this.size = size;
            this.isTrigger = isTrigger;
        }

        public override void Awake()
        {
        }

        public override void Start()
        {
        }

        public override void Update(float deltaTime)
        {
        }

        public bool CheckCollision(Collider other)
        {
            if (isTrigger || other.isTrigger)
            {
                return Bounds.Intersects(other.Bounds);
            }

            return false;
        }

        public void OnCollisionEnter(Collider other)
        {
        }

        public void OnCollisionStay(Collider other)
        {
        }

        public void OnCollisionExit(Collider other)
        {
        }

        public void OnTriggerEnter(Collider other)
        {
        }

        public void OnTriggerStay(Collider other)
        {
        }

        public void OnTriggerExit(Collider other)
        {
        }
    }
}

