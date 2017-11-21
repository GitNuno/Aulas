using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportStore.Models.ViewModels
{
    // nao vou usar como ViewModels
    public class PagingInfo
    {
        public int TotalItems { get; set; }
        public int ItemsPerPage { get; set; }
        public int CurrentPage { get; set; }
        // funciona como get : serve para determinar o nº de paginas por nº de items
        public int TotalPages =>
            (int) Math.Ceiling((decimal) TotalItems / ItemsPerPage);//converter um para decimal de modo a que se der por exemplo 2,3 o ceiling encarrega-se de passar o resultado 3 e dps convertemos para inteiro
    }
}
