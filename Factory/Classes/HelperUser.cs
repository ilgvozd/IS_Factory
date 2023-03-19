using System.Linq;

namespace Factory
{
    internal class HelperUser
    {
        public static Employee Employee { get; set; }       
        
        public static Employee GetEmployee(string login, string password)
        { 
            Employee employee = null;

            using (FactoryEntities db = new FactoryEntities()) 
            {
                employee = db.Employee.SingleOrDefault(e => e.login_user == login && e.password_user == password);
                Employee = employee;
            }

            return employee;
        }

        public static byte[] GetImageData()
        {
            return Employee != null ? Employee.image_ : null;
        }
    }
}