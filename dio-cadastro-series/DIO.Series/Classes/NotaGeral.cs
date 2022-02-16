namespace DIO.Series.Classes
{
    public class NotaGeral : EntidadeBase
    {
        private int _numeroDeNotas = 0;

        // public NotaGeral(decimal nota)
        // {
        //     Nota = nota;
        // }

        private decimal Nota { get; set; }

        public void AdicionarNota(int nota)
        {
            _numeroDeNotas += 1;
            var notaGeral = Nota; 
            notaGeral = (notaGeral + nota) / _numeroDeNotas;

            Nota = notaGeral;
        }

        public decimal RetornarNotaGeral() => Nota;
    }
}