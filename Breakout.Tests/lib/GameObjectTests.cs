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
            Sprite sprite = new Sprite(0, 0, 0, 0);
            obj.AddComponent(sprite);

            Assert.That(obj.componentCount, Is.EqualTo(1));
        }

        [Test]
        public void ShouldAddComponents()
        {
            GameObject obj = new GameObject(game);
            Sprite sprite = new Sprite(0, 0, 0, 0);
            Hitbox2D hitbox = new Hitbox2D(0, 0, 0, 0);
            obj.AddComponent(sprite);
            obj.AddComponent(hitbox);

            Assert.That(obj.componentCount, Is.EqualTo(2));
        }

        [Test]
        public void ShouldNotAddExistingComponent()
        {
            GameObject obj = new GameObject(game);
            Sprite sprite = new Sprite(0, 0, 0, 0);
            obj.AddComponent(sprite);
            obj.AddComponent(sprite);

            Assert.That(obj.componentCount, Is.EqualTo(1));
        }

        [Test]
        public void ShouldRemoveComponent()
        {
            GameObject obj = new GameObject(game);
            Sprite sprite = new Sprite(0, 0, 0, 0);
            obj.AddComponent(sprite);
            obj.RemoveComponent<Sprite>();

            Assert.That(obj.componentCount, Is.EqualTo(0));
        }

        [Test]
        public void ShouldRemoveComponentsByType()
        {
            GameObject obj = new GameObject(game);
            Sprite sprite1 = new Sprite(0, 0, 0, 0);
            Sprite sprite2 = new Sprite(0, 0, 0, 0);
            Hitbox2D hitbox1 = new Hitbox2D(0, 0, 0, 0);
            Hitbox2D hitbox2 = new Hitbox2D(0, 0, 0, 0);
            obj.AddComponent(sprite1);
            obj.AddComponent(sprite2);
            obj.AddComponent(hitbox1);
            obj.AddComponent(hitbox2);
            obj.RemoveComponent<Sprite>();

            Assert.That(obj.componentCount, Is.EqualTo(2));
        }

        [Test]
        public void ShouldGetComponentByType()
        {
            GameObject obj = new GameObject(game);
            Sprite sprite1 = new Sprite(0, 0, 0, 0);
            Sprite sprite2 = new Sprite(0, 0, 0, 0);
            Hitbox2D hitbox1 = new Hitbox2D(0, 0, 0, 0);
            Hitbox2D hitbox2 = new Hitbox2D(0, 0, 0, 0);
            obj.AddComponent(sprite1);
            obj.AddComponent(hitbox1);
            obj.AddComponent(sprite2);
            obj.AddComponent(hitbox2);
            List<Sprite> sprites = obj.GetComponents<Sprite>();

            Assert.That(sprites.Count, Is.EqualTo(2));
            Assert.That(sprites[0], Is.SameAs(sprite1));
            Assert.That(sprites[1], Is.SameAs(sprite2));
        }
    }
}
