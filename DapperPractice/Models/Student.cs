﻿using Dapper;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DapperPractice.Models
{
    [Table("Student")]
    public class Student
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }

    }
}
