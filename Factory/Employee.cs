//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Factory
{
    using System;
    using System.Collections.Generic;
    
    public partial class Employee
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Employee()
        {
            this.Receipt = new HashSet<Receipt>();
        }
    
        public int id_employee { get; set; }
        public string surname_employee { get; set; }
        public string name_employee { get; set; }
        public string patronymic_employee { get; set; }
        public System.DateTime date_birthday { get; set; } = DateTime.Now;
        public string number_phone { get; set; }
        public string email { get; set; }
        public string login_user { get; set; }
        public string password_user { get; set; }
        public string post { get; set; }
        public byte[] image_ { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Receipt> Receipt { get; set; }
    }
}