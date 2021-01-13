using System;
using System.ComponentModel.DataAnnotations;

namespace GlobalGames.Data.Entidades
{
    public class Inscricoes
    {
        public int Id { get; set; }

        [Display(Name = "Nome")]
        public string Name { get; set; }

        [Display(Name = "Apelido")]
        public string LastName { get; set; }

        [Display(Name = "Morada")]
        public string Address { get; set; }

        [Display(Name = "Localidade")]
        public string Localidade { get; set; }

        [Display(Name = "CC")]
        public int CCidadao { get; set; }

        [Display(Name = "Data de Nascimento")]
        public DateTime Birthday { get; set; }

        [Display(Name = "Image")]
        public string ImageUrl { get; set; }

        public User User { get; set; }


        public string ImageFullPath
        {
            get
            {
                if (string.IsNullOrEmpty(this.ImageUrl))
                {
                    return null;
                }


                //por a morada do site !!!!!!! e tirar o localhost
                //FEITO POR JD
                return $"https://localhost:44394{this.ImageUrl.Substring(1)}";
            }
        }
    }
}