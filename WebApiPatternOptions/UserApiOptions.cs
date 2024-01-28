using System.ComponentModel.DataAnnotations;

namespace WebApiPatternOptions
{
    public class UserApiOptions
    {
        public const string UserApi = "UserApi";

        [Required(ErrorMessage = "O campo 'Name' é obrigatório.")]
        [StringLength(50, ErrorMessage = "O campo 'Name' deve ter no máximo 50 caracteres.")]
        public string Name { get; set; }


        [Required(ErrorMessage = "O campo 'Admin' é obrigatório.")]
        public bool Admin { get; set; }


        [Required(ErrorMessage = "O campo 'Email' é obrigatório.")]
        public string Email { get; set; }


        [Required(ErrorMessage = "O campo 'Age' é obrigatório.")]
        [Range(15, 100, ErrorMessage = "A idade deve estar entre 15 e 100 anos.")]
        public int Age { get; set; }
    }
}
