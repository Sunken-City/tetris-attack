using System;

namespace Tetris_Attack
{
#if WINDOWS || XBOX
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        static void Main(string[] args)
        {
            using (TetrisAttack game = new TetrisAttack())
            {
                game.Run();
            }
        }
    }
#endif
}

