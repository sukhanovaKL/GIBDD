//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace GIBDD
{
    using System;
    using System.Collections.Generic;
    
    public partial class Fine
    {
        public int Id { get; set; }
        public string CarNumber { get; set; }
        public string RegionNameRU { get; set; }
        public int LicenceNumber { get; set; }
        public Nullable<System.DateTime> CreateDate { get; set; }
        public byte[] Photo { get; set; }
        public int IdStatus { get; set; }
        public Nullable<System.Guid> IdDriver { get; set; }
    
        public virtual Drivers Drivers { get; set; }
        public virtual FineStatuses FineStatuses { get; set; }
    }
}
