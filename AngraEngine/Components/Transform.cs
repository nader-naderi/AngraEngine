using SFML.System;

namespace AngraEngine
{
    public class Transform : Component
    {
        public Transform Parent { get; private set; }
        public Vector2f Position { get; set; }
        public Vector2f Scale { get; set; } = new Vector2f(1.0f, 1.0f);
        public float Rotation { get; set; }
        private readonly List<Transform> Children = new List<Transform>();

        public Transform()
        {
            
        }

        public Transform(Vector2f position, float rotation)
        {
            Position = position;
            Rotation = rotation;
        }

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

        public void SetParent(Transform parent)
        {
            // Remove this transform from its current parent's children
            Parent?.Children.Remove(this);

            Parent = parent;

            // Add this transform to the new parent's children
            Parent?.Children.Add(this);
        }

        // A list to hold this transform's children
    }
}
