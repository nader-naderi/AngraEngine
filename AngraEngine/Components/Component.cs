using SFML.Graphics;

namespace AngraEngine
{
    public abstract class Component : IInitializable, ILoadable, Drawable
    {
        public GameObject gameObject { get; set; }
        private bool isActive = true;

        public bool IsActive
        {
            get => isActive;
            set
            {
                if (value != isActive)
                {
                    isActive = value;
                    SetActive(value);
                }
            }
        }

        public abstract void Awake();

        public abstract void Start();

        public abstract void Update(float deltaTime);

        public virtual void OnDestroy() { }

        public virtual void Load() { }

        public virtual void Unload() { }

        public virtual void Draw(RenderTarget target, RenderStates states) { }

        public virtual void SetActive(bool value) { }
        public virtual Component Clone()
        {
            Component clone = (Component)Activator.CreateInstance(this.GetType());
            return clone;
        }

        public virtual void Attach(Component component)
        {
            if (gameObject != null && component.gameObject != null)
            {
                component.gameObject.Transform.SetParent(gameObject.Transform);
            }
            else
            {
                throw new Exception("Failed to attach component: game object or component game object is null.");
            }
        }
    }
}
