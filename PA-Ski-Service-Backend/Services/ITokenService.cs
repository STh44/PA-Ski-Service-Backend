namespace SkiServiceBackend.Services
{
    public interface ITokenService
    {
        /// <summary>
        /// Erstellt einen Token für den angegebenen Benutzernamen.
        /// </summary>
        /// <param name="username">Der Benutzername.</param>
        /// <returns>Der erstellte Token.</returns>
        string CreateToken(string username);
    }
}
