using System;
using GestionApp.src.Data;


namespace GestionApp
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();

            //Creo la base de datos si no existe
            using (var db = new AppDbContext())
            {
                db.Database.EnsureCreated();
            }
            
            //levanto el formulario principal
            Application.Run(new frmHome());
        }
    }
}