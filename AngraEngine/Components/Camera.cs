using AngraEngine;

using SFML.Graphics;
using SFML.System;


namespace AngraEngine
{
    public class Camera : Component
    {
        public Vector2f Position { get; set; }
        public float Zoom { get; set; } = 1f;
        public View View { get; private set; }
        
        public static Camera main;

        public Camera()
        {
        }

        public void SetPosition(Vector2f position)
        {
            Position = position;
            View.Center = Position;
        }

        public override void Update(float deltaTime)
        {
            View ??= new View(Position, new Vector2f(Game.Instance.Window.Size.X, Game.Instance.Window.Size.Y));

            // Update view position
            View.Center = Position;

            // Apply zoom
            View.Size = new Vector2f(Game.Instance.Window.Size.X, Game.Instance.Window.Size.Y) / Zoom;

            // Set the view on the game window
            Game.Instance.Window.SetView(View);
        }

        public override void Awake()
        {
            if (gameObject.Tag == "Main Camera")
                main = this;

            View = new View(Position, new Vector2f(Game.Instance.Window.Size.X, Game.Instance.Window.Size.Y));
            Position = gameObject.GetComponent<Transform>().Position;
        }

        public override void Start()
        {

        }
    }
}