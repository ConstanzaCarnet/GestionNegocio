using GestionApp.src.Data;
using GestionApp.src.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionApp.src.Services.Email
{
    public class ConfiguracionService
    {
        public ConfiguracionEmail ObtenerConfig()
        {
            using var db = new AppDbContext();
            return db.ConfiguracionEmails.FirstOrDefault() ?? new ConfiguracionEmail();
        }
        public void GuardarConfig(ConfiguracionEmail config)
        {
            using var db = new AppDbContext();
            var existente = db.ConfiguracionEmails.FirstOrDefault();
            if (existente != null)
            {
                existente.EmailEmisor = config.EmailEmisor;
                existente.Password = config.Password;
                existente.Host = config.Host;
                existente.Puerto = config.Puerto;
                existente.NombreEmpresa = config.NombreEmpresa;
                db.Update(existente);
            }
            else
            {
                db.Add(config);
            }
            db.SaveChanges();
        }
    }
}
