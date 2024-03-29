﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoFinalAp2.Models
{
    public class Productos
    {
        [Key]
        [Range(0, 1000000, ErrorMessage = "El campo Id no puede ser menor que cero ni mayor a 1000000.")]
        [Required(ErrorMessage = "El campo Id debe ser un numero.")]
        public int ProductoId { get; set; }

        [Required(ErrorMessage = "Tienes que elegir una categoría.")]
        [ForeignKey("CategoriaId")]
        public int CategoriaiD { get; set; }

        [Required(ErrorMessage = "Tienes que elegir una marca.")]
        [ForeignKey("MarcaId")]
        public int MarcaiD { get; set; }

        [Required(ErrorMessage = "La descripción no puede estar vacía.")]
        [MinLength(3, ErrorMessage = "La descripción es muy corta.")]
        [MaxLength(50, ErrorMessage = "La descripción es muy larga.")]
        public string Descripcion { get; set; }

        [Required(ErrorMessage = "El costo debe ser un numero.")]
        [Range(1, 1000000000, ErrorMessage = "El costo debe ser mayor que cero.")]
        public decimal Costo { get; set; }

        [Required(ErrorMessage = "El precio debe ser un numero.")]
        [Range(1, 1000000000, ErrorMessage = "El precio debe ser mayor que cero.")]
        public decimal Precio { get; set; }
        public decimal Ganancia { get; set; }

        [DataType(DataType.Date, ErrorMessage = "Debes elegir una fecha.")]
        [Required(ErrorMessage = "El campo fecha no puede estar vacío.")]
        [DisplayFormat(DataFormatString = "{0:dd,mm, yyyy}")]
        public DateTime Fecha { get; set; }
       
        [Required(ErrorMessage = "La cantidad debe ser un numero.")]
        [Range(0, 1000000, ErrorMessage = "La cantidad de productos no puede ser menor que cero ni mayor a 1000000.")]
        public int Cantidad { get; set; }

        [Required(ErrorMessage = "El reorden debe ser un numero.")]
        [Range(0, 100000, ErrorMessage = "El reorden de productos no puede ser menor que cero ni mayor a 100000.")]
        public int Reorden { get; set; }

        public Productos()
        {
            ProductoId = 0;
            CategoriaiD = 0;
            Descripcion = string.Empty;
            Costo = 0;
            Precio = 0;
            Ganancia = 0;
            Fecha = DateTime.Now;
            Cantidad = 0;
        }

        public Productos(int productoId, int categoriaiD, string descripcion, decimal costo, decimal precio, decimal ganancia, DateTime fecha, int cantidad, int reorden)
        {
            ProductoId = productoId;
            CategoriaiD = categoriaiD;
            Descripcion = descripcion ?? throw new ArgumentNullException(nameof(descripcion));
            Costo = costo;
            Precio = precio;
            Ganancia = ganancia;
            Fecha = fecha;
            Cantidad = cantidad;
            Reorden = reorden;
        }
    }
}
