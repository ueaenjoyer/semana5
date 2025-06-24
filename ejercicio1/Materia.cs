namespace GestorMaterias
{
    public class Materia
    {
        public string Nombre { get; set; }
        public string Profesor { get; set; }

        public Materia(string nombre, string profesor)
        {
            Nombre = nombre;
            Profesor = profesor;
        }

        public override string ToString()
            => $"{Nombre,-25}  {Profesor,-15} cr.";
    }
}
