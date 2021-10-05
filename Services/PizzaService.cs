using ContosoPizza.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using MySql.Data.MySqlClient;

namespace ContosoPizza.Services
{
    public class PizzaService
    {

        public static List<Pizza> GetAll()
        {
            List<Pizza> pizzas;
            string query = $"SELECT * FROM pizzas";
            using (MySqlConnection connection = new MySqlConnection(Program.SqlCNN))
            {
                pizzas = connection.Query<Pizza>(query).ToList();
            }

            return pizzas;
        }
        public static Pizza Get(int id)
        {
            Pizza pizza = new Pizza();
            string query = $"SELECT * FROM pizzas WHERE Id = {id}";
            using (MySqlConnection connection = new MySqlConnection(Program.SqlCNN))
            {
                pizza = connection.Query<Pizza>(query).SingleOrDefault();
            }
            return pizza;
        }

        public static void Add(Pizza pizza)
        {
            string query = "INSERT INTO pizzas(Name, IsGlutenFree) Values(@Name, @IsGlutenFree);";
            using (MySqlConnection connection = new MySqlConnection(Program.SqlCNN))
            {
                connection.Execute(query, pizza);
            }
        }

        public static void Delete(int id)
        {
            var pizza = Get(id);
            if(pizza is null)
            {
                return;
            }

            string query = $"DELETE * FROM pizzas WHERE Id = {id}";
            using (MySqlConnection connection = new MySqlConnection(Program.SqlCNN))
            {
                connection.Execute(query);
            }
        }

        public static void Update(Pizza pizza)
        {
            var result = Get(pizza.Id);
            if (result is null)
            {
                return;
            }
            string query = $"UPDATE pizzas set Name=@Name, IsGlutenFree=@IsGlutenFree WHERE Id = {pizza.Id}";
            using (MySqlConnection connection = new MySqlConnection(Program.SqlCNN))
            {
                connection.Execute(query, pizza);
            }
        }
    }
}
