using SFML.Graphics;
using SFML.Window;

namespace AngraEngine
{
    public class Game
    {
        Font font;

        public static Game Instance { get; set; }
        public RenderWindow Window { get; private set; }

        public Game()
        {
            Window = new RenderWindow(new VideoMode(800, 600), "Our Great Game");
            ResourceManager.Window = Window;
            Window.SetVerticalSyncEnabled(true);

            ResourceManager.LoadAssets();

            TimeManager.Awake();

            font = new Font(Directory.GetCurrentDirectory() +
                "/Assets/Textures/SpaceShooterRedux/Bonus/kenvector_future.ttf");

            Scene scene = new Scene("New Scene");
            SceneManager.AddScene(scene);


        }
        public void Run()
        {
            // GameLoop
            while (Window.IsOpen)
            {
                // Handle Events
                Window.DispatchEvents();
                
                // Update.
                Update();

                PhysicsManager.Update();

                Window.Clear();

                // Draw
                Draw();

                Window.Display();
            }
        }

        private void Draw()
        {
            Window.Draw(SceneManager.CurrentScene);
        }

        private void Update()
        {
            TimeManager.Update(Window);

            if (Keyboard.IsKeyPressed(Keyboard.Key.Escape))
                Window.Close();

            SceneManager.CurrentScene.Update();
        }
    }
}
