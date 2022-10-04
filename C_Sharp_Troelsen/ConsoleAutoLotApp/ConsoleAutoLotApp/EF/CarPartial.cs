using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAutoLotApp.EF
{
    public partial class Car
    {
        public override string ToString()
        {
            // Поскольку столбец PetName может быть пустым,
            // предоставить стандартное имя **No Name**.
            return $"{ this.CarNickName ?? "**No Name**"} is a {this.Color}" +
                $"{ this.Make} with ID { this.CardID}.";
        }

    }
}
