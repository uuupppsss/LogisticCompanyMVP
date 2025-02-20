using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using LogisticCompanyMVP.Model;
using LogisticCompanyMVP.View;

namespace LogisticCompanyMVP.ViewModel
{
    public class MainWindowVM:BaseVM
    {
		private DBManager db;
		private string _username;

		public string Username
		{
			get { return _username; }
			set { 
				_username = value;
				Signal();
			}
		}

		private string _password;

		public string Password
		{
			get { return _password; }
			set { 
				_password = value;
				Signal();
			}
		}



		public CommandVM SignIn { get; set; }

        public MainWindowVM()
        {
			db=DBManager.Instance;
			SignIn = new CommandVM(async()=>
			{
				User user= await db.SignIn(User);
				if (user != null)
				{
					db.CurrentUser = user;
					MessageBox.Show($"{user.Name}, Добро пожаловать!");
					switch (user.Role)
					{
						case "Admin": AdminView win_ = new AdminView();
							win_.Show();
                            Window win = Application.Current.Windows.OfType<Window>().SingleOrDefault(x => x.DataContext == this);
                            win?.Close();
                            break;
					}
				}
			});
		}
    }
}
