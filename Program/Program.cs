
namespace Program
{
    using System;
    using KimTower.Data;

    class Program
    {
        static void Main(string[] args)
        {
            var tower = new Tower();
            var loop = new GameLoop();
            loop.Run(tower);

        }
    }
}


