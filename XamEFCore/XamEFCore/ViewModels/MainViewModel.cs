using Microsoft.EntityFrameworkCore.Scaffolding.Metadata;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
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
