namespace AHLVBShop.Helper.CustomException
{
    public class TokenNotFoundException:Exception
    {
        public TokenNotFoundException(string message="Token bilgisi gelmedi."):base(message)
        {

        }
    }
}
