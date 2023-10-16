namespace ValidacaoConhecimentoCG.API.Infrastructure.Extensions
{
    public static class StringExtensions
    {
        public static string? ApenasNumeros(this string str)
        {
            if (str is null) 
                return null;

            return new string(str.Where(char.IsDigit).ToArray());
        }
    }
}
