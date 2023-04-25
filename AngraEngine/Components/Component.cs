using SFML.Graphics;

namespace AngraEngine
{
    public abstract class Component : IInitializable, ILoadable, Drawable
    {
        public GameObejct gameObject { get; set; }

        public abstract void Awake();

        public abstract void Start();

        public abstract void Update(float deltaTime);

        public virtual void OnDestroy() { }

        public virtual void Load()
        {

        }

        public virtual void Unload()
        {

        }

        public virtual void Draw(RenderTarget target, RenderStates states)
        {

        }
    }
}
