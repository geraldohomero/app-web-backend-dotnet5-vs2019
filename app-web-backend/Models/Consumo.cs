using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace app_web_backend.Models
{
    [Table("Consumos")]
    public class Consumo
    {
        [Key]
        public int Id { get; set; }
        [Display(Name = "Descrição")]
        [Required(ErrorMessage ="Obrigatório informar a descrição")]
        public string Descricao { get; set; }
        [Required(ErrorMessage = "Obrigatório informar a Data")]
        public DateTime Data { get; set; }
        [Required(ErrorMessage = "Obrigatório informar a quilometragem")]
        public int Km { get; set; }
        [Required(ErrorMessage = "Obrigatório informar o Valor")]
        [Column(TypeName = "decimal(18,2)")]
        public decimal Valor { get; set; }
        [Display(Name = "Tipo de Combistível")]
        [Required(ErrorMessage = "Obrigatório informar o Tipo")]
        public TipoCombustivel Tipo { get; set; }

        [Display(Name = "Veículo")]
        [Required(ErrorMessage = "Obrigatório informar o Veículo")]
        public int VeiculoId { get; set; }
        [ForeignKey("VeiculoId")]
        public Veiculo Veiculo { get; set; }

    }

    public enum TipoCombustivel
    {
        Gasolina,
        Etanol,
        GNV,
        Flex
    }
}
