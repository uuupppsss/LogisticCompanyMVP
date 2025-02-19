using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace LogisticCompanyMVP.Model
{
    public class DBManager
    {
        private DataBase context;

        static DBManager instance;
        public static DBManager Instance
        {
            get
            {
                if (instance == null)
                    instance = new DBManager();
                return instance;
            }
        }

        public event Action UsersCollectionChanged;
        public event Action OrdersCollectionChanged;

        public User CurrentUser { get; set; }

        public DBManager()
        {
            context = new DataBase();
            context.Database.EnsureCreated();
        }

        //Users
        public async Task<User> SignIn(User user)
        {
           if (user!=null)
            {
                User found_user = await context.Users.FindAsync(user.Name);
                if (found_user != null)
                {
                    if (found_user.Password == user.Password) return found_user;
                    else
                    {
                        MessageBox.Show("Неверный пароль");
                        return null;
                    }

                }
                else
                {
                    MessageBox.Show("Неверный логин");
                    return null;
                }
            }
           else
            {
                MessageBox.Show("Заполните все поля");
                return null;
            }
        }

        public async Task SignUp(User user)
        {
            if(user is null) MessageBox.Show("Неверные входные данные");
            context.Users.Add(user);
            await context.SaveChangesAsync();
            if (context.Users.Contains(user)) MessageBox.Show("Пользователь успешно добавлен");
            else MessageBox.Show("Что-то пошло не так");

            UsersCollectionChanged.Invoke();
        }

        public async Task<List<User>> GetUsersList()
        {
            List<User> result = await context.Users.ToListAsync();
            if (result is null) MessageBox.Show("Пользователи не найдены");
            return result;
        }

        //Orders
        public async Task CreateNewOrder(Order order)
        {
            if (order is null) MessageBox.Show("Неверные входные данные");
            context.Orders.Add(order);
            await context.SaveChangesAsync();
            if (context.Orders.Contains(order)) MessageBox.Show("Пользователь успешно добавлен");
            else MessageBox.Show("Что-то пошло не так");
        }

        public async Task<List<Order>> GetOrdersList()
        {
            List<Order> result = await context.Orders.ToListAsync();
            if (result is null) MessageBox.Show("Заказы не найдены");
            return result;
        }
    }
}
