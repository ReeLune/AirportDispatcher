//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace AirportDispatcher.Model
{
    using System;
    using System.Collections.Generic;
    
    public partial class Ticket
    {
        public string Number_Booking { get; set; }
        public string Number_Passenger_Passport { get; set; }
        public string Number_Flight_Ticket { get; set; }
    
        public virtual Flight Flight { get; set; }
        public virtual Passengers Passengers { get; set; }
    }
}
