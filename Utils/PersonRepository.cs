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
    internal class PersonRepository
    {
        string _dbPath;//ruta
        private SQLiteConnection conn;
        public string StatusMessage { get; set; }
        private void Init()
        {
            if (conn is not null)
                return;
            conn = new(_dbPath);
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
                Persona person = new()
                {
                    Nombre = nombre
                };
                result = conn.Insert(person);
                StatusMessage = String.Format("datos anadidos corerctamente", result, nombre);

            }
            catch (Exception ex)
            {
                StatusMessage = String.Format("Error ", result, nombre);

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

                StatusMessage = String.Format("Error  al mostrar", ex.Message);



            }
            return new List<Persona>();
        }
    }

}


