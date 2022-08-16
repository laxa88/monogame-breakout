using System.Collections.Generic;
using Microsoft.Xna.Framework;

namespace Engine
{
    public class GameObject : GameComponent
    {
        protected Vector2 _position;
        public Vector2 position
        {
            get { return _position; }
        }

        protected List<Component> _components;
        public int componentCount
        {
            get { return _components.Count; }
        }

        public GameObject(Game game) : base(game)
        {
            _components = new List<Component>();
        }

        public void AddGameObject(GameObject obj)
        {
            // TODO add to list, set their parent to this
        }

        public void RemoveGameObject(GameObject obj)
        {
            // TODO destroy object, remove its parent, remove from this list
        }

        public void AddComponent(Component component)
        {
            if (_components.Contains(component))
            {
                return;
            }

            _components.Add(component);
        }

        public void RemoveComponent<T>()
        {
            _components
                .FindAll(
                    delegate(Component c)
                    {
                        return c is T;
                    }
                )
                .ForEach(
                    delegate(Component c)
                    {
                        _components.Remove(c);
                    }
                );
        }

        public List<T> GetComponents<T>()
        {
            List<T> result = new List<T>();

            _components.ForEach(
                delegate(Component c)
                {
                    if (c is T)
                    {
                        T foo = (T)(object)c;
                        result.Add(foo);
                    }
                }
            );

            return result;
        }

        protected virtual void Activate()
        {
            Enabled = true;
        }

        protected virtual void Deactivate()
        {
            Enabled = false;
        }
    }
}
