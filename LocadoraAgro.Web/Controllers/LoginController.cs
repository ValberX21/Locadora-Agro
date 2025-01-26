namespace LocadoraAgro.Controllers
{
    public class LoginController : Controller
    {
        private readonly UserRepository _userRepository;

        public LoginController(UserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Login(ViewUserLogin login)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    string userName = login.Nome;
                    string PassWord = login.Password;

                    byte[] userPassword = HashPassword(PassWord);

                    UserModel user = new UserModel
                    {
                        FullName = userName,
                        Password = userPassword
                    };

                    UserModel verificaUsuario = _userRepository.verificaUsuario(user);

                    if (verificaUsuario != null)
                    {
                        TempData["success"] = "Usuario autenticado !";

                        if (verificaUsuario.FullName == "admin")
                        {
                            HttpContext.Session.SetString("userCargo", verificaUsuario.FullName);
                        }


                        return RedirectToAction("Index", "Home");
                    }
                    else
                    {
                        TempData["usernotfound"] = "Usuario ou senha incorretos";
                    }
                }
                catch (Exception ex)
                {
                    TempData["error"] = ex.Message;
                }
            }
            else
            {
                TempData["error"] = "Por favor preencha todos os campos";
            }

            return View("Index");

        }

        public byte[] HashPassword(string password)
        {
            using (var sha256 = System.Security.Cryptography.SHA256.Create())
            {
                return sha256.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }
    }
}
