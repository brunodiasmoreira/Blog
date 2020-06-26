﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blog.ViewModels.Admin
{
    public class AdminPostagensRemoverViewModel : ViewModelAreaAdministrativa
    {
        public int IdEtiqueta { get; set; }

        public string NomeEtiqueta { get; set; }

        public string Erro { get; set; }

        public AdminPostagensRemoverViewModel()
        {
            TituloPagina = "Remover Postagem: ";
        }
    }
}