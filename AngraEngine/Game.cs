using SFML.Graphics;
using SFML.System;
using SFML.Window;

using System.Numerics;

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

            //Scene scene = new Scene("New Scene");
            //SceneManager.AddScene(scene);


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
            if (SceneManager.CurrentScene != null)
                Window.Draw(SceneManager.CurrentScene);
        }

        private void Update()
        {
            TimeManager.Update(Window);

            if (Keyboard.IsKeyPressed(Keyboard.Key.Escape))
                Window.Close();

            if (SceneManager.CurrentScene != null)
                SceneManager.CurrentScene.Update();
        }


    }

    //public class ObjectPool<T> where T : Component
    //{
    //    private T prefab;
    //    private int initialSize;
    //    private List<T> pool = new List<T>();

    //    public ObjectPool(T prefab, int initialSize = 10)
    //    {
    //        this.prefab = prefab;
    //        this.initialSize = initialSize;

    //        for (int i = 0; i < initialSize; i++)
    //        {
    //            CreateNewInstance();
    //        }
    //    }

    //    private T CreateNewInstance()
    //    {
    //        T newInstance = GameObject.Instantiate(prefab, new Vector2f(0, 0),
    //            0f);

    //        newInstance.gameObject.SetActive(false);
    //        pool.Add(newInstance);
    //        return newInstance;
    //    }

    //    public T GetInstance()
    //    {
    //        for (int i = 0; i < pool.Count; i++)
    //        {
    //            if (!pool[i].gameObject.activeSelf)
    //            {
    //                pool[i].gameObject.SetActive(true);
    //                return pool[i];
    //            }
    //        }

    //        T newObject = CreateNewInstance();
    //        newObject.gameObject.SetActive(true);
    //        return newObject;
    //    }

    //    public void ReleaseInstance(T instance)
    //    {
    //        instance.gameObject.SetActive(false);
    //    }
    //}

    //public class Object
    //{
    //    private static Dictionary<string, Object> prefabs = new Dictionary<string, Object>();

    //    public Transform transform { get; private set; }
    //    public Collider collider { get; private set; }
    //    public SpriteRenderer spriteRenderer { get; private set; }

    //    public static void RegisterPrefab(string name, Object prefab)
    //    {
    //        prefabs[name] = prefab;
    //    }

    //    public static Object Instantiate(string name, Vector2f position, float rotation)
    //    {
    //        if (!prefabs.ContainsKey(name))
    //        {
    //            throw new ArgumentException($"No prefab with name {name} is registered");
    //        }

    //        Object prefab = prefabs[name];

    //        Object newObj = new Object
    //        {
    //            transform = new Transform(position, rotation)
    //        };

    //        if (prefab.collider != null)
    //        {
    //            newObj.collider = (Collider)prefab.collider.Clone();
    //        }
    //        if (prefab.spriteRenderer != null)
    //        {
    //            newObj.spriteRenderer = (SpriteRenderer)prefab.spriteRenderer.Clone();
    //        }

    //        return newObj;
    //    }

    //    public static GameObject Instantiate(GameObject prefab, Vector2f position, float rotation)
    //    {
    //        GameObject obj = new GameObject(prefab.Name);
    //        obj.Transform.Position = position;
    //        obj.Transform.Rotation = rotation;
    //        obj.Transform.Scale = prefab.Transform.Scale;
    //        obj.SetActive(true); // set the game object as active by default
    //        //obj.layer = prefab.layer; // set the layer of the game object to match the layer of the prefab

    //        // clone the collider from the prefab and add it to the game object
    //        if (prefab.Collider != null)
    //        {
    //            //obj.Collider = (Collider)prefab.Collider.Clone();
    //           // obj.Collider.Attach((Component)obj);
    //        }

    //        // clone all components from the prefab and add them to the game object
    //        foreach (Component component in prefab.GetComponents())
    //        {
    //            Component componentClone = component.Clone();
    //            componentClone.gameObject = obj;
    //            obj.AddComponent(componentClone);
    //        }

    //        return obj;
    //    }
    //}


}
