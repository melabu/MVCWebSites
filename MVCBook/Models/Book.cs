using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MVCBook.Models
{
    [Table("Book")]
    public class Book
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "The name field is required")]
        [Column(TypeName = "Varchar")]
        public string Name { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(50, ErrorMessage = "The field Author must be a string with a maximum lenght of 50")]
        public string Author { get; set; }

        [Range(100, 10000, ErrorMessage = "The field PagesNumber must be between 100 and 10000")]
        public int PagesNumber { get; set; }

        [Column(TypeName = "Varchar")]
        public string Publisher { get; set; }

        [Column(TypeName = "Varchar")]
        [DisplayFormat(DataFormatString = "{0:dd / MM / yy}", ApplyFormatInEditMode = true)]
        [RegularExpression(@"^\d{4}(\-|\/|\.)\d{1,2}\1\d{1,2}$")]
        public string PublicationDate { get; set; }

        [Column(TypeName = "Varchar")]
        public string Content { get; set; }

        [Column(TypeName = "Money")]
        public decimal Price { get; set; }

        [Column(TypeName = "Money")]
        [System.ComponentModel.DataAnnotations.Compare("Price")]
        public decimal PriceConfirm { get; set; }
    }
}