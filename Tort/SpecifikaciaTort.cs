//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Tort
{
    using System;
    using System.Collections.Generic;
    
    public partial class SpecifikaciaTort
    {
        public string Izdelie { get; set; }
        public string UkrashenieTorta { get; set; }
        public Nullable<int> Kolichestvo { get; set; }
    
        public virtual Izdelie Izdelie1 { get; set; }
        public virtual UkrasheniaTort UkrasheniaTort { get; set; }
    }
}
