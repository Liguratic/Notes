//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Notes.DB
{
    using System;
    using System.Collections.Generic;
    
    public partial class Notes
    {
        public int IdNote { get; set; }
        public string Topic { get; set; }
        public string Message { get; set; }
        public System.DateTime DateAndTime { get; set; }
        public int IdUser { get; set; }
    
        public virtual UserData UserData { get; set; }
    }
}
