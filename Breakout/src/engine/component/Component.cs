namespace Engine
{
    public class Component
    {
        protected GameObject _parent;
        protected bool _active = false;

        public void Activate()
        {
            _active = true;
        }

        public void Deactivate()
        {
            _active = false;
        }

        public virtual void Update() { }

        public virtual void Draw() { }
    }
}
