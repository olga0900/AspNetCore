﻿namespace ASPAirport.Models
{
    public class AirModel
    {
        public int nomer_reisa { get; set; }
        public Types type { get; set; }
        public DateTime prib_time { get; set; }
        public int passagiers_count { get; set; }
        public double ppassagiers__price { get; set; }
        public int ek_count { get; set; }
        public double ek_price { get; set; }
        public double procent { get; set; }
    }
}
