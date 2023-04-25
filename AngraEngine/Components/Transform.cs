using SFML.System;

namespace AngraEngine
{
    public class Transform : Component
    {
        public Vector2f Position { get; set; }
        public Vector2f Scale { get; set; } = new Vector2f(1.0f, 1.0f);
        public float Rotation { get; set; }

        public override void Awake()
        {
            Position = new Vector2f(0, 0);
            Scale = new Vector2f(1.0f, 1.0f);
            Rotation = 0.0f;
        }

        public override void Start()
        {
        }

        public override void Update(float deltaTime)
        {
            // Perform any transform-related updates here
        }

        public void Translate(Vector2f translation) => Position += translation;
    }
}
