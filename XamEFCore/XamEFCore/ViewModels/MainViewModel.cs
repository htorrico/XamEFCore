using Microsoft.EntityFrameworkCore.Scaffolding.Metadata;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using XamEFCore.Models;
using XamEFCore.Services;

namespace XamEFCore.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        #region Attributes
        private ObservableCollection<MenuItemViewModel> menu;
        #endregion Attributes

        #region Properties
        public ObservableCollection<MenuItemViewModel> Menu
        {
            get { return this.menu; }
            set { SetValue(ref this.menu, value); }
        }
        #endregion Properties

        #region Constructor
        public MainViewModel()
        {
            this.LoadMenu();

            //this.SaveArtistasList();

            // DBDataAccess<Album> dBDataAccess = new DBDataAccess<Album>();


            //Insertar nuevo album
            //   dBDataAccess.Create(new Album { 
            //    Titulo = "COVID 2020", 
            //    Anio = 2020 ,
            //    ArtistaID=1            
            //});

            //Insertar artista y el album
            //Gian Marco
            //Album Invierno 2021


            //No saber usar el ORM
            //DBDataAccess<Artista> serviceArtista = new DBDataAccess<Artista>();
            //serviceArtista.Create(new Artista { Nombre = "GianMarco" });
            //Artista artista = serviceArtista.Get(x => x.Nombre == "GianMarco").FirstOrDefault();
            //DBDataAccess<Album> serviceAlbum = new DBDataAccess<Album>();
            //serviceAlbum.Create(new Album { Titulo = "Titulo", ArtistaID = artista.ArtistaID });

            //ORM 
            DBDataAccess<Album> serviceAlbum = new DBDataAccess<Album>();
            List<Cancion> canciones = new List<Cancion>();
            canciones.Add(new Cancion { Nombre = "La Chata" });
            canciones.Add(new Cancion { Nombre = "Decir Adios" });
            canciones.Add(new Cancion { Nombre = "Pan con Mantequilla" });
            canciones.Add(new Cancion { Nombre = "Rosas en el Bar" });

            //Services.serviceAlbum serviceAlbum = new serviceAlbum();
            serviceAlbum.Create(
                new Album
                {
                    Titulo = "Album 2010",
                    Artista = new Artista { Nombre = "Grupo Amén" },
                    Canciones= canciones
                }
                );






            //this.DeleArtistasList();
        }
        #endregion Constructor

        #region Methods
        private void LoadMenu()
        {
            this.Menu = new ObservableCollection<MenuItemViewModel>();

            this.Menu.Clear();
            this.Menu.Add(new MenuItemViewModel { Id = 1, Option = "Crear" });
            this.Menu.Add(new MenuItemViewModel { Id = 2, Option = "Lista de Registros" });
            this.Menu.Add(new MenuItemViewModel { Id = 3, Option = "Eliminar Registros" });
        }
        #endregion Methods

        DBDataAccess<Artista> dataService = new DBDataAccess<Artista>();
        private void SaveArtistasList()
        {
            var artistas = new List<Artista>()
            {
                new Artista{ Nombre = "Arjona" },
                new Artista{ Nombre = "Luismi" },
                new Artista{ Nombre = "Kalimba" }
            };

            dataService.SaveList(artistas);
        }
        private void DeleArtistasList()
        {
            var artistas = dataService.Get().ToList();
            dataService.DeleteList(artistas);
        }
        
    }
}
