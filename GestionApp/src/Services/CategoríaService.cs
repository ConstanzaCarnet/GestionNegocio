using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GestionApp.src.Data;
using GestionApp.src.DTOs.Request;
using GestionApp.src.Models;
using Microsoft.EntityFrameworkCore;

namespace GestionApp.src.Services
{
    public class CategoríaService
    {
        public void Crear(CategoriaDto dto)
        {
            // Validación de entrada para evitar el error de base de datos
            if (string.IsNullOrWhiteSpace(dto.Nombre))
                throw new Exception("El nombre de la categoría no puede estar vacío.");

            //abro conexion
            using var db = new AppDbContext();
            //valido que el nombre no esté ya registrado
            if (db.Categorias.Any(c => c.Nombre.ToLower() == dto.Nombre.ToLower()))
                throw new Exception("Ya existe una categoría con ese nombre.");

            var categoria = new Categoria
            {
                Nombre = dto.Nombre.Trim(), // Limpiamos espacios
                Descripcion = dto.Descripcion?.Trim()
            };
            db.Add(categoria);
            db.SaveChanges();
        }

        //obtener los nombres de todas las categorias
        //para cargar combos box
        public List<Categoria> Obtener()
        {
            using var db = new AppDbContext();
            return db.Categorias
                .AsNoTracking()
                .ToList();
        }
        //metodo para validar si existe una categoria por su nombre
        public bool ExisteNombre(string nombre)
        {
            using var db = new AppDbContext();
            //revisamos si ya existe el nombre de esa categoría parecida o igual
            if (db.Categorias.Any(c => c.Nombre.ToLower() == nombre.ToLower()) || db.Categorias.Any(c => c.Nombre.ToLower().Contains(nombre.ToLower())))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        //metodo para eliminar una categoria por su id
        public void Eliminar(int id)
        {
            using var db = new AppDbContext();
            var categoria = db.Categorias.Find(id);
            if (categoria == null)
                throw new Exception("Categoría no encontrada.");

            //No permitimos borrar una categoría con productos asociados (rompería la FK).
            if (db.Productos.Any(p => p.IdCategoria == id))
                throw new Exception("No se puede eliminar la categoría porque tiene productos asociados.");

            db.Categorias.Remove(categoria);
            db.SaveChanges();
        }
        //metodo para actualizar una categoria por su id
        public void Actualizar(int id, CategoriaDto dto)
        {
            using var db = new AppDbContext();
            var categoria = db.Categorias.Find(id);
            if (categoria == null)
                throw new Exception("Categoría no encontrada.");

            // Validación de entrada para evitar el error de base de datos
            if (string.IsNullOrWhiteSpace(dto.Nombre))
                throw new Exception("El nombre de la categoría no puede estar vacío.");

            // Verificar si el nuevo nombre ya existe en otra categoría
            if (db.Categorias.Any(c => c.IdCategoria != id && c.Nombre.ToLower() == dto.Nombre.ToLower()))
                throw new Exception("Ya existe una categoría con ese nombre.");

            categoria.Nombre = dto.Nombre.Trim();
            categoria.Descripcion = dto.Descripcion?.Trim();
            db.SaveChanges();
        }

        //obtenemos por id
        public Categoria ObtenerPorId(int id)
        {
            using var db = new AppDbContext();
            return db.Categorias.FirstOrDefault(c => c.IdCategoria == id);
        }
        //valido si existe mas  de una categoria con el mismo nombre
        public bool ExisteNombreDuplicado(string nombre, int id)
        {
            using var db = new AppDbContext();
            return db.Categorias.Any(c => c.IdCategoria != id && c.Nombre.ToLower() == nombre.ToLower());
        }

        }
}
