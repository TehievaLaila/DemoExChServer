//------------------------------------------------------------------------------
// <auto-generated>
//    Этот код был создан из шаблона.
//
//    Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//    Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DemoExChServer.DB
{
    using System;
    using System.Collections.Generic;
    
    public partial class Empl_Chatr
    {
        public int ID_Empl_Chatr { get; set; }
        public Nullable<int> ID_Employee { get; set; }
        public Nullable<int> ID_Chatroom { get; set; }
    
        public virtual Chatroom Chatroom { get; set; }
        public virtual Employee Employee { get; set; }
    }
}
