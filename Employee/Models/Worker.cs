using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Employee.Models
{
    //Сущность работника
    public class Worker
    {
        //id
        public int WorkerId { get; set; }
        //Имя
        public string FirstName { get; set; }
        //Фамилия
        public string SecondName { get; set; }
        //Отчество
        public string Patronymic { get; set; }
        ///Должность
        public string Position { get; set; }
        ///Группа к которой относится
        public string DivisionName { get; set; }
    }
}