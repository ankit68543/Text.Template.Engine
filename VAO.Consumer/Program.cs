using System;
using System.Collections.Generic;
using System.IO;
using Text.Template.Engine;

namespace VAO.Consumer
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var order = new Order
            {
                Id = 1,
                Name = "Sports Equipement",
                TotalPrice = 100,
                Discount=5,
                CustomerAddress = new Address
                {
                    City = "Delhi",
                    PinCode = 110094,
                    State = "Delhi"
                },
                Products = new List<Product>
                {
                   new Product
                   {
                       Id=20,
                       Name="Bat",
                       Price=60,
                       Colors=new List<Color>
                       {
                           new Color
                           {
                               Type="White"
                           },
                           new Color
                           {
                               Type="Red"
                           }
                       }
                   },
                    new Product
                   {
                       Id=29,
                       Name="Ball",
                       Price=40,
                       Colors=new List<Color>
                       {
                           new Color
                           {
                               Type="Green"
                           },
                           new Color
                           {
                               Type="blue"
                           }
                       }
                   }

                }
            };
            var compiler = new HtmlFormatCompiler();
            var htmlFile = File.ReadAllText("OrderSummary.html");
            var generator = compiler.Compile(htmlFile);            
            var html = generator.Render(order);
            Console.WriteLine(html);

        }

        public class Order
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public decimal TotalPrice { get; set; }
            public List<Product> Products { get; set; }
            public Address CustomerAddress { get; set; }
            public decimal Discount { get; set; }

        }

        public class Address
        {
            public string State { get; set; }
            public string City { get; set; }
            public int PinCode { get; set; }
        }

        public class Product
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public decimal Price { get; set; }

            public List<Color> Colors { get; set; }
        }

        public class Color
        {
            public string Type { get; set; }
        }
    }
}
