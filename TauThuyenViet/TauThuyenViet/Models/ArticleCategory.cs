﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace TauThuyenViet.Models
{
    [Table("ArticleCategory")]
    public partial class ArticleCategory
    {
        public ArticleCategory()
        {
            Articles = new HashSet<Article>();
        }

        [Key]
        public int ArticleCategoryID { get; set; }
        [StringLength(50)]
        public string Code { get; set; }
        [StringLength(200)]
        public string Title { get; set; }
        [StringLength(4000)]
        public string Description { get; set; }
        [StringLength(255)]
        public string Avatar { get; set; }
        [StringLength(255)]
        public string Thumb { get; set; }
        public bool? Status { get; set; }
        public int? Position { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? CreateTime { get; set; }
        public int? ArticleMainCategoryID { get; set; }
        [StringLength(50)]
        public string CreateBy { get; set; }

        [ForeignKey("ArticleMainCategoryID")]
        [InverseProperty("ArticleCategories")]
        public virtual ArticleMainCategory ArticleMainCategory { get; set; }
        [ForeignKey("CreateBy")]
        [InverseProperty("ArticleCategories")]
        public virtual Account CreateByNavigation { get; set; }
        [InverseProperty("ArticleCategory")]
        public virtual ICollection<Article> Articles { get; set; }
    }
}