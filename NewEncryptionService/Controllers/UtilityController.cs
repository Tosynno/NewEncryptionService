using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NewEncryptionService.BusinessLogic;

namespace NewEncryptionService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UtilityController : ControllerBase
    {
        protected GeneralClass _generalClass;

        public UtilityController(GeneralClass generalClass)
        {
            _generalClass = generalClass;
        }

        [HttpGet("Encrypt/{key}/{jsontext}")]
        public ActionResult Encrypt(string key, string jsontext)
        {
            return Ok(_generalClass.EncryptString(key, jsontext));
        }

        [HttpGet("Decrypt/{key}/{Encryptedpayload}")]
        public ActionResult Decrypt(string key, string Encryptedpayload)
        {
            return Ok(_generalClass.DecryptString(key, Encryptedpayload));
        }
    }
}
