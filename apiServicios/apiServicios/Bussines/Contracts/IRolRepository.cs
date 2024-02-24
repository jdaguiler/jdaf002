namespace apiServicio.Bussines.Contracts
{
    public class IRolRepository
    {
        Task<List<RolBE>> GetList();
    }
}
