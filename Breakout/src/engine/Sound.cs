using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace Engine
{
    public class Sound
    {
        private static Sound _instance;
        public static Sound instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new Sound();
                }
                return _instance;
            }
        }

        private Dictionary<string, SoundEffect> _soundEffects;
        private Game _game;

        public Sound()
        {
            _soundEffects = new Dictionary<string, SoundEffect>();
        }

        public static void Initialize(Game game)
        {
            instance._game = game;
        }

        public static void LoadSoundEffect(string filename)
        {
            try
            {
                instance._soundEffects.Add(
                    filename,
                    instance._game.Content.Load<SoundEffect>(filename)
                );
            }
            catch (ArgumentException)
            {
                Debug.Print($"Duplicate SFX file loaded: {filename}");
            }
            catch (ContentLoadException)
            {
                Debug.Print($"File not found: {filename} (is it defined in Content.mgcb?)");
            }
        }

        public static void PlaySfx(string filename)
        {
            instance._soundEffects[filename].CreateInstance().Play();
        }
    }
}
