﻿
using SFML.Graphics;
using SFML.System;

using System.Reflection;
using System.Runtime.CompilerServices;

namespace AngraEngine
{
    public class GameObject : Drawable, IDisposable, IInitializable, IUpdatable, ILoadable
    {
        protected float rotation;
        protected Vector2f position;
        public string Tag { get; protected set; } = "untagged";

        private List<Component> components = new List<Component>();
        public Collider Collider { get; protected set; }
        public bool IsCollided { get; set; } = false;
        public Transform Transform { get; private set; } = new Transform();
        public float Rotation { get => Transform.Rotation; set => Transform.Rotation = value; } // Use the Transform component's Rotation property
        public Vector2f Position { get => Transform.Position; set => Transform.Position = value; } // Use the Transform component's Position property
        public bool IsActive { get; private set; } = true;
        public virtual Vector2f Size => new Vector2f(1, 1);
        public virtual FloatRect GlobalBounds => new FloatRect(1, 1, 1, 1);

        public string Name { get; protected set; }

        public GameObject()
        {
            Transform = new Transform();
            AddComponent(Transform);
        }

        public GameObject(string name)
        {
            Transform = new Transform();
            AddComponent(Transform);
            this.Name = name;
        }

        public void SetActive(bool active)
        {
            if (IsActive == active)
                return;

            IsActive = active;
            ToggleActivation(active);
        }

        public void ToggleActivation(bool active)
        {
            components.ForEach(c => c.IsActive = active);
        }


        /// <summary>
        /// Executed one frame
        /// </summary>
        public virtual void Awake()
        {
            foreach (Component component in components)
                component.Awake();
        }

        public virtual void Dispose()
        {
            //sprite.Dispose();
        }

        public virtual void Draw(RenderTarget target, RenderStates states)
        {
            if (!IsActive)
                return;

            foreach (Component component in components)
                if (component.IsActive)
                    component.Draw(target, states);
        }

        /// <summary>
        /// Executed one frame after awake
        /// </summary>
        public virtual void Start()
        {
            foreach (Component component in components)
                component.Start();
        }

        /// <summary>
        /// Execute every frame
        /// </summary>
        public virtual void Update()
        {
            foreach (var component in components)
                component.Update(TimeManager.deltaTime);
        }

        public virtual void OnDestroy()
        {
            SceneManager.CurrentScene.RemoveGameObejct(this);
            Dispose();
        }

        public bool CheckCollision(GameObject targetObject) => GlobalBounds.Intersects(targetObject.GlobalBounds);

        public virtual void OnCollisionEnter(GameObject target)
        {
            Rigidbody rigidbody = GetComponent<Rigidbody>();
            Rigidbody targetRigidbody = target.GetComponent<Rigidbody>();

            if (rigidbody == null)
                return;

            if (targetRigidbody == null)
                return;

            float impactForce = 0.5f * rigidbody.Mass * targetRigidbody.Mass *
                ((rigidbody.Velocity - targetRigidbody.Velocity).Length() / TimeManager.deltaTime);
            // Calculate direction of impact
            Vector2f direction = target.Position - Position;

            // Normalize the direction vector to get a unit vector
            direction.Normalize();

            // Apply a force in the opposite direction of the impact
            rigidbody.ApplyForce(-direction * impactForce);
        }

        public virtual void OnCollisionExit(GameObject target)
        {

        }

        public virtual void Load()
        {
            foreach (Component component in components)
                component.Load();
        }

        public virtual void Unload()
        {
            foreach (Component component in components)
                component.Unload();
        }

        #region Component Related Methods

        public void AddComponent(params Component[] newComponents)
        {
            for (int i = 0; i < newComponents.Length; i++)
                for (int j = 0; j < components.Count; j++)
                    if (newComponents[i] == components[j])
                        return;

            for (int i = 0; i < newComponents.Length; i++)
            {
                components.Add(newComponents[i]);
                newComponents[i].gameObject = this;

                if (newComponents[i] is IPhysical)
                    PhysicsManager.AddRigidBody((Rigidbody)newComponents[i]);
            }
        }

        public void RemoveComponent(Component component) => components.Remove(component);


        public T GetComponent<T>() where T : Component
        {
            // LINQ
            return components.Find(theComponent => theComponent is T) as T;
        }

        // Lambda Expression
        public List<Component> GetComponents() => components;


        #endregion
    }
}
