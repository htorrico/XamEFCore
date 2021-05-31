using System;
using System.Collections.Generic;
using System.Text;
using XamEFCore.Models;

namespace XamEFCore.Services
{
    class ArtistaService
    {
        public void InsertarArtista()
        {
            DBDataAccess<Artista> service = new DBDataAccess<Artista>();

            service.Create(new Artista {ArtistaID=1, Nombre="Luis Miguel" });

            service.Get();
            


        }
    }
}
