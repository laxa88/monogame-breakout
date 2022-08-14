using System.Collections.Generic;
using Engine;
using Microsoft.Xna.Framework;
using NUnit.Framework;

namespace Breakout.Tests
{
    [TestFixture]
    public class GameObjectTests
    {
        Game game;

        [SetUp]
        public void SetUp()
        {
            // Code here will be run once before every test.
            game = new Game();
        }

        [Test]
        public void ShouldAddComponent()
        {
            GameObject obj = new GameObject(game);
            Sprite sprite = new Sprite();
            obj.AddComponent(sprite);

            Assert.AreEqual(1, obj.componentCount);
        }

        [Test]
        public void ShouldAddComponents()
        {
            GameObject obj = new GameObject(game);
            Sprite sprite = new Sprite();
            Hitbox2D hitbox = new Hitbox2D();
            obj.AddComponent(sprite);
            obj.AddComponent(hitbox);

            Assert.AreEqual(2, obj.componentCount);
        }

        [Test]
        public void ShouldNotAddExistingComponent()
        {
            GameObject obj = new GameObject(game);
            Sprite sprite = new Sprite();
            obj.AddComponent(sprite);
            obj.AddComponent(sprite);

            Assert.AreEqual(1, obj.componentCount);
        }

        [Test]
        public void ShouldRemoveComponent()
        {
            GameObject obj = new GameObject(game);
            Sprite sprite = new Sprite();
            obj.AddComponent(sprite);
            obj.RemoveComponent<Sprite>();

            Assert.AreEqual(0, obj.componentCount);
        }

        [Test]
        public void ShouldRemoveComponentsByType()
        {
            GameObject obj = new GameObject(game);
            Sprite sprite1 = new Sprite();
            Sprite sprite2 = new Sprite();
            Hitbox2D hitbox1 = new Hitbox2D();
            Hitbox2D hitbox2 = new Hitbox2D();
            obj.AddComponent(sprite1);
            obj.AddComponent(sprite2);
            obj.AddComponent(hitbox1);
            obj.AddComponent(hitbox2);
            obj.RemoveComponent<Sprite>();

            Assert.AreEqual(2, obj.componentCount);
        }

        [Test]
        public void ShouldGetComponentByType()
        {
            GameObject obj = new GameObject(game);
            Sprite sprite1 = new Sprite();
            Sprite sprite2 = new Sprite();
            Hitbox2D hitbox1 = new Hitbox2D();
            Hitbox2D hitbox2 = new Hitbox2D();
            obj.AddComponent(sprite1);
            obj.AddComponent(hitbox1);
            obj.AddComponent(sprite2);
            obj.AddComponent(hitbox2);
            List<Sprite> sprites = obj.GetComponents<Sprite>();

            Assert.AreEqual(2, sprites.Count);
            Assert.AreSame(sprite1, sprites[0]);
            Assert.AreSame(sprite2, sprites[1]);
        }
    }
}
