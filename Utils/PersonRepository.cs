using gTipanS5.Modelos;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace gTipanS5.Utils
{
    public class PersonRepository
    {
        private readonly string _dbPath;
        private SQLiteConnection conn;

        public string StatusMessage { get; set; }
        private void Init()
        {
            if (conn != null)
                return;
            conn = new SQLiteConnection(_dbPath);
            conn.CreateTable<Persona>();
           
        }
        public PersonRepository(string dbPath)
        {
            _dbPath = dbPath;
        }
        public void AddNewPerson(string nombre)
        {
            int result = 0;
            try
            {
                Init();
                if (string.IsNullOrEmpty(nombre))
                    throw new Exception("Nombre requerido");
                var person = new Persona { Name = nombre };
                result = conn.Insert(person);
                StatusMessage = $"Datos añadidos correctamente: {result} - {nombre}";

            }
            catch (Exception ex)
            {
                StatusMessage = $"Error añadiendo {nombre}: {ex.Message}";

            }

        }

        public List<Persona> GetAllPeople()
        {

            try
            {
                Init();
                return conn.Table<Persona>().ToList();
            }
            catch (Exception ex)
            {

                StatusMessage = $"Error al mostrar personas: {ex.Message}";
                return new List<Persona>();

            }
           
        }
        public void UpdatePerson(int id, string nombre)
        {
            try
            {
                Init();
                var person = conn.Table<Persona>().FirstOrDefault(p => p.Id == id);
                if (person == null)
                    throw new Exception("Persona no encontrada");

                person.Name = nombre;
                conn.Update(person);
                StatusMessage = $"Persona actualizada correctamente: {id} - {nombre}";
            }
            catch (Exception ex)
            {
                StatusMessage = $"Error actualizando {nombre}: {ex.Message}";

            }
        }
        public void DeletePerson(int id)
        {
            try
            {
                Init();
                var person = conn.Table<Persona>().FirstOrDefault(p => p.Id == id);
                if (person == null)
                    throw new Exception("Persona no encontrada");

                conn.Delete(person);
                StatusMessage = $"Persona eliminada correctamente: {id}";
            }
            catch (Exception ex)
            {
                StatusMessage = $"Error eliminando persona con ID {id}: {ex.Message}";

            }
        }

    }

}


