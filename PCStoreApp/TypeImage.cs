//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace PCStoreApp
{
    using System;
    using System.Collections.Generic;
    
    public partial class TypeImage
    {
        public int Id { get; set; }
        public int Typeid { get; set; }
        public byte[] ImageSource { get; set; }
    
        public virtual Type Type { get; set; }
    }
}
