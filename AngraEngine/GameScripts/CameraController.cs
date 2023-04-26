namespace AngraEngine
{
    public class CameraController : GameObject
    {
        private Transform target;
        public CameraController(Transform target)
        {
            this.target = target;

            Tag = "Main Camera";
            AddComponent(new Camera());
        }

        public override void Update()
        {
            base.Update();

            Transform.Position = target.Position;
        }
    }
}
