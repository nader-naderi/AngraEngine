using SFML.Graphics;

namespace AngraEngine
{
    public class Scene : IInitializable, IUpdatable, IDisposable, Drawable, ILoadable
    {

        private List<GameObject> gameObjects = new List<GameObject>();

        private string name;

        public Scene(string name)
        {
            gameObjects.Add(new Background(ResourceManager.BackGroundTexture));

            Player player = new Player(ResourceManager.PlayerTexture);

            gameObjects.Add(player);
            gameObjects.Add(new Enemy(ResourceManager.EnemyTexture));
            //gameObjects.Add(new CameraController(player.Transform));

            for (int i = 0; i < gameObjects.Count; i++)
            {
                gameObjects[i].Awake();
                gameObjects[i].Start();
            }

            this.name = name;
        }

        public void Awake()
        {

        }

        public void Start()
        {

        }

        public void Dispose()
        {

        }

        public void Draw(RenderTarget target, RenderStates states)
        {
            for (int i = 0; i < gameObjects.Count; i++)
            {
                GameObject gameObejct = gameObjects[i];
                target.Draw(gameObejct);
            }
        }

        
        public void Update()
        {
            for (int i = 0; i < gameObjects.Count; i++)
            {
                GameObject gameObject = gameObjects[i];
                gameObject.Update();
            }
        }

        public void AddGameObejct(GameObject target)
        {
            // Editor

            gameObjects.Add(target);
        }

        public void RemoveGameObejct(GameObject target)
        {
            gameObjects.Remove(target);
        }

        public void Load()
        {
            for (int i = 0; i < gameObjects.Count; i++)
            {
                GameObject gameObject = gameObjects[i];
                gameObject.Load();
            }
        }

        public void Unload()
        {
            for (int i = 0; i < gameObjects.Count; i++)
            {
                GameObject gameObject = gameObjects[i];
                gameObject.Unload();
            }
        }
    }
}
