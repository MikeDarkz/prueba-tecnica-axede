namespace HotelApi.Modelos
{
    public class ConsultaHotelCiudad
    {
        public byte IdHotel { get; set; }
        public string NombreCiudad { get; set; }
        public byte HabitacionesEstandar { get; set; }
        public byte HabitacionesPremium { get; set; }
        public byte CupoMaximoHabitaciones { get; set; }
    }
}
