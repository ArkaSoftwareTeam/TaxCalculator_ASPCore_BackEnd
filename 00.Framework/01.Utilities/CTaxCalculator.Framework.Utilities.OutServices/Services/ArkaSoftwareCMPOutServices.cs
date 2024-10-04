using Extensions.ObjectMappers.Abstractions;
using Extensions.Serializers.Abstractions;
using Extensions.Translations.Abstractions;
using Extensions.UsersManagement.Abstractions;

namespace CTaxCalculator.Framework.Utilities.OutServices.Services
{
    public class ArkaSoftwareCMPOutServices
    {
        public readonly ITranslator Translator;
        public readonly IMapperAdapter MapperFacade;
        public readonly IUserInfoService UserInfoService;
        public readonly IJsonSerializer Serialize;
        public ArkaSoftwareCMPOutServices(ITranslator translator, IUserInfoService userInfoService, IJsonSerializer serialize, IMapperAdapter mapperFacade)
        {
            Translator = translator;
            UserInfoService = userInfoService;
            Serialize = serialize;
            MapperFacade = mapperFacade;
        }
    }
}
