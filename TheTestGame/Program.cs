using AngraEngine;

namespace TheTestGame
{
    internal class Program
    {
        static void Main(string[] args)
        {
            TheTestGame game = new TheTestGame();
        }
    }

    public class TheTestGame
    {
        public delegate void GameObjectsCreationDelegate();
        static Scene scene;

        public TheTestGame()
        {
            Scene scene = new Scene("New Scene", Create);
            SceneManager.AddScene(scene);
        }

        public static void Create(Scene scene)
        {
            scene.AddGameObejct(new Background(ResourceManager.BackGroundTexture));

            Player player = new Player(ResourceManager.PlayerTexture);

            scene.AddGameObejct(player);
            scene.AddGameObejct(new Enemy(ResourceManager.EnemyTexture));
        }
    }
}