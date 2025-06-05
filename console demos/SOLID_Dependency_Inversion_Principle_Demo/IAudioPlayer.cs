using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOLID_Dependency_Inversion_Principle_Demo
{
    public interface IAudioPlayer
    {
        void Play(string file);
    }

    public class MP3Player:IAudioPlayer
    {
        public void Play(string file)
        {
            Console.WriteLine(" MP3 Palyer is Running");
        }
    }
    public class WAVPlayer : IAudioPlayer
    {
        public void Play(string file)
        {
            Console.WriteLine(" WAV Palyer is Running");
        }
    }

    public class MusicPlayer
    {
        private readonly Dictionary<string, IAudioPlayer> _players;

        public MusicPlayer(Dictionary<string,IAudioPlayer> players)
        {
            _players = players;
        }
        public void Play(string file,string format) {
        
            if(_players.ContainsKey(format)) {
                _players[format].Play(file);
            }
            else
            {
                Console.WriteLine("Unsupported File format");
            }
        }
    }
}
