
namespace AngraEngine
{
    public static class PhysicsManager
    {
        private static List<Rigidbody> rigidbodies = new List<Rigidbody>();   

        public static void AddRigidBody(Rigidbody newGameObject)
        {
            rigidbodies.Add(newGameObject);
        }

        public static void RemoveRigidbody(Rigidbody newGameObject)
        {
            rigidbodies.Remove(newGameObject);
        }

        public static void Update()
        {
            CollisionDetection();
            ApplyPhysics(TimeManager.deltaTime);
        }

        private static void CollisionDetection()
        {
            for (int i = 0; i < rigidbodies.Count; i++)
            {
                Rigidbody bodyA = rigidbodies[i];
                Collider colliderA = bodyA.gameObject.GetComponent<Collider>();

                for (int j = 0; j < rigidbodies.Count; j++)
                {
                    Rigidbody bodyB = rigidbodies[j];
                    Collider colliderB = bodyB.gameObject.GetComponent<Collider>();

                    if (colliderA == null || colliderB == null)
                        continue;

                    if (colliderA.CheckCollision(colliderB))
                    {
                        bodyA.gameObject.OnCollisionEnter(bodyB.gameObject);
                        bodyB.gameObject.OnCollisionEnter(bodyA.gameObject);
                    }
                    else
                    {
                        bodyA.gameObject.OnCollisionExit(bodyB.gameObject);
                        bodyB.gameObject.OnCollisionExit(bodyA.gameObject);
                    }
                }
            }
        }

        public static void ApplyPhysics(float deltaTime)
        {
            foreach (Rigidbody body in rigidbodies)
                body.Update(deltaTime);
        }
    }
}
