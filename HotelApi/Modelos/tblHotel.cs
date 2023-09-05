namespace HotelApi.Modelos
{
    public class TblHotel
    {
        public byte IdHotel { get; set; }
        public byte FkCiudad { get; set; }
        public byte HabitacionesEstandar { get; set; }
        public byte HabitacionesPremium { get; set; }
        public byte CupoMaximoHabitaciones { get; set; }
    }
}
