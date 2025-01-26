using Locadora.Data.Data;

namespace LocadoraAgro.Data.Repository
{
    public class UserRepository
    {
        private readonly ApplicationDbContext _db;

        public UserRepository(ApplicationDbContext db)
        {
            _db = db;            
        }

        public UserModel verificaUsuario(UserModel userLogin)
        {
            UserModel? user = new UserModel();

            try
            {
                user  = _db.Users.Where(u => u.FullName == userLogin.FullName && u.Password == userLogin.Password).FirstOrDefault();

                return user;
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao autenticar usuario - " + ex.Message);
            }
        }

    }
}
