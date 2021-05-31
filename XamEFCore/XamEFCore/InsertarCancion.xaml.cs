using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XamEFCore.DataContext;
using XamEFCore.Interfaces;

namespace XamEFCore
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class InsertarCancion : ContentPage
    {
        private string DbPath;
        private AppDbContext dbContext;
        public InsertarCancion()
        {
            InitializeComponent();

            //Utilizar la dependencia de servicio
            DbPath = DependencyService.Get<IConfigDataBase>().GetFullPath("dbTest.db");
            dbContext = new AppDbContext(DbPath);
            //Crear la base de datos
            dbContext.Database.EnsureCreated();
        }

        private void btnGrabar_Clicked(object sender, EventArgs e)
        {                
                dbContext.Canciones.Add(new Models.Cancion {
                Annio =Convert.ToInt32( txtAnnio.Text), Titulo = txtTitulo.Text });
                dbContext.SaveChanges();                 
        }

        private void btnListar_Clicked(object sender, EventArgs e)
        {
            ReloadData();
        }

        private void btnEliminar_Clicked(object sender, EventArgs e)
        {            
            dbContext.Canciones.RemoveRange(dbContext.Canciones);
            dbContext.SaveChanges();
            ReloadData();

        }
        private void ReloadData()
        {
            lvCanciones.ItemsSource = dbContext.Canciones.ToList();
        }

        private void btnBuscar_Clicked(object sender, EventArgs e)
        {
            lvCanciones.ItemsSource= dbContext.Canciones.Where(x => x.Titulo.Contains(txtFiltro.Text));

        }
    }
}