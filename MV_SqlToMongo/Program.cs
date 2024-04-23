using AutoMapper;
using MV_SqlToMongo.View;

namespace MV_SqlToMongo
{
    public static class Program
    {
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();
            Application.Run(new MainForm());
        }
    }
}