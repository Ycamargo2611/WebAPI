using Microsoft.AspNetCore.Http.HttpResults;
using ShoppingAPI_Viernes2024I.DAL;
using ShoppingAPI_Viernes2024I.DAL.Entities;
using System.Data.Entity;
using WebAPI.ShoppingAPI_Viernes2024I.DAL.Entities;

namespace WebAPI.ShoppingAPI_Viernes2024I.DAL
{
    public class SeederDB //ligado a DBContext
    {
        private readonly DataBaseContext _context;

        public SeederDB(DataBaseContext context)
        {
            _context = context;
        }

        //Creamos el metodo SeederAsync, Es una especie de MAIN()
        //Este metodo tendra la responsabilidad de prepoblar en diferentes tablas de la DB.

        public async Task SeederAsync() //Este metodo es asincronico porque permite correr la app de manera que no se pare
        {
            //Primero agregamos un metodo propio de EntityFramework que hace las veces de comando "update-database"
            //En otras palabras, crea la BD inmediatamenete ponga en ejecución la API

            await _context.Database.EnsureCreateAsync();

            //A partir de acá creamos los metodos para prepoblar la BD
            await PopulateCountriesAsync();

        }

        #region Private Methos

        private async Task PopulateCountriesAsync()
        {
            if (!_context.Countries.Any()) //El metodo !Any() me indica si la tabla Countries tiene al menos un registro
                                           //El metodo Any negado indica que no hay nada en la tabla Countries
            {
                //Aquí se crea el objeto País con sus respectivos estados y de esta manera se llena la DB 
                //Nos sirve para llenar los productos del shopping
                _context.Countries.Add(new Country
                {
                    CreatedDate = DateTime.Now,
                    Name = "Colombia",
                    States = new List<State>()
                    {
                        new State
                        {
                            CreatedDate = DateTime.Now,
                            Name = "Antioquia"
                        },

                        new State
                        {
                            CreatedDate =  DateTime.Now,
                            Name = "Cundinamarca"
                        }
                    }



                });
            }
            #endregion

        }
    }
}
