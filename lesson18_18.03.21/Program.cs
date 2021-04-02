using System;
using System.Collections.Generic;
using System.Linq;
using Dapper;
using Microsoft.Data.SqlClient;

namespace lesson18_18._03._21
{
    //sql сервер перестал работать, пришлось переустанавливать
    class Program
    {
        static void Main(string[] args)
        {
            var test = new DudesTable.Dude
            {
                Name = "Anush",
                Age = 18,
                Surname = "Pall"
            };
            DudesTable.Commands.Create(test);
        }
    }
}
